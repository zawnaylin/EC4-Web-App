using Microsoft.AspNetCore.Identity;
using System;

namespace EC4WebApp.Domains
{
    public class User : IdentityUser
    {
        public string DisplayName { get; set; }
        public string Description { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PhotoPath { get; set; }
        public string StudentId { get; set; }
        public bool IsVerified { get; set; }
    }
}
