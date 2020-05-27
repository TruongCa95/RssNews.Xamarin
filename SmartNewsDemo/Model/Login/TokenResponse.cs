using System;
namespace SmartNewsDemo.Model.Login
{
    internal class TokenResponse
    {
        public string AccessToken { get; set; }
        public int ExpiresIn { get; set; }
        public string Error { get; set; }
        public string ErrorDescription { get; set; }
        public DateTime ExpiresAt { get; set; }
        public bool IsExpired()
        {
            return DateTime.UtcNow > ExpiresAt;
        }
    }
}
