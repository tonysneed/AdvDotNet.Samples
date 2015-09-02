Web API Routing ReadMe

Part A: Convention-Based Routing

1. Open WebApiConfig.cs and have a look at the Register method,
   which is being called from Application_Start in Global.asax.cs.
   - Notice the call to config.Routes.MapHttpRoute, where we pass in
     a new route named "DefaultApi".
   - Notice the routeTemplate parameter, which is a string literal
     with placeholders in brackets

2. Let's fiddle with the routing configuration a bit
   - Remove "api/" from the route template
     > Then see if you can invoke an action without "api" in the url
   - But then let's try to configure the routes to support both paths
     > If you add the original route again by calling MapHttpRoute with
	   a different route name, you won't be able to call an action with api
	 > The reason is that the first route will interpret api as a controller name
	 > So reverse the calls so that it tries routes with api in the url first

3. Next let's experiment with action name conventions
   - Notice we can add any suffix to a Get method name
   - But then if we change the method from Get to Retrieve, we get a 404
     if we try this url: http://localhost:51803/api/Values/Retrieve
   - Add the {action} placeholder to the route template:
     "api/{controller}/{action}/{id}"
     > This url will then generate a 405 Method Not Allowed response
	 > The reason for this is that it doesn't know where to map an HTTP GET verb,
	   because we have deviated from the Get prefix convention
   - To remedy this, we can add an [HttpGet] attribute to the Retrieve method

Part B: Attribute-Based Routing

1. We'd like to remove the need for the action name when routing to the Retrieve
   method.  This is where attribute-based routing comes in handy.
   - First, let's try adding a Route attribute to Retrieve with "api/{controller}"
     > This will generate the following error:
	 "A direct route cannot use the parameter 'controller'. Specify a literal path in
	  place of this parameter to create a route to a controller."
   - As the message states, we have to use a literal path rather than a placeholder,
     which makes sense because this attribute applies to a specific action.
	 > Change the template to: "api/values"

2. Next apply the following attribute to the GetValuesById method:
   [Route("api/values")]
   - Refresh the Help page to see how the routing has been affected
   > Notice that convention still works here, because HTTP GET is mapped based
     on the Get profix in the method name
   > Also notice that the parameters are mapped by default using query strings
     GET api/values?id={id}
	 - Change the route attribute to add the id parameter placeholder:
	   [Route("api/values/{id}")]

3. Now we'll try overloading the route to use another method for getting value
   by string instead of int
   - Change the existing route parameter for GetValuesById to constrain by data type:
     [Route("api/values/{id:int}")]
   - Copy the method and refactor it to accept a name parameter of type string

    [ResponseType(typeof(string))]
    public IHttpActionResult GetValuesById(string name)
    {
        var value = Values.SingleOrDefault(e => e == name);
        if (value == null)
            throw new HttpResponseException(HttpStatusCode.NotFound);
        return Ok(value);
    }

    > Add the following route attribute:
	[Route("api/values/{name}")]
	  - Note this is alphanumeric by default, so it accepts value5 as a parameter,
	    but it can be constrained to only alpha characters with {name:alpha},
		in which case value5 would not route to the method.

5. We can remove some of the repetition in the method routes by adding a
   RoutePrefix attribute to the controller.
   - [RoutePrefix("api/values")]
   - Remove "api/values" from the route attribute for each action

6. As a result of using the RoutePrefix attribute, you'll find that the Post
   method can no longer be found, because we are no longer using the DefaultApi
   route table configured for the app.
   - You'll need to add the [HttpPost, Route("")] attribute to the Post method
     > However, you'll get a runtime exception because the DefaultApi route is
	   not being used to invoke the action.
   - Add a Name parameter to the Route attribute, such as DefaultApi2, then
     update the first parameter to CreatedAtRoute to match.
   - Finally, add attributes to Put and Delete methods:
    [HttpPut, Route("{id}")]
    [HttpDelete, Route("{id}")]
   