namespace DummyApi.Migrations
{
    using Models.EntityModels;
    using System;
    using System.Collections.Generic;
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
                new Post { Id = 1, Title = "Post 1", Author = "John Doe", PostDate = DateTime.Now, Body = "Post body", ThreadId = 1 },
                new Post { Id = 2, Title = "Post 2", Author = "John Doe", PostDate = DateTime.Now, Body = "Post body", ThreadId = 1 },
                new Post { Id = 3, Title = "Post 3", Author = "John Doe", PostDate = DateTime.Now, Body = "Post body", ThreadId = 1 },
                new Post { Id = 4, Title = "Post 4", Author = "John Doe", PostDate = DateTime.Now, Body = "Post body", ThreadId = 1 },
                new Post { Id = 5, Title = "Post 5", Author = "John Doe", PostDate = DateTime.Now, Body = "Post body", ThreadId = 1 }
            };

            var threads = new Thread[]
            {
                new Thread { Id = 1, Name = "Welcome!", Posts = new List<Post>() }
            };

            var messages = new Message[]
            {
                new Message { Id = 1, Author = "John Doe", TimeSent = new DateTime(), ChannelId = 1, Body = "Hello #Global!" }
            };

            var channels = new Channel[]
            {
                new Channel { Id = 1, Name = "Global", Messages = new List<Message>() }
            };

            threads[0].Posts.AddRange(posts);
            channels[0].Messages.AddRange(messages);

            context.Posts.AddOrUpdate(posts);
            context.Threads.AddOrUpdate(threads);
            context.Messages.AddOrUpdate(messages);
            context.Channels.AddOrUpdate(channels);
        }
    }
}
