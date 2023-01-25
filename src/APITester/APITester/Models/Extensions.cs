using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Formatting;
namespace APITester.Models
{
    public static class ExtensionsMethods
    {
        public static Task<HttpResponseMessage> PatchAsync(this HttpClient client, string requestUri, HttpContent value)
        { 
            var request = new HttpRequestMessage(new HttpMethod("PATCH"), requestUri) { Content = value };

            return client.SendAsync(request);
        }
    }
}
