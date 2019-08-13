using System.Collections.Generic;
using System.Threading.Tasks;
using Xem.Api.Mapping;

namespace Xem.Api
{
    public interface IApiClient
    {
        /// <summary>
        /// Get single mapping.
        /// </summary>
        /// <param name="query"></param>
        Task<MappingCollection> GetMapping(MappingQuery query);

        /// <summary>
        /// Get all mappings for origin entity id.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="origin"></param>
        Task<ICollection<MappingCollection>> GetAllMappings(string id, EntityType origin);

        /// <summary>
        /// Get all names xem has to offer for origin entity.
        /// </summary>
        /// <param name="query"></param>
        Task<NameCollection> GetAllNames(AllNamesQuery query);
    }
}
