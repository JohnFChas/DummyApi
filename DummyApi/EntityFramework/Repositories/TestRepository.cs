using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DummyApi.Models.EntityModels;

namespace DummyApi.EntityFramework.Repositories
{
    public class TestRepository : IRepository
    {
        public Post[] GetPosts()
        {
            Post[] posts = new Post[] 
            {
                new Post { Id = 1, Title = "Post 1", Author = "John Doe", PostDate = DateTime.Now, Body = "Post body" },
                new Post { Id = 2, Title = "Post 2", Author = "John Doe", PostDate = DateTime.Now, Body = "Post body" },
                new Post { Id = 3, Title = "Post 3", Author = "John Doe", PostDate = DateTime.Now, Body = "Post body" },
                new Post { Id = 4, Title = "Post 4", Author = "John Doe", PostDate = DateTime.Now, Body = "Post body" },
                new Post { Id = 5, Title = "Post 5", Author = "John Doe", PostDate = DateTime.Now, Body = "Post body" },
            };

            return posts;
        }

        public Post GetPost(int id)
        {
            return new Post { Id = id, Title = String.Format("Post {0}", id), Author = "John Doe", PostDate = DateTime.Now, Body = "Post Body" };
        }
    }
}