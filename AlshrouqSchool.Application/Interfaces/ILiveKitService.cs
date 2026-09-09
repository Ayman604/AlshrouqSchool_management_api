namespace AlshrouqSchool.Application.Interfaces;

public sealed record LiveKitParticipantToken(string Token, DateTime ExpiresAtUtc);

public interface ILiveKitService
{
    Task<LiveKitParticipantToken> CreateParticipantTokenAsync(int liveSessionId, string participantIdentity,
        string participantName, bool canPublish, CancellationToken cancellationToken = default);
}
