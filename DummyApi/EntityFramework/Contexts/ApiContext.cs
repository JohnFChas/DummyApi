using DummyApi.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DummyApi.EntityFramework.Contexts
{
    [DbConfigurationType(typeof(MySql.Data.Entity.MySqlEFConfiguration))]
    public class ApiContext : DbContext
    {
        public ApiContext()
            :base("ApiContextLocal")
        {}

        public ApiContext(string connection)
            : base(connection)
        {}

        public DbSet<Post> Posts { get; set; }
        public DbSet<Thread> Threads { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Channel> Channels { get; set; }
    }
}