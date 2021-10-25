using System;

namespace EC4WebApp.Contracts.V1.Responses
{
    public class UserResponseOwn : UserResponsePublic
    {
        public DateTime DateOfBirth { get; set; }
        public string StudentId {  get; set; }
        public string Phone {  get; set; }
    }
}
