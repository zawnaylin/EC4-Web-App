using System.Collections.Generic;

namespace EC4WebApp.Contracts.V1.Responses.Authentication
{
    public struct FailResponse
    {
        public IEnumerable<string> Errors {  get; set; }
    }
}
