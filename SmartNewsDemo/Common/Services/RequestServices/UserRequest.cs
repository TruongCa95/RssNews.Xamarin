using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SmartNewsDemo.Common.Constants;
using SmartNewsDemo.Model.Login;

namespace SmartNewsDemo.Common.Services.RequestServices
{
    public class UserRequest
    {
        private HttpRequestBase HttpRequestBase;
        public UserRequest(HttpRequestBase httpRequestBase)
        {
            HttpRequestBase = httpRequestBase;
        }
        public async Task<bool> LoginAsync(string email, string password)
        {
            var url = ConfigurationConstants.ID_HOST + "/connect/token";
            var response = await HttpRequestBase.PostAsync<TokenResponse>(url, new Dictionary<string, string>
            {
                {"client_id","client" },
                {"client_secret","secret" },
                {"grant_type","password" },
                {"username",email },
                {"password", password }
            });
            return false;
        }
    }
}
