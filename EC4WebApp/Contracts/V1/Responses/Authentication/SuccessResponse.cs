namespace EC4WebApp.Contracts.V1.Responses.Authentication
{
    public struct SuccessResponse
    {
        public string RefreshToken { get; set; }
        public string JwtToken { get; set; }
        public string DisplayName { get; set; }
    }
}
