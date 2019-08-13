using Microsoft.AspNetCore.WebUtilities;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Xem.Api.Infrastructure;
using Xem.Api.Mapping;

namespace Xem.Api
{
    public class ApiClient : IApiClient
    {
        private readonly HttpClient client;

        public ApiClient(string baseUri)
        {
            this.client = new HttpClient { BaseAddress = new Uri(baseUri) };
            this.client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<ICollection<MappingCollection>> GetAllMappings(string id, EntityType origin)
        {
            var respone = await this.client.GetAsJsonAsync<MappingCollection[]>($"/map/all?id={id}&origin={origin.ToString().ToLower()}");
            return respone;
        }

        public Task<NameCollection> GetAllNames(AllNamesQuery query)
        {
            throw new NotImplementedException();
        }

        public async Task<MappingCollection> GetMapping(MappingQuery query)
        {
            var uri = QueryHelpers.AddQueryString("/map/all", query.GetQueryValues());
            var respone = await this.client.GetAsJsonAsync<MappingCollection>(uri);
            return respone;
        }
    }
}
