The exercise files have been updated to include project definitions for .NET 5, 6, and 7.

All of the contents of each folder are identical. Choose the folder that corresponds to the
version of .NET that you have installed.

You can run 'dotnet --version' to see what version you have.

If you need to install .NET, visit https://dotnet.microsoft.com/download

In the future, you can update these examples yourself by editing the .csproj file in the root directory for each example. You just need to change the .NET version specified in the XML:

---------

<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <OutputType>Exe</OutputType>
    <TargetFramework>net7.0</TargetFramework> <!-- CHANGE THIS VALUE TO "netX.X" for your SDK -->
  </PropertyGroup>

</Project>

---------

Happy coding!
