namespace EC4WebApp.Contracts.V1
{
    public static class ApiRoutes
    {
        public const string Root = "api";
        public const string Version = "v1";
        public const string Base = Root + "/" + Version;

        public static class Identity
        {
            public const string Login = Base + "/identity/login";
            //public const string Logout = Base + "/identity/logout";
            public const string User = Base + "/identity/members/{id}";
            public const string AllUsers = Base + "/identity/members";
        }
    }
}
