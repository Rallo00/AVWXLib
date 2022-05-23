# AVWXLib
This C# Library allows users to get information on the desidered airport by using AVWX Service provided APIs.

---- REQUISITES ----

- Requires Newtonsoft.Json.dll to parse JSON information, get it from NuGet into Visual Studio.
- .Net Framework SDK v4.5.1

---- HOW TO USE ----
- Add the provided DLL file as Reference into your C# project;
- Add `using OpenAVWXLib;` at the top of your Project code-behind file;
- Create a free API token here → https://account.avwx.rest/getting-started (need to register);
- This library provides also a Raw Json/Xml response from AVWX Services;
- It provides live METAR/TAF;

---- AVAILABLE METHODS TO CALL ----
```cs
public async static Task<Airport> GetStationInfo(string Station, string API_TOKEN) {}
public async static Task<string> GetMetar(string Station, string API_TOKEN) {}
public async static Task<string> GetTaf(string Station, string API_TOKEN) {}
public async static Task<string> GetCurrentAiracCycle() {}
public async static Task<string> GetCurrentAiracExpiryDate() {}
public async static Task<List<Airport>> GetNearestStationFromStation(string Station, int numberOfStations, bool onlyAirports, string API_TOKEN) {}
public async static Task<List<Airport>> GetNearestStationFromPosition(double latitude, double longitude, int numberOfStations, bool onlyAirports, string API_TOKEN) {}
```

To avoid thread blocking I recommend to use async methods.

---- PROVIDED INFORMATION ----
- Name of the airport;
- City of the airport;
- ICAO code;
- IATA code;
- Country;
- Elevation (in meters);
- Latitude (°N);
- Longitude (°E);
- Airport website;
- Runways (Runway number, True heading , Length of the runway, Width of the runway);
- METAR;
- TAF;
- Current AIRAC cycle number and expiry date;
