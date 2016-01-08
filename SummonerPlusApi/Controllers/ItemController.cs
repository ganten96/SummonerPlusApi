using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SummonerPlusApi.Controllers
{
    public class ItemController : ApiController
    {
        [HttpGet, Route("api/Items/")]
        public IHttpActionResult GetItems()
        {
            return Ok();
        }
    }
}
