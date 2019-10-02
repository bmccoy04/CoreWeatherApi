using CoreWeatherApi.Core.Shared;
using System;
using System.Collections.Generic;

namespace CoreWeatherApi.Core.Entities
{ 
    public class Entry : BaseEntity
    {
        public DateTime PublishDate { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public int BlogId { get; set; }
        public Blog Blog { get; set;  }

        public ICollection<Comment> Comments { get; set; }
    }
}