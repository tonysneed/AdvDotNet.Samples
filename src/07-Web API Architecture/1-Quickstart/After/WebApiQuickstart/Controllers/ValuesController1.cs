using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace WebApiQuickstart.Controllers
{
    public class ValuesController1 : ApiController
    {
        private static readonly List<string> Values = new List<string>
            {
                "value1", "value2", "value3", "value4", "value5"
            };

        // GET api/values
        [ResponseType(typeof(IEnumerable<string>))]
        public HttpResponseMessage Get()
        {
            return Request.CreateResponse(HttpStatusCode.OK, Values.ToArray());
        }

        // GET api/values/5
        [ResponseType(typeof(string))]
        public HttpResponseMessage Get(int id)
        {
            if (id < 1 || id > Values.Count)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            return Request.CreateResponse(HttpStatusCode.OK, Values[id - 1]);
        }

        // POST api/values
        [ResponseType(typeof(string))]
        public HttpResponseMessage Post([FromBody]string value)
        {
            Values.Add(value);
            var response = Request.CreateResponse(HttpStatusCode.Created, value);
            response.Headers.Location = new Uri(Request.RequestUri,
                "values/" + Values.Count);
            return response;
        }

        //public void Post([FromBody]string value)
        //{
        //    Values.Add(value);
        //}

        // PUT api/values/5
        public HttpResponseMessage Put(int id, [FromBody]string value)
        {
            if (id < 1 || id > Values.Count)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            Values[id - 1] = value;
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        //public void Put(int id, [FromBody]string value)
        //{
        //    Values[id - 1] = value;
        //}

        // DELETE api/values/5
        public HttpResponseMessage Delete(int id)
        {
            if (id < 1 || id > Values.Count)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            Values.RemoveAt(id - 1);
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
