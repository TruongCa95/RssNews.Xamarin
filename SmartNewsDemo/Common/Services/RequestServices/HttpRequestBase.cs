using System.Text;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace SmartNewsDemo.Common.Services.RequestServices
{
    public class HttpRequestBase
    {
        public async Task<T> SendAsync<T>(string url, HttpMethod httpMethod, HttpContent httpContent=null)
        {
            var request = new HttpRequestMessage(httpMethod, url);
            if (httpContent != null) request.Content = httpContent;
            using (var client = DefaultHttpClient())
            {
                var response = await client.SendAsync(request);
                var body = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(body);
            }
        }
        internal Task<T> PostAsync<T>(string url, object body)
        {
            var content = new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8, "application/json");

            return SendAsync<T>(url, HttpMethod.Post, content);
        }

        internal Task<T> PostAsync<T>(string url, Dictionary<string, string> form)
        {
            var content = new FormUrlEncodedContent(form);

            return SendAsync<T>(url, HttpMethod.Post, content);
        }

        public Task<T> GetAsync<T>(string url)
        {
            return SendAsync<T>(url, HttpMethod.Get);
        }

        private HttpClient DefaultHttpClient()
        {
            return new HttpClient();
        }
    }
}
