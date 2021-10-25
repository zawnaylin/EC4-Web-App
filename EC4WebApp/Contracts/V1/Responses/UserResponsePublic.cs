using System;

namespace EC4WebApp.Contracts.V1.Responses
{
    public class UserResponsePublic
    {
        public string DisplayName { get; set; }
        public string Email {  get; set; }
        public string PhotoPath { get; set; }
        public string Description {  get; set; }
    }
}
