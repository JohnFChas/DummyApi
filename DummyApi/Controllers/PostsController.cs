using DummyApi.EntityFramework.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DummyApi.Controllers
{
    [RoutePrefix("api/posts")]
    public class PostsController : ApiController
    {
        IRepository repository;

        public PostsController()
        {
            repository = new TestRepository();
        }

        public IHttpActionResult GetPosts()
        {
            return Ok(repository.GetPosts());
        }
    }
}
