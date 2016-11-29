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
    [RoutePrefix("api/threads")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ThreadsController : ApiController
    {
        IRepository repository;

        public ThreadsController()
        {
            repository = new DbRepository();
        }

        [HttpGet]
        [Route("")]
        public IHttpActionResult GetThreads()
        {
            return Ok(repository.GetThreads());
        }

        [HttpGet]
        [Route("{id}")]
        public IHttpActionResult GetThread(int id)
        {
            var thread = repository.GetThread(id);

            if (thread != null)
                return Ok(thread);

            return NotFound();
        }

        [HttpPost]
        [Route("")]
        public IHttpActionResult CreateThread(Thread thread)
        {
            var data = repository.CreateThread(thread);

            if (data != null)
                return Ok(data);

            return BadRequest();
        }

        [HttpDelete]
        [Route("{id}")]
        public IHttpActionResult DeleteThread(int id)
        {
            if (!repository.DeleteThread(id))
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
