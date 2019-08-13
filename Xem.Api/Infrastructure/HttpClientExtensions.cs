using System.Net.Http;
using System.Threading.Tasks;

namespace Xem.Api.Infrastructure
{
    public static class HttpClientExtensions
    {

        public async static Task<T> GetAsJsonAsync<T>(this HttpClient client, string uri)
        {
            var result = await client.GetAsync(uri);
            result.EnsureSuccessStatusCode();
            return await result.Content.ReadAsAsync<T>();
        }
    }
}
