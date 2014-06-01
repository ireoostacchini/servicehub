
rem load VS objects

cd "C:\Program Files (x86)\Microsoft Visual Studio 11.0\VC\"
call vcvarsall.bat

rem go back to current directory

set mydir="%~p0"
cd %mydir%


rem build solution

rem C:\Windows\Microsoft.NET\Framework64\v4.0.30319\msbuild "Publish.msbuild"  /verbosity:quiet 

rem C:\Windows\Microsoft.NET\Framework64\v4.0.30319\msbuild "Transform.msbuild"  /verbosity:quiet 

rem C:\Windows\Microsoft.NET\Framework64\v4.0.30319\msbuild "Deploy.msbuild" /verbosity:quiet 

 C:\Windows\Microsoft.NET\Framework64\v4.0.30319\msbuild "UpdateDatabase.msbuild" 
rem /verbosity:quiet 
pause