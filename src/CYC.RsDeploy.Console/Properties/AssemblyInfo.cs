using System.Reflection;
using System.Runtime.InteropServices;
using CommandLine;

// General Information about an assembly is controlled through the following 
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.

[assembly: AssemblyTitle("rsdeploy.exe")]
[assembly: AssemblyDescription("SQL Server Reporting Services report deployment tool.")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("")]
[assembly: AssemblyProduct("rsdeploy.exe")]
[assembly: AssemblyCopyright("Copyright © City of York Council 2016")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

// Setting ComVisible to false makes the types in this assembly not visible 
// to COM components.  If you need to access a type in this assembly from 
// COM, set the ComVisible attribute to true on that type.
[assembly: ComVisible(false)]

// The following GUID is for the ID of the typelib if this project is exposed to COM
[assembly: Guid("7970bdd2-1b77-4e3e-a47d-76fedd1e657d")]

// Version information for an assembly consists of the following four values:
//
//      Major Version
//      Minor Version 
//      Build Number
//      Revision
//
// You can specify all the values or you can default the Build and Revision Numbers 
// by using the '*' as shown below:
// [assembly: AssemblyVersion("1.0.*")]
[assembly: AssemblyVersion("1.1.0.0")]
[assembly: AssemblyFileVersion("1.1.0.0")]
[assembly: AssemblyInformationalVersion("1.1.0")]

[assembly: AssemblyUsage(
    @"Usage: rsdeploy upload-file -f 'C:\folder.sub-folder.report.rdl' -d '/test' -s server",
    @"       rsdeploy upload-folder -f 'C:\folder' -d '/test' -s server",
    @"       rsdeploy create-datasources -f 'con-str.config' -d '/test' -s server")]
