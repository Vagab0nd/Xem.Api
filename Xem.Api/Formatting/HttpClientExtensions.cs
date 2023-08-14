using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading.Tasks;
using Xem.Api.Formatting;

namespace Xem.Api
{
    internal static class HttpClientExtensions
    {
        private static readonly JsonMediaTypeFormatter[] formatters = { new XemJsonMediaTypeFormatter() };

        public async static Task<T> ReadAsAsync<T>(this HttpContent httpContent)
        {
            return await httpContent.ReadAsAsync<T>(formatters);
        }
    }
}
