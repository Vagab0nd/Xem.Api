using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading.Tasks;

namespace Xem.Api
{
    public static class HttpClientExtensions
    {
        private static readonly JsonMediaTypeFormatter[] formatters = { new XemJsonMediaTypeFormatter() };

        public async static Task<T> ReadAsAsync<T>(this HttpContent httpContent)
        {
            return await httpContent.ReadAsAsync<T>(formatters);
        }
    }
}
