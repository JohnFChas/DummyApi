using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DummyApi.Models.EntityModels;
using DummyApi.EntityFramework.Contexts;

namespace DummyApi.EntityFramework.Repositories
{
    public class DbRepository : IRepository
    {
        ApiContext db = new ApiContext();

        public Post GetPost(int id)
        {
            throw new NotImplementedException();
        }

        public Post[] GetPosts()
        {
            throw new NotImplementedException();
        }
    }
}