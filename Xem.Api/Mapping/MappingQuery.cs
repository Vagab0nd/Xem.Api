using System.Collections.Generic;

namespace Xem.Api.Mapping
{

    /// <summary>
    /// Query model to fetch mapping.
    /// </summary>
    public class MappingQuery
    {
        public MappingQuery(string id, EntityType origin, int episode, int season): this(id, origin)
        {
            this.Episode = episode;
            this.Season = season;
        }

        public MappingQuery(string id, EntityType origin, int absolute) : this(id, origin)
        {
            this.Absolute = absolute;
        }

        private MappingQuery(string id, EntityType origin)
        {
            this.Id = id;
        }

        /// <summary>
        /// Id of origin entity
        /// </summary>
        public string Id { get; private set; }

        public EntityType Origin { get; private set; }

        public EntityType? Destination { get; set; }

        public int? Episode { get; private set; }

        public int? Season { get; private set; }

        public int? Absolute { get; private set; }

        public IDictionary<string, string> GetQueryValues()
        {
            var values = new Dictionary<string, string>
            {
                { "id", this.Id },
                { "origin", this.Origin.ToString().ToLower() }
            };

            if (this.Destination.HasValue)
            {
                values.Add("destination", this.Destination.ToString().ToLower());
            }

            if (this.Episode.HasValue && this.Season.HasValue)
            {
                values.Add("episode", this.Episode.ToString());
                values.Add("season", this.Season.ToString());
            } else if (this.Absolute.HasValue)
            {
                values.Add("absolute", this.Absolute.ToString());
            }

            return values;
        }
    }
}
