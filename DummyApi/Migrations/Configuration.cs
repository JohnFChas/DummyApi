namespace DummyApi.Migrations
{
    using Models.EntityModels;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DummyApi.EntityFramework.Contexts.ApiContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DummyApi.EntityFramework.Contexts.ApiContext context)
        {
            var posts = new Post[]
            {
                new Post { Id = 1, Title = "Post 1", Author = "John Doe", PostDate = DateTime.Now, Body = "Post body" },
                new Post { Id = 2, Title = "Post 2", Author = "John Doe", PostDate = DateTime.Now, Body = "Post body" },
                new Post { Id = 3, Title = "Post 3", Author = "John Doe", PostDate = DateTime.Now, Body = "Post body" },
                new Post { Id = 4, Title = "Post 4", Author = "John Doe", PostDate = DateTime.Now, Body = "Post body" },
                new Post { Id = 5, Title = "Post 5", Author = "John Doe", PostDate = DateTime.Now, Body = "Post body" }
            };

            context.Posts.AddOrUpdate(posts);
        }
    }
}
