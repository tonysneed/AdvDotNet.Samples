I/O Bound Async ReadMe

IOAsync.Web hosts a RESTful service using ASP.NET Web API, while IOAsync.Client
is a GUI app which calls the web service. The two projects in the solution are
meant to be run together, so set the solution to start multiple projects with
Web and Client projects set to start.

The the web project is using OWIN web hosting with Web API, using the following
NuGet packages:
Microsoft.Owin.Host.SystemWeb
Microsoft.AspNet.WebApi.Owin
Microsoft.Owin.Diagnostics

The client project uses the following NuGet package:
Microsoft.AspNet.WebApi.Client

Part A: Client Responsiveness

1. Run the web and client projects
   - Click the Categories button. Notice that the UI is unresponsive.
   - Then click the Products button. Notice that the UI is unresponsive.

2. Open MainForm.cs in the client project and refactor the categoriesButton_Click
   method so that the UI becomes responsive.
   - Remove .Result from the following line of code:

   HttpResponseMessage response = client.GetAsync(url).Result;

   - Instead, await the call to client.GetAsync and make categoriesButton_Click async.
   - Also remove .Result from:

   var categores = response.Content.ReadAsAsync<List<Category>>().Result;

   - And instead await the call to response.Content.ReadAsAsync

3. Refactor the productsButton_Click method in the same way
   - Running the client, you will now see that the UI is responsive when clicking
     either button.

4. As a bonus you can disable and enable the categories and products buttons

Part B: Server Scalability

The web api actions are written in a non-scalable fashion, because the call to
Task.Delay, which simulates latency, blocks the thread on which the method is called.
In this part we will use Tasks with async and await to avoid blocking the thread.

1. Change the return type of methods to Task<T> and mark it as async

    public async Task<IEnumerable<Category>> Get()
	public async Task<IEnumerable<Product>> Get(int categoryId)

2. Then await the call to Task.Delay and remove the call to Wait()
   - This will cause the compiler to re-write the code following await
     into a continuation callback that does not block the executing thread
   - This means that the executing thread can be re-used by another incoming
     request, whereas if the thread is blocked, then a new Thread Pool thread
	 must be created, which incurs additional overhead and harms scalability.
