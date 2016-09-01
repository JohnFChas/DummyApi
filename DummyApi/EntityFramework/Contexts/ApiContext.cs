using DummyApi.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DummyApi.EntityFramework.Contexts
{
    public class ApiContext : DbContext
    {
        public ApiContext()
            :base("ApiContextLocal")
        {}

        public ApiContext(string connection)
            : base(connection)
        {}

        public DbSet<Post> Posts { get; set; }
    }
}