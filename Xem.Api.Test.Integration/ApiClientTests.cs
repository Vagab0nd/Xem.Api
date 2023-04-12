using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using Xem.Api.Mapping;

namespace Xem.Api.Test.Integration
{
    [TestClass]
    public class ApiClientTests
    {
        private IApiClient apiClient;

        [TestInitialize]
        public void Initialize()
        {
            this.apiClient = new ApiClient("https://thexem.info");
        }

        [TestMethod]
        public async Task GetMapping_should_return_mapping()
        {
            var result = await this.apiClient.GetMapping(new MappingQuery("24", EntityType.AniDb, 2, 1));

            result.Mappings.Count.Should().Be(2);
        }

        [TestMethod]
        public async Task GetAllMapping_should_return_all_mappings()
        {
            var result = await this.apiClient.GetAllMappings("24", EntityType.AniDb);

            result.Length.Should().Be(64);
        }

        [TestMethod]
        public async Task GetAllNames_should_return_all_names()
        {
            var result = await this.apiClient.GetAllNames(new AllNamesQuery(EntityType.AniDb));

            result.NameValues.Count.Should().BeGreaterOrEqualTo(936);
        }
    }
}
