Reactive Extensions Intro ReadMe

This solution contains projects which introduces the basics of Reactive Extensions.

1. Hello Observable
   - Manually implement IEnumerable
   - Manually implement IObservable and IObserver

2. Observable Extensions
   - Use a Delegating Observer to eliminate need to create an IObserver
   - Create an IObservable.Subscribe extension method for conveniently 
     wiring up an Action<T> to a Delegating Observer
   - Use Enumerable-Observable adapter to eliminate need to create an IObservable
     that simply iterates over an IEnumerable calling OnNext for each item
   - Create an IEnumerable.ToObservable extension method for conveniently
     returning an IObservable calls OnNext on each item in a collection

3. Rx Basics
   - Add Rx-Main NuGet package
   - Filtering
     > Use Rx's ToObservable method on an int array
     > Apply Where operator to filter OnNext calls based for even ints only
   - Projection
     > Use Observable.Range to generate observable based on range of ints
	 > Use LINQ query syntax with where and select
	 > Select projects numbers as formatted strings
   - Paging
     > Use the Window method to chunk events into groups
   - Grouping
     > Similar to Window, except there is a Key for each group
	 > Group by string lengths
	 > Note that a group is established when the length changes
	   because we're dealing with streams versus buffered items

4. Rx Async
   - Scheduling
     > Selecting an IScheduler:
       NewThreadScheduler - creates a manual thread
	   ThreadPoolScheduler - thread pool thread
	   TaskPoolScheduler - uses thread pool with task
	 > StartWith (run on a specific thread)
   - Scheduling with Latency
     > Shows that enumerable observables call OnNext
       on the same thread for all elements
   - Async
     > Uses Observable.Start to execute OnNext as an async Task
	 > Items executed on different thread pool threads in parallel
	   - Specific items delayed to show results out of order