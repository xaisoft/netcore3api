﻿namespace CaseWebsites.Service.Domain
{
    public class AuthenticationResult
    {
        public string Token { get; set; }
        public bool Success { get; set; }
        public string Error { get;set; }
    }
}
