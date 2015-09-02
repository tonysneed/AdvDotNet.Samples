using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;

namespace WebApiQuickstart.Controllers
{
    [RoutePrefix("api/values")]
    public class ValuesController : ApiController
    {
        private static readonly List<string> Values = new List<string>
            {
                "value1", "value2", "value3", "value4", "value5"
            };

        // GET api/values/retrieve
        [HttpGet, Route("")]
        [ResponseType(typeof(IEnumerable<string>))]
        public IHttpActionResult Retrieve()
        {
            return Ok(Values.ToArray());
        }

        // GET api/values/5
        [Route("{id:int}")]
        [ResponseType(typeof(string))]
        public IHttpActionResult GetValuesById(int id)
        {
            if (id < 1 || id > Values.Count)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            return Ok(Values[id - 1]);
        }

        // GET api/values/5
        [Route("{name}")]
        [ResponseType(typeof(string))]
        public IHttpActionResult GetValuesById(string name)
        {
            var value = Values.SingleOrDefault(e => e == name);
            if (value == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            return Ok(value);
        }

        // POST api/values
        [HttpPost, Route("", Name = "DefaultApi2")]
        [ResponseType(typeof(string))]
        public IHttpActionResult Post([FromBody]string value)
        {
            Values.Add(value);
            return CreatedAtRoute("DefaultApi2", new { id = Values.Count }, value);
        }

        // PUT api/values/5
        [HttpPut, Route("{id}")]
        public IHttpActionResult Put(int id, [FromBody]string value)
        {
            if (id < 1 || id > Values.Count)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            Values[id - 1] = value;
            return Ok();
        }

        // DELETE api/values/5
        [HttpDelete, Route("{id}")]
        public IHttpActionResult Delete(int id)
        {
            if (id < 1 || id > Values.Count)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            Values.RemoveAt(id - 1);
            return Ok();
        }
    }
}
