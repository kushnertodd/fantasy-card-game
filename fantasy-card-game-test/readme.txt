Visual Studio Community 2022
solution explorer:
expand project (TestProject1)
expand dependencies
expand Packages
remove all Packages
right-click on Packages, select Nuget Package Manager
select Package source: Microsoft Visual Studio Offlne Packages
search for coverlet
add coverlet.collector (3.0.3)
search for mstest
install MSTest.TestFramework (2.2.7)
install MSTest.TestAdapter (2.2.7)
search for net.test
install Microsoft.NET.Test.Sdk (16.11.0)

error:
Nuget connection attempt failed "Unable to load the service index for source"
solution:
https://stackoverflow.com/questions/41185443/nuget-connection-attempt-failed-unable-to-load-the-service-index-for-source
Delete %AppData%\Roaming\NuGet\NuGet.Config and restart VS2022

error:
How To Resolve Issue Of Test Project Not Running The Unit Tests After Upgrade To .NET 6
solution:
https://www.c-sharpcorner.com/article/how-to-resolve-issue-of-test-project-not-running-the-unit-tests-after-upgrade-to/
 there was no Microsoft.NET.Test.Sdk in the .csproj file. (fixed above)
 
 