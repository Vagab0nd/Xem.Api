using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;
using Xem.Api.Formatting;
using Xem.Api.Mapping;

namespace Xem.Api
{
    public class ApiClient : IApiClient
    {
        private readonly XemHttpClientWrapper httpClientWrapper;

        public ApiClient(string baseUri)
        {
            this.httpClientWrapper = new XemHttpClientWrapper(baseUri);
        }

        public async Task<MappingCollection[]> GetAllMappings(string id, EntityType origin)
        {
            var respone = await this.httpClientWrapper.DoAsync(c => c.GetAsync($"map/all?id={id}&origin={origin.ToString().ToLower()}"));
            return await this.GetDataFromResponse<MappingCollection[]>(respone);
        }

        public async Task<NameCollection> GetAllNames(AllNamesQuery query)
        {
            var uri = "/map/allNames".AddQueryValues(query.GetQueryValues());
            var respone = await this.httpClientWrapper.DoAsync(c => c.GetAsync(uri));
            return await this.GetDataFromResponse<NameCollection>(respone);
        }

        public async Task<MappingCollection> GetMapping(MappingQuery query)
        {
            var uri = "/map/single".AddQueryValues(query.GetQueryValues());
            var respone = await this.httpClientWrapper.DoAsync(c => c.GetAsync(uri));
            return await this.GetDataFromResponse<MappingCollection>(respone);
        }

        private async Task<T> GetDataFromResponse<T>(HttpResponseMessage httpResponse)
        {
            var response = await httpResponse.Content.ReadAsAsync<ResponseBase>();
            return JsonConvert.DeserializeObject<T>(response.Data.ToString(), new MappingCollectionJsonConverter(), new NameCollectionJsonConverter());
        }
    }
}
