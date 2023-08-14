using System.Collections.Generic;
using Xem.Api.Formatting;

namespace Xem.Api.Mapping
{

    /// <summary>
    /// Query model to fet all names.
    /// </summary>
    public class AllNamesQuery
    {
        public AllNamesQuery(EntityType origin)
        {
            this.Origin = origin;
        }

        public EntityType Origin { get; private set; }

        public int? Season { get; set; }

        public CompareOperator? SeasonOperator { get; set; }

        /// <summary>
        /// 2 character language code. ex: us, jp. Defaults to all if not specified.
        /// </summary>
        public string Language { get; set; }

        /// <summary>
        /// Should the default names be added to the list.
        /// </summary>
        public bool? DefaultNames { get; set; }

        public IDictionary<string, string> GetQueryValues()
        {
            var values = new Dictionary<string, string>
            {
                { "origin", this.Origin.ToString().ToLower() }
            };

            if (this.Season.HasValue)
            {
                var seasonValue = this.SeasonOperator.HasValue ? $"{this.SeasonOperator.Value.AsString()}{this.Season}" : this.Season.ToString();
                values.Add("season", seasonValue);
            }

            //TODO: validate using region/culture info?
            if (string.IsNullOrWhiteSpace(this.Language) == false && this.Language.Length == 2)
            {
                values.Add("language", this.Language);
            }

            if (this.DefaultNames.HasValue)
            {
                values.Add("defaultNames", this.DefaultNames.Value ? "1" : "0");
            }

            return values;
        }
    }
}
