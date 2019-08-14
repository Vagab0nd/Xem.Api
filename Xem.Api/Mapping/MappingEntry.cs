namespace Xem.Api.Mapping
{
    /// <summary>
    /// Describes mapping value for given mapping entry.
    /// </summary>
    public class MappingEntry
    {
        public int EntityIndex { get; set; }

        public EntityType EntityType { get; set; }

        public int Season { get; set; }

        public int Episode { get; set; }

        public int Absolute { get; set; }
    }
}
