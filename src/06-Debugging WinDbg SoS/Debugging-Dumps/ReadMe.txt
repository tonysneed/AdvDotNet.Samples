WinDbg with SOS Debugging ReadMe

Note: Before solution is intentionally empty.

Part A: Generating Dumps with ADPLUS

Download Win7 or 8.1 SDK: https://msdn.microsoft.com/en-us/windows/hardware/hh852365.aspx
- SCroll down to: Standalone Debugging Tools for Windows (WinDbg), run sdksetup.exe
- While installing uncheck everything except Debugging Tools for Windows
- If it fails to install: https://support.microsoft.com/en-us/kb/2717426

NOTE: There is a new executable for adplus (adplus.exe), located in the folder
where Windbg is installed, for ex:
C:\Program Files (x86)\Windows Kits\8.1\Debuggers\x64
This replaces the ols vbs script file from days of old.

Instructions: http://blogs.msdn.com/b/webdav_101/archive/2012/01/27/taking-dumps-with-the-adplus-executable.aspx

1. Run CrashMe.exe
   - Don't press any keys just yet

2. Open cmd prompt as admin
   - Navigate to directory where adplus.exe is installed

3. Execute adplus
   - adplus -crash -o c:\temp -pn CrashMe.exe
   - Inspect the output dir in c:\temp
   - The second chance exception dump file is the one we want

Difference between 1st and 2nd chance exceptions: http://support.microsoft.com/kb/105675

4. Repeat this process with HangMe
   - adplus -hang -o c:\temp -pn HangMe.exe

5. Take repeated dumps with LeakMe
   - adplus -hang -o c:\temp -pn LeakMe.exe -r 3 30
     > Generates a dump file every 30 seconds, for 3 times

Part B: Using Debugging Tools for Windows (WinDbg)

1. Set symbol search paths
   - Open WinDbg
   - Select File, Symbol File Path (Ctrl + S)
   - Enter list of search paths delimitted by semi-colons:
     C:\Symbols\Dumps;
     SRV*C:\Symbols*http://msdl.microsoft.com/download/symbols
     > The first item is the local symbols cache from VS options
       - If needed copy pdb files to a folder in c:\symbols
     > The second item is the Microsoft symbol server, including local symbol cache dir

2. Open CrashMe dump file
   - File, Open Dump File (Ctrl + D)

3. Load SOS
   .loadby sos clr (.NET 4.0)
   .loadby sos mscorwks (.NET 3.5 and earlier)

4. Show exception info
   !PrintException -nested
   > This will show last exception on thread stack
   > Includes nested exceptions

5. Load SosEx
   - Download sosex from http://www.stevestechspot.com
   - Copy sosex.dll file from Tools folder to the Debugging Tools install dir
     > C:\Program Files (x86)\Windows Kits\8.1\Debuggers\x64
   .load sosex.dll

6. Show exeption type info (SosEx)
   !mdt CrashMe.MyCustomException

