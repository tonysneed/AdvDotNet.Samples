Visual Studio Debugging Demos

The PickupDebugging project is a Windows Forms app which has some bugs in it.
We will use VS debugging tools to locate and correct these bugs. There are separate
solutions for PickupDebugging and PickupLib projects.

The main app has a reference to PickupLib.dll in the Lib folder, which does
not have the accompanying pdb file, which can instead be found in the Symbols folder.
This is to replicate an environment in which a component is deployed without a pdb file,
but the pdb file is stored in source control or on an internal network share.

Part A: Symbols

1. VS Debugging Options
   - Show line numbers: Tools, Options, Text Editor, All Languages
   - Tools, Options, Debugging:
     > Uncheck 'Step over properties and operators'
	 > Uncheck 'Enable Just My Code'

2. Debugging without symbols
   - Set a breakpoint in MainForm.loadButton_Click method.
     > Press F5 to debug, click Load button to hit the breakpoint.
	 > Notice you cannot step into PickupLib code.

3. Modules window, symbol settings
   - Debug, Windows, Modules
   - Note that symbols for PickupLib.dll are NOT loaded
   - Right-click, select Symbol Load Information; note search paths
   - Right-click, select Load Symbols From Symbol Path
     > Specify Symbols directory above solution root
   - Right-click, select Symbol Settings
     > Note addition of selected symbol path

4. Step into PickupLib code
   - After loading the pdb file, you should be able to step into
     PickupHelper.GetLine
   - If you modify the source code file, VS will ask if you want to use it anyway
     > Saying No will display the "No Source Available" page,
	   but you can still browse to a source file from there
	 > You can also show disassebly and see where it is getting source from

5. Other Debug Windows
   - Look at Call Stack and Parallel Stacks windows
   - Note that while you can load symbols for the .NET Framework,
     there are a few hoops to jump before being able to step through
	 the framework source code.
	 > Software upgrades and patches modify Framework DLL's (for ex, .NET 4.5)
	 > See http://stackoverflow.com/questions/8139269/how-do-you-enable-enable-net-framework-source-stepping
   - While you're at it, take a look at the Debug Threads window
     > Notice the three named threads, including Main Thread, vshost and system events
	 > Notice the unnamed thread, which is a high priority finalization thread
	   that is hidden in the Parallel Stacks window
   - It's also fun to look at Disassebly and Registers windows to see native JIT'd code,
     and even step through it
	 > This includes disassembly for Framework code, even without the Framework source code

Part B: Breakpoints

1. Trackpoints (When Hit)
   - The first problem we'd like to solve is that responses are not correlated with lines,
     and we'll even get different responses for the same line.
   - To troubleshoot this we'll insert a tracepoint that prints out the selected index of
     the combo box, so that we can look up the correct response for that line.
   - We'll start by using the Breakpoints window to insert a breakpoint at a specific location
     > Select New, Break at Function, type: goButton_Click
	 > Right-click breakpoint and select When Hit
	 > Check Print a Message and type: Selected Line Index: {pickupLinesComboBox.SelectedIndex}
	   Breakpoint shape will change to a diamond to indiciate it's a tracepoint
   - Press F5, open the Output window
     > Click the Go button to see the following: Selected Line Index: -1
	 > Click Load button to populate list, then click Go after selecting different items.
	   You should see the corresponding index printed to the output window

2. Conditional Breakpoint
   - Obviously this didn't tell us what we didn't already know. So to further troubleshoot,
     we'll add a conditional breakpoint.
   - Set a breakpoint in PickupHelper.cs at line 46.
   - Add the condition: random < _responses.Count (keep Is True option)
   - This allows us to see if the response is the same
   - On line 47, add a tracepoint: Correct Response: {_responses[index]}
     > Compare correct response with the actual response

3. Hit Count
   - In MainForm.cs, line 34, add a breakpoint
   - Set the Hit Count to break when the count is greater than or equal to 3
   - Press F5 and click the Load button to break after two iterations.
   - Reset it to multiples of 2 and check the value of the lines parameter
     > Use locals or autos window
	 > Try pinning the data tip to see the value of lines

4. Filters
   - Set breakpoint in PickupHelper line 40
   - Add the following filter: ThreadName != "Main Thread"
   - This will only break when clicking the Load button with Async checked

5. Exceptions
   - Notice the debugger is not breaking on the ArgumentOutOfRangeException
     > This is because we are handling all exceptions at the Application level
   - Set Exceptions to break when System.ArgumentOutOfRangeException is thrown
     > Debug menu, Exceptions
     > You can click Find to locate it
	 > It's also possible to break on all CLR exceptions

6. Parallel Tasks
   - Press F5, check Async, press Load button
   - Then click Go button until ArgumentOutOfRangeException is thrown
     > You should still have Exceptions set to break on that exception
	 > Notice the Managed Debugging Assistance that appears on the exception break,
	   which is especially helpful to see the InnerExceptions of the AggregateException
	   in the task continuations
   - Open the Parallel Tasks window to see the call stack for the task
   - After clicking a few times, you will break on the exception
   - But notice that the application-level handler is not invoked
   - Set Exceptions to break on all CLR exceptions
     - Notice that you break on MainForm.cs, line 87, which throws t.Exception
	 - Also notice that the thrown exception is consumed by the runtime

Part C: Fixing the Problems

1. PickupHelper.GetResponse
   - Remove * 2 from rng.Next
   - Change _responses indexer from random to index
   - Run the app.
     > Responses will be correlated with selected line
	 > Occassionally a DrinkInYourFace exception will be thrown

2. Async GetResponse error handler
   - Comment out throw t.Exception in MainForm.cs, line 88
   - Add following code:
		string excMessage = GetErrorMessage(t.Exception);
		MessageBox.Show(excMessage, "Error");
   - Message box will show error message when clicking Go with async selected
     > You may have to click Go a number of times to get random exception

Part D: Intellitrace (Ultimate SKU only)

1. Set target platform to x86
   - Project properties, Build tab

2. Interactive Mode
   - Press F5, Click Load, stop at breakpoint
   - Set level to collect call information
   - Go backward: Ctrl+Shft+F11
   - Go forward: F11

3. Locate location of saved files
   - Intellitrace settings, Advanced
   - Double-click to open file
     > Try different iTrace files to select the right one

4. Double-click a Live Event
   - Explore various items in the summer
     > Double-clicking a thread shows trace log
   - Can step forward and backwards through the code

5. Copy off files to a new location
   - Otherwise files will be deleted when closing Visual Studio
   - Can open the files in new VS session

