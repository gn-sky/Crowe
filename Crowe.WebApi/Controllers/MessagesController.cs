using System;
using System.Net;
using Crowe.Core.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Crowe.WebApi.Controllers
{
    [Route("api")]
    public class MessagesController : ControllerBase
    {
        private readonly IMessageService _messageSvc;
        public MessagesController(IMessageService messageSvc)
        {
            _messageSvc = messageSvc;
        }

        [HttpGet]
        [Route("message")]
        [ProducesResponseType(200, Type = typeof(string))]
        [EnableCors("AllowAllOrigins")]
        public IActionResult Get()
        {
            try
            {
                return Ok(_messageSvc.GetMessage());
            }
            catch (Exception)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new { ErrorMessage = "Internal Server Error on Get()" });
            }
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
