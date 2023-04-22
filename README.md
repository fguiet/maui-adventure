# My .NET MAUI Adventures

## Forewords

In this repo, you will find some tests I have made regarding .NET MAUI stuff

## Test 1 - Using Visual Studio 2022, Android Virtual Machine and Bluetooth

See documentation [here](using-android-vm.md)

See C# project sample in `samples\ble-helloworld` folder

Some technical info:

* Update csproj to remove MacOS and Windows support

Remove `net7.0-maccatalyst` and `net7.0-windows10.0.19041.0`

```xml
<TargetFrameworks>net7.0-android;net7.0-ios</TargetFrameworks>
		<!-- <TargetFrameworks>net7.0-android;net7.0-ios;net7.0-maccatalyst</TargetFrameworks> -->
		<!-- <TargetFrameworks Condition="$([MSBuild]::IsOSPlatform('windows'))">$(TargetFrameworks);net7.0-windows10.0.19041.0</TargetFrameworks> -->
```

* This project uses Shiny Library

Shiny is a cross platform framework designed to make working with device services and background processes easy, testable, and consistent while bringing things like dependency injection & logging in a structured way to your code!

GitHub project <https://github.com/shinyorg/shiny>

Using last beta version library, go to : <https://shinylib.net/appbuilder/>

Add this to your csproj file

```xml
<ItemGroup>
	<PackageReference Include="Shiny.BluetoothLE" version="3.0.0-alpha-0560" />
	<PackageReference Include="Shiny.BluetoothLE.Hosting" version="3.0.0-alpha-0560" />
	<PackageReference Include="Shiny.Hosting.Maui" version="3.0.0-alpha-0560" />
</ItemGroup>
```