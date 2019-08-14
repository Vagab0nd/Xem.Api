using System.Collections.Generic;

namespace Xem.Api.Mapping
{
    public class NameCollection
    {
        public NameCollection(IDictionary<string, string[]> nameValues)
        {
            this.NameValues = nameValues;
        }

        /// <summary>
        /// id - names
        /// </summary>
        public IDictionary<string, string[]> NameValues { get; private set; }
    }
}
