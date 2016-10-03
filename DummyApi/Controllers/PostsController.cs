using DummyApi.EntityFramework.Repositories;
using DummyApi.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace DummyApi.Controllers
{
    [RoutePrefix("api/posts")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class PostsController : ApiController
    {
        IRepository repository;

        public PostsController()
        {
            repository = new DbRepository();
        }

        [HttpGet]
        public IHttpActionResult GetPosts()
        {
            return Ok(repository.GetPosts());
        }

        [HttpGet]
        public IHttpActionResult GetPost(int id)
        {
            return Ok(repository.GetPost(id));
        }

        [HttpPost]
        public IHttpActionResult CreatePost(Post post)
        {
            if (post == null || !repository.CreatePost(post))
                return BadRequest();

            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult DeletePost(int id)
        {
            if (!repository.DeletePost(id))
                return BadRequest();

            return Ok();
        }

        protected override void Dispose(bool disposing)
        {
            repository.Dispose();
            base.Dispose(disposing);
        }
    }
}