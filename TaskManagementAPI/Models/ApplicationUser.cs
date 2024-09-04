using Microsoft.AspNetCore.Identity;

namespace TaskManagementAPI.Models
{
    public class ApplicationUser :IdentityUser
    {
        public string? Name { get; set; }
    }
}
