SurePark SDK for .NET
================

The SurePark SDK for .NET allows you to build .NET applications for the Microsoft platform (including ASP.NET, Windows, and Windows Phone) that leverage SurePark.

## Download & Install

### Via Git

To get the source code of the SurePark SDK for .NET via git just type:

```bash
git clone https://github.com/agrocholski/surepark-sdk-for-net
cd surepark-sdk-for-net
```

### Via NuGet

To get the binaries associated with this project you can also have them installed by the .NET package manager [NuGet](http://www.nuget.org)

#### SurePark core binaries
```bash
PM> Install-Package SurePark.Core
```
## Dependencies

The current version of the SurePark SDK for .NET has the following dependencies:

- [Microsoft BCL Build Components](https://www.nuget.org/packages/Microsoft.Bcl.Build)
- [Microsoft BCL Portability Pack](https://www.nuget.org/packages/Microsoft.Bcl)
- [Microsoft HTTP Client Libraries](https://www.nuget.org/packages/Microsoft.Net.Http/)

These dependencies can be downloaded directly or referenced by your project through NuGet.

## Code Samples

### Getting parking information for an airport

First, include the classes you need.

```csharp
using SurePark.Core;
```

Next, instantiate an instance of the SureParkClient class using the URL to the specific airports parking data. The below example uses parking data from the Minneapolis-St. Paul International airport.

```csharp
var client = new SureParkClient("http://www.mspairport.com/data/sureparknow/surepark.aspx")
```

Then call the GetAirportParkingInfoAsync method.

```csharp
var parkingInfo = await client.GetAirportParkingInfoAsync();
```

### Getting parking information for a specific terminal

```csharp
using SurePark.Core;
```

Next, instantiate an instance of the SureParkClient class using the URL to the specific airports parking data. The below example uses parking data from the Minneapolis-St. Paul International airport.

```csharp
var client = new SureParkClient("http://www.mspairport.com/data/sureparknow/surepark.aspx")
```

Then call the GetTerminalParkingInfoAsync method using the name of the terminal. The below example returns parking data for Terminal 1 at the Minneapolis-St. Paul International airport.

```csharp
var parkingInfo = await client.GetTerminalParkingInfoAsync("Terminal 1");
```

### Getting parking information for a specific lot

```csharp
using SurePark.Core;
```

Next, instantiate an instance of the SureParkClient class using the URL to the specific airports parking data. The below example uses parking data from the Minneapolis-St. Paul International airport.

```csharp
var client = new SureParkClient("http://www.mspairport.com/data/sureparknow/surepark.aspx")
```

Then call the GetTerminalLotParkingInfoAsync method using the name of the terminal and the name of the lot. The below example returns parking data for the General parking lot at Terminal 1 at the Minneapolis-St. Paul International airport.

```csharp
var parkingInfo = await client.GetTerminalParkingInfoAsync("Terminal 1", "Total General (T1)");
```