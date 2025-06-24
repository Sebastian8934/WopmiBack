﻿namespace WebApi.Models.Responses.Auth
{
    public class LoginResponse
    {
        public string Token { get; set; }
        public int ExpiresIn { get; set; }
        public string TokenType { get; set; } = "Bearer";
    }
}
