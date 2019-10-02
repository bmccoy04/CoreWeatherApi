using CoreWeatherApi.Core.Shared;
using System;
using System.Collections.Generic;

namespace CoreWeatherApi.Core.Entities
{
    public class User : BaseEntity
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime BirthDate{ get; set; }

        public string ProfileImageLink { get; set; }

        public ICollection<Comment> Comments { get; set; }

        public ICollection<Blog> Blogs { get; set; }
    }
}