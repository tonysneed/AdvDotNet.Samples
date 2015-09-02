using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using WebApiQuickstart.Models;

namespace WebApiQuickstart.Controllers
{
    [RoutePrefix("api/values")]
    public class ValuesController : ApiController
    {
        private static readonly List<string> Values = new List<string>
            {
                "value1", "value2", "value3", "value4", "value5"
            };

        private static readonly ValuesRepository Repository = new ValuesRepository();

        // GET api/values/retrieve
        [HttpGet, Route("")]
        [ResponseType(typeof(IEnumerable<string>))]
        public async Task<IHttpActionResult> Retrieve()
        {
            var values = await Repository.GetValuesAsync();
            return Ok(values);
        }

        // GET api/values/5
        [Route("{id:int}")]
        [ResponseType(typeof(string))]
        public async Task<IHttpActionResult> GetValuesById(int id)
        {
            var value = await Repository.GetValueAsync(id);
            if (value == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            return Ok(Values[id - 1]);
        }

        // GET api/values/5
        [Route("{name}")]
        [ResponseType(typeof(string))]
        public async Task<IHttpActionResult> GetValuesById(string name)
        {
            var value = await Repository.GetValueAsync(name);
            if (value == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            return Ok(value);
        }

        // POST api/values
        [HttpPost, Route("", Name = "DefaultApi2")]
        [ResponseType(typeof(string))]
        public async Task<IHttpActionResult> Post([FromBody]string value)
        {
            await Repository.AddValueAsync(value);
            return CreatedAtRoute("DefaultApi2", new { id = Values.Count }, value);
        }

        // PUT api/values/5
        [HttpPut, Route("{id}")]
        public async Task<IHttpActionResult> Put(int id, [FromBody]string value)
        {
            try
            {
                await Repository.UpdateAsync(id, value);
            }
            catch (InvalidOperationException)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return Ok();
        }

        // DELETE api/values/5
        [HttpDelete, Route("{id}")]
        public async Task<IHttpActionResult> Delete(int id)
        {
            try
            {
                await Repository.DeleteAsync(id);
            }
            catch (InvalidOperationException)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return Ok();
        }
    }
}
