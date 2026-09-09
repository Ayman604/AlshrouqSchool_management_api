using AlshrouqSchool.Application.Interfaces;
using AlshrouqSchool.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.Json;

namespace AlshrouqSchool.Infrastructure.LiveKit;

/// <summary>Issues short-lived LiveKit access tokens; its API secret is never stored in the database.</summary>
public sealed class LiveKitService(AlshrouqDbContext db, IOptions<LiveKitOptions> options) : ILiveKitService
{
    public async Task<LiveKitParticipantToken> CreateParticipantTokenAsync(int liveSessionId, string participantIdentity,
        string participantName, bool canPublish, CancellationToken cancellationToken = default)
    {
        var room = await db.LiveSessions.AsNoTracking().Where(x => x.Id == liveSessionId)
            .Select(x => x.RoomName).SingleOrDefaultAsync(cancellationToken)
            ?? throw new KeyNotFoundException($"Live session {liveSessionId} was not found.");
        var settings = options.Value;
        if (string.IsNullOrWhiteSpace(settings.ApiKey) || string.IsNullOrWhiteSpace(settings.ApiSecret))
            throw new InvalidOperationException("LiveKit API credentials are not configured.");
        var now = DateTime.UtcNow;
        var expires = now.AddMinutes(settings.TokenLifetimeMinutes);
        var grant = JsonSerializer.Serialize(new { roomJoin = true, room, canPublish, canSubscribe = true });
        var claims = new[] { new Claim(JwtRegisteredClaimNames.Sub, participantIdentity), new Claim("name", participantName), new Claim("video", grant, JsonClaimValueTypes.Json) };
        var signing = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(settings.ApiSecret)), SecurityAlgorithms.HmacSha256);
        var token = new JwtSecurityToken(settings.ApiKey, null, claims, now, expires, signing);
        return new(new JwtSecurityTokenHandler().WriteToken(token), expires);
    }
}
