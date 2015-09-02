Web API Async ReadMe

The Models folder in the Before solution contains a ValuesRepository class,
which uses Task.Delay to simulate a database with an I/O bound async API.
We will use this repository in the ValuesController to create async actions,
which will use async / await for creating a scalable async service.

1. Start by adding a static readonly Repository field of type ValuesRepository.
   
    private static readonly ValuesRepository Repository = new ValuesRepository();

2. Refactor the Retrieve method to return a Task<IHttpActionResult>.
   - Call Repository.GetValuesAsync() to get the values
     > Use await with this call and mark method with async keyword
	 > Then simply return values.
   - Test the Retrieve method to see the delay in action
     > If you wish, set a breakpoint to see the delay take place

3. Do the same for the two Get methods, as well as the Post method
   - Check for a null response in order to throw HttpResponseException

4. For Put and Delete, add a try/catch block that catches an InvalidOperationException
   and throws an HttpResponseException
