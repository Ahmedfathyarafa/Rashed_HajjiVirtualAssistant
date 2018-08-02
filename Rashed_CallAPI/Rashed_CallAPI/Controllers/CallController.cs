
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DSL;
using System.Web.Http.Cors;

namespace Rashed_CallAPI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class CallController : ApiController
    {
        public static CallRequestDSL callRequestDSL;
        public CallController()
        {
            callRequestDSL = new CallRequestDSL();
        }
        // GET: api/Call
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpPost]
        public IHttpActionResult RequestCall(CallRequestDTO callRequestDTO)
        {
            if (callRequestDTO == null)
                return BadRequest();
            try
            {
                var response = callRequestDSL.SendCallRequest(callRequestDTO);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        public IHttpActionResult GetAllRequestCalls()
        {
            try
            {
                var response = callRequestDSL.GetAllRequestCalls();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
