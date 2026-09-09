using Microsoft.AspNetCore.Identity;

namespace AlshrouqSchool.Core.Entities.Identity;

public class ApplicationUser : IdentityUser
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string? ProfilePictureUrl { get; set; }
    public Teacher? Teacher { get; set; }
    public Student? Student { get; set; }
    public Parent? Parent { get; set; }
}
