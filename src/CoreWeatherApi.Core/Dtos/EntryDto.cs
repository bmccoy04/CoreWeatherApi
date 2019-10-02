using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreWeatherApi.Core.Dtos
{
    public class EntryDto
    {
        public int Id { get; set; }

        public DateTime PublishDate { get; set; }

        public string Content { get; set; }

        public int UserId { get; set; }
    }
}
