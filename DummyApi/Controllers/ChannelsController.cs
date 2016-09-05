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
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ChannelsController : ApiController
    {
        IRepository repository;

        public ChannelsController()
        {
            repository = new DbRepository();
        }

        [HttpGet]
        public IHttpActionResult GetChannels()
        {
            return Ok(repository.GetChannels());
        }

        [HttpGet]
        public IHttpActionResult GetChannel(int id)
        {
            return Ok(repository.GetChannel(id));
        }

        [HttpPost]
        public IHttpActionResult CreateChannel(Channel channel)
        {
            if (repository.CreateChannel(channel))
                return Ok();

            return BadRequest();
        }

        protected override void Dispose(bool disposing)
        {
            repository.Dispose();
            base.Dispose(disposing);
        }
    }
}
