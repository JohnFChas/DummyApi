﻿using DummyApi.EntityFramework.Repositories;
using DummyApi.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace DummyApi.Controllers
{
    [RoutePrefix("api/messages")]
    public class MessagesController : ApiController
    {
        IRepository repository;

        public MessagesController()
        {
            repository = new DbRepository();
        }

        [HttpGet]
        [ResponseType(typeof(Message[]))]
        public IHttpActionResult GetMessages()
        {
            return Ok(repository.GetMessages());
        }

        [HttpGet]
        [ResponseType(typeof(Message))]
        public IHttpActionResult GetMessage(int id)
        {
            return Ok(repository.GetMessage(id));
        }

        [HttpPost]
        [ResponseType(typeof(void))]
        public IHttpActionResult CreateMessage(Message message)
        {
            if (message == null || !repository.CreateMessage(message))
                return BadRequest();

            return Ok();
        }

        [HttpDelete]
        [ResponseType(typeof(void))]
        public IHttpActionResult DeleteMessage(int id)
        {
            if (!repository.DeleteMessage(id))
                return NotFound();

            return Ok();
        }

        protected override void Dispose(bool disposing)
        {
            repository.Dispose();
            base.Dispose(disposing);
        }
    }
}
