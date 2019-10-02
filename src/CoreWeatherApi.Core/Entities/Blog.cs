using CoreWeatherApi.Core.Shared;
using System.Collections.Generic;

namespace CoreWeatherApi.Core.Entities
{
    public class Blog : BaseEntity
    {
        public string Name { get; set; }

        public ICollection<Entry> Entries{ get; set; }
    }
}