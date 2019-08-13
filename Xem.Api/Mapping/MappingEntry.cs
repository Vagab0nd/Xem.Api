namespace Xem.Api.Mapping
{
    /// <summary>
    /// Describes mapping value for given mapping entry.
    /// </summary>
    public class MappingEntry
    {
        public int EntityIndex { get; private set; }

        public EntityType EntityType { get; private set; }

        public int Season { get; private set; }

        public int Episode { get; private set; }

        public int Absolute { get; private set; }
    }
}
