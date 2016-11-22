using DummyApi.EntityFramework.Repositories;
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
    public class ThreadController : ApiController
    {
        IRepository repository;

        public ThreadController()
        {
            repository = new DbRepository();
        }

        [HttpGet]
        [Route("")]
        public IHttpActionResult GetThreads()
        {
            return Ok(repository.GetThreads());
        }
    }
}
