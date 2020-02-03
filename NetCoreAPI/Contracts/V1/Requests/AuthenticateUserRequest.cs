namespace CaseWebsites.Service.Contracts.V1.Requests
{
    public class AuthenticateUserRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
