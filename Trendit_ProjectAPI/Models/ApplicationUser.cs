using Microsoft.AspNetCore.Identity;

namespace Trendit_ProjectAPI.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
    }

}
