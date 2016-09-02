using DummyApi.EntityFramework.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DummyApi.Controllers
{
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

        protected override void Dispose(bool disposing)
        {
            repository.Dispose();
            base.Dispose(disposing);
        }
    }
}
