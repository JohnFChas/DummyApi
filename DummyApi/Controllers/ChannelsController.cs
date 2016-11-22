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
    [RoutePrefix("api/channels")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ChannelsController : ApiController
    {
        IRepository repository;

        public ChannelsController()
        {
            repository = new DbRepository();
        }

        [HttpGet]
        [Route("")]
        public IHttpActionResult GetChannels()
        {
            return Ok(repository.GetChannels());
        }

        [HttpGet]
        [Route("{id}")]
        public IHttpActionResult GetChannel(int id)
        {
            var channel = repository.GetChannel(id);

            if (channel != null)
                return Ok(channel);

            return BadRequest();
        }

        [HttpPost]
        [Route("")]
        public IHttpActionResult CreateChannel(Channel channel)
        {
            var data = repository.CreateChannel(channel);
            if (data != null)
                return Ok(data);

            return BadRequest();
        }

        [HttpDelete]
        [Route("{id}")]
        public IHttpActionResult DeleteChannel(int id)
        {
            if (!repository.DeleteChannel(id))
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
