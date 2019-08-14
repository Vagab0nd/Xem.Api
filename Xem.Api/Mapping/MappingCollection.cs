using System.Collections.Generic;

namespace Xem.Api.Mapping
{
    public class MappingCollection
    {
        public MappingCollection(ICollection<MappingEntry> mappings)
        {
            this.Mappings = mappings;
        }

        public ICollection<MappingEntry> Mappings { get; private set; }
    } 
}
