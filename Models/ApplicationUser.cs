using Microsoft.AspNetCore.Identity;

namespace Tazaker.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        //public string? ProfilePicture { get; set; } 

    }
}
