using EC4WebApp.Domains;
using System;

namespace EC4WebApp.Contracts.V1.Requests
{
    public class UserUpdateRequest
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Description { get; set; }
        public string PhotoPath { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string StudentId { get; set; }

    }
}
