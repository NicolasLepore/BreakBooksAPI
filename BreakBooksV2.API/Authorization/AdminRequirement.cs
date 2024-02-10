using Microsoft.AspNetCore.Authorization;

namespace BreakBooks.Authorization
{
    public class AdminRequirement : IAuthorizationRequirement
    {
        public AdminRequirement(string role)
        {
            Role = role;
        }
        public string Role { get; set; }
    }
}