using System.Collections.Generic;

namespace EC4WebApp.Domains
{
    public class AuthenticationResults
    {
        public bool Success { get; set; }
        public IEnumerable<string> Errors { get; set; }
        public string Token { get; set; }
        public string UserId { get; set; }
        public string DisplayName {  get; set; }
    }
}
