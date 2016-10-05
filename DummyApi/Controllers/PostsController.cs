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
            if (post == null)
                return BadRequest();

            var data = repository.CreatePost(post);

            if (data == null)
                return InternalServerError();

            return Ok(data);
        }

        [HttpPut]
        [Route("{id}")]
        public IHttpActionResult UpdatePost(int id, Post post)
        {
            if (post == null || id != post.Id)
                return BadRequest();

            var data = repository.UpdatePost(post);

            return Ok(data);
        }

        [HttpDelete]
        public IHttpActionResult DeletePost(int id)
        {
            if (!repository.DeletePost(id))
                return BadRequest();

            return Ok();
        }

        [Route("upvote/{id}")]
        [HttpPut]
        public IHttpActionResult UpvotePost(int id)
        {
            var data = repository.UpvotePost(id);

            if (data == null)
                return InternalServerError();

            return Ok(data);
        }

        [Route("downvote/{id}")]
        [HttpPut]
        public IHttpActionResult DownvotePost(int id)
        {
            var data = repository.DownvotePost(id);

            if (data == null)
                return InternalServerError();

            return Ok(data);
        }

        protected override void Dispose(bool disposing)
        {
            repository.Dispose();
            base.Dispose(disposing);
        }
    }
}