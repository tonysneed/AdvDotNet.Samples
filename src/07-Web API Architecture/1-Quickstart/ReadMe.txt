ASP.NET Web API Quickstart ReadMe

1. Add a new web project to the solution.
   - Select the Web API template
   - Change authentication to None

2. Update all the NuGet packages
   - Respond 'Yes to All' when prompted to overwrite files
   - Install the following NuGet package: WebApiTestOnHelpPage
   - Update kockout.js (do NOT update jQuery UI)

3. Build the solution, then view in browser
   - Press Ctrl+W to launch app using IIS Express
   - Click API, GET api/Values, then click the Test API button
   - Click the Send button to return a JSON array of values
   - Add Accept header of application/xml to return the XML representation

4. Update the Values controller to implement all the methods
   - Add static field: List<string> Values
     > Set values in field initializer
   - Refactor both GET actions to return Values, Values[id-1]
   - Refactor Post to add a value to the list
   - Refactor Put to update a value in the list
   - Refactor Delete to remote a value from the list
   - Build, then test all actions, this time using Fiddler

5. Refactor Values controller methods to return HttpResponseMessage 
   - We need to update the Post method to return a 201 Created status code,
     as well as a Location header with a url pointing to newly created resource.

    // POST api/values
    public HttpResponseMessage Post([FromBody]string value)
    {
        Values.Add(value);
        var response = Request.CreateResponse(HttpStatusCode.Created, value);
        response.Headers.Location = new Uri(Request.RequestUri,
            "values/" + Values.Count);
        return response;
    }

	- Next, we can refactor the Put method to return a 404 Not Found status code
	  if the id is greater than the number of items in the list.
	  > We should also return a status code of 200 OK

    public HttpResponseMessage Put(int id, [FromBody]string value)
    {
        if (id < 1 || id > Values.Count)
            throw new HttpResponseException(HttpStatusCode.NotFound);
        Values[id - 1] = value;
        return Request.CreateResponse(HttpStatusCode.OK);
    }

   - Do the same refactoring for the Get and Delete methods
     > Each method should return HttpResponseMessage
	 > Methods accepting an id should return Not Found with invalid id

6. Lastly, we'll simplify our code and make our actions more easily testable
   by using the IHttpActionResult abstraction.
   - First, copy and rename ValuesContoller (append a 1 to the name)
   - Set the return type of each action to IHttpActionResult
   - Use the ApiController helper methods to return results
