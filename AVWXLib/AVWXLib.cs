using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
public static class AVWXLib
{
    /// <summary>
    /// Obtain information on desidered station
    /// </summary>
    /// <param name="Station">Desired aeronautical station</param>
    /// <param name="API_TOKEN">AVWX personal Token</param>
    /// <returns>String containing raw JSON</returns>
    public async static Task<string> GetStationInfoJsonAsync(string Station, string API_TOKEN)
    {
        string url = "http://avwx.rest/api/station/" + Station.ToUpper() + "?format=json&token=" + API_TOKEN;
        return await Http_GetRequest(url);
    }
    /// <summary>
    /// Obtain information on desidered station
    /// </summary>
    /// <param name="Station">Desired aeronautical station</param>
    /// <param name="API_TOKEN">AVWX personal Token</param>
    /// <returns>String containing raw XML</returns>
    public async static Task<string> GetStationInfoXmlAsync(string Station, string API_TOKEN)
    {
        string url = "http://avwx.rest/api/station/" + Station.ToUpper() + "?format=xml&token=" + API_TOKEN;
        return await Http_GetRequest(url);
    }
    /// <summary>
    /// Obtain information on desidered station
    /// </summary>
    /// <param name="Station">Desired aeronautical station</param>
    /// <param name="API_TOKEN">AVWX personal Token</param>
    /// <returns>Airport object containing station informations</returns>
    public async static Task<Airport> GetStationInfoAsync(string Station, string API_TOKEN)
    {
        string url = "http://avwx.rest/api/station/" + Station.ToUpper() + "?format=json&token=" + API_TOKEN;
        string response = await Http_GetRequest(url);
        Airport airport = Newtonsoft.Json.JsonConvert.DeserializeObject<Airport>(response);
        return airport;
    }
    /// <summary>
    /// Obtain METAR of desidered station
    /// </summary>
    /// <param name="Station">Desired aeronautical station</param>
    /// <param name="API_TOKEN">AVWX personal Token</param>
    /// <returns>String containing raw JSON</returns>
    public async static Task<string> GetMetarJsonAsync(string Station, string API_TOKEN)
    {
        string url = "http://avwx.rest/api/metar/" + Station.ToUpper() + "?options=&airport=true&reporting=true&format=json&onfail=error&token=" + API_TOKEN;
        return await Http_GetRequest(url);
    }
    /// <summary>
    /// Obtain METAR of desidered station
    /// </summary>
    /// <param name="Station">Desired aeronautical station</param>
    /// <param name="API_TOKEN">AVWX personal Token</param>
    /// <returns>String containing raw XML</returns>
    public async static Task<string> GetMetarXmlAsync(string Station, string API_TOKEN)
    {
        string url = "http://avwx.rest/api/metar/" + Station.ToUpper() + "?options=&airport=true&reporting=true&format=xml&onfail=error&token=" + API_TOKEN;
        return await Http_GetRequest(url);
    }
    /// <summary>
    /// Obtain METAR of desidered station
    /// </summary>
    /// <param name="Station">Desired aeronautical station</param>
    /// <param name="API_TOKEN">AVWX personal Token</param>
    /// <returns>String containing only METAR</returns>
    public async static Task<string> GetMetarAsync(string Station, string API_TOKEN)
    {
        string url = "http://avwx.rest/api/metar/" + Station.ToUpper() + "?options=&airport=true&reporting=true&format=json&onfail=error&token=" + API_TOKEN;
        string response = await Http_GetRequest(url);
        MetarTAF metarTaf = Newtonsoft.Json.JsonConvert.DeserializeObject<MetarTAF>(response);
        return metarTaf.Raw;
    }
    /// <summary>
    /// Obtain TAF of desidered station
    /// </summary>
    /// <param name="Station">Desired aeronautical station</param>
    /// <param name="API_TOKEN">AVWX personal Token</param>
    /// <returns>String containing raw JSON</returns>
    public async static Task<string> GetTafJsonAsync(string Station, string API_TOKEN)
    {
        string url = "http://avwx.rest/api/taf/" + Station.ToUpper() + "?options=summary&airport=true&reporting=true&format=json&onfail=error&token=" + API_TOKEN;
        return await Http_GetRequest(url);
    }
    /// <summary>
    /// Obtain TAF of desidered station
    /// </summary>
    /// <param name="Station">Desired aeronautical station</param>
    /// <param name="API_TOKEN">AVWX personal Token</param>
    /// <returns>String containing raw XML</returns>
    public async static Task<string> GetTafXmlAsync(string Station, string API_TOKEN)
    {
        string url = "http://avwx.rest/api/taf/" + Station.ToUpper() + "?options=summary&airport=true&reporting=true&format=xml&onfail=error&token=" + API_TOKEN;
        return await Http_GetRequest(url);
    }
    /// <summary>
    /// Obtain TAF of desidered station
    /// </summary>
    /// <param name="Station">Desired aeronautical station</param>
    /// <param name="API_TOKEN">AVWX personal Token</param>
    /// <returns>String containing only TAF</returns>
    public async static Task<string> GetTafAsync(string Station, string API_TOKEN)
    {
        string url = "http://avwx.rest/api/taf/" + Station.ToUpper() + "?options=&airport=true&reporting=true&format=json&onfail=error&token=" + API_TOKEN;
        string response = await Http_GetRequest(url);
        MetarTAF metarTaf = Newtonsoft.Json.JsonConvert.DeserializeObject<MetarTAF>(response);
        return metarTaf.Raw;
    }
    /// <summary>
    /// Obtain the current AIRAC Cycle number
    /// </summary>
    /// <returns>String that contains AIRAC Cycle number</returns>
    public async static Task<string> GetCurrentAiracCycleAsync()
    {
        string url = "http://eliafrate.altervista.org/ms/airac/cycle.php";
        string response = await Http_GetRequest(url);
        AIRAC airac = Newtonsoft.Json.JsonConvert.DeserializeObject<AIRAC>(response);
        return airac.Cycle;
    }
    /// <summary>
    /// Obtain the current AIRAC Cycle expiry date
    /// </summary>
    /// <returns>String that contains AIRAC Cycle expiry date</returns>
    public async static Task<string> GetCurrentAiracExpiryDateAsync()
    {
        string url = "http://eliafrate.altervista.org/ms/airac/cycle.php";
        string response = await Http_GetRequest(url);
        AIRAC airac = Newtonsoft.Json.JsonConvert.DeserializeObject<AIRAC>(response);
        string airac_exp_date = airac.ExpiryDate;
        return airac_exp_date.Split('T')[0];
    }
    /// <summary>
    /// Get nearest station around a desidered ICAO station
    /// </summary>
    /// <param name="Station">Desidered ICAO station as Bullseye</param>
    /// <param name="numberOfStations">Number of nearest stations to find</param>
    /// <param name="onlyAirports">If true it will show up only airports</param>
    /// <param name="API_TOKEN">AVWX personal token</param>
    /// <returns>Returns a List of Airport object containing the desidered nearby airports</returns>
    public async static Task<List<Airport>> GetNearestStationFromStationAsync(string Station, int numberOfStations, bool onlyAirports, string API_TOKEN)
    {
        List<Airport> nearestStations = new List<Airport>();
        //Getting current Station coordinates
        string url = "http://avwx.rest/api/station/" + Station.ToUpper() + "?format=json&token=" + API_TOKEN;
        string response = await Http_GetRequest(url);
        Airport airport = Newtonsoft.Json.JsonConvert.DeserializeObject<Airport>(response);
        double latitude = double.Parse(airport.Latitude), longitude = double.Parse(airport.Longitude);
        //Getting nearest stations
        url = "https://avwx.rest/api/station/near/" + latitude + "," + longitude + "?n=" + numberOfStations + "&airport=" + onlyAirports.ToString() + "&reporting=true&format=json&token=" + API_TOKEN;
        response = await Http_GetRequest(url);
        nearestStations.Add(Newtonsoft.Json.JsonConvert.DeserializeObject<Airport>(response));
        return nearestStations;
    }
    /// <summary>
    /// Get nearest station given latitude and longitude
    /// </summary>
    /// <param name="latitude">Current latitude</param>
    /// <param name="longitude">Current longitude</param>
    /// <param name="numberOfStations">Number of nearest stations to find</param>
    /// <param name="onlyAirports">If true it will show up only airports</param>
    /// <param name="API_TOKEN">AVWX personal token</param>
    /// <returns>Returns a List of Airport object containing the desidered nearby airports</returns>
    public async static Task<List<Airport>> GetNearestStationFromPositionAsync(double latitude, double longitude, int numberOfStations, bool onlyAirports, string API_TOKEN)
    {
        List<Airport> nearestStations = new List<Airport>();
        string url = "https://avwx.rest/api/station/near/" + latitude + "," + longitude + "?n=" + numberOfStations + "&airport=" + onlyAirports.ToString() + "&reporting=true&format=json&token=" + API_TOKEN;
        string response = await Http_GetRequest(url);
        nearestStations.Add(Newtonsoft.Json.JsonConvert.DeserializeObject<Airport>(response));
        return nearestStations;
    }

    /// <summary>
    /// Obtain information on desidered station
    /// </summary>
    /// <param name="Station">Desired aeronautical station</param>
    /// <param name="API_TOKEN">AVWX personal Token</param>
    /// <returns>String containing raw JSON</returns>
    public static string GetStationInfoJson(string Station, string API_TOKEN) { return GetStationInfoJsonAsync(Station, API_TOKEN).Result; }
    /// <summary>
    /// Obtain information on desidered station
    /// </summary>
    /// <param name="Station">Desired aeronautical station</param>
    /// <param name="API_TOKEN">AVWX personal Token</param>
    /// <returns>String containing raw XML</returns>
    public static string GetStationInfoXml(string Station, string API_TOKEN) { return GetStationInfoXmlAsync(Station, API_TOKEN).Result; }
    /// <summary>
    /// Obtain information on desidered station
    /// </summary>
    /// <param name="Station">Desired aeronautical station</param>
    /// <param name="API_TOKEN">AVWX personal Token</param>
    /// <returns>Airport object containing station informations</returns>
    public static Airport GetStationInfo(string Station, string API_TOKEN) { return GetStationInfoAsync(Station, API_TOKEN).Result; }
    /// <summary>
    /// Obtain METAR of desidered station
    /// </summary>
    /// <param name="Station">Desired aeronautical station</param>
    /// <param name="API_TOKEN">AVWX personal Token</param>
    /// <returns>String containing raw JSON</returns>
    public static string GetMetarJson(string Station, string API_TOKEN) { return GetMetarJsonAsync(Station, API_TOKEN).Result; }
    /// <summary>
    /// Obtain METAR of desidered station
    /// </summary>
    /// <param name="Station">Desired aeronautical station</param>
    /// <param name="API_TOKEN">AVWX personal Token</param>
    /// <returns>String containing raw XML</returns>
    public static string GetMetarXml(string Station, string API_TOKEN) { return GetMetarXmlAsync(Station, API_TOKEN).Result; }
    /// <summary>
    /// Obtain METAR of desidered station
    /// </summary>
    /// <param name="Station">Desired aeronautical station</param>
    /// <param name="API_TOKEN">AVWX personal Token</param>
    /// <returns>String containing only METAR</returns>
    public static string GetMetar(string Station, string API_TOKEN) { return GetMetarAsync(Station, API_TOKEN).Result; }
    /// <summary>
    /// Obtain TAF of desidered station
    /// </summary>
    /// <param name="Station">Desired aeronautical station</param>
    /// <param name="API_TOKEN">AVWX personal Token</param>
    /// <returns>String containing raw JSON</returns>
    public static string GetTafJson(string Station, string API_TOKEN) { return GetTafJsonAsync(Station, API_TOKEN).Result; }
    /// <summary>
    /// Obtain TAF of desidered station
    /// </summary>
    /// <param name="Station">Desired aeronautical station</param>
    /// <param name="API_TOKEN">AVWX personal Token</param>
    /// <returns>String containing raw XML</returns>
    public static string GetTafXml(string Station, string API_TOKEN) { return GetTafXmlAsync(Station, API_TOKEN).Result; }
    /// <summary>
    /// Obtain TAF of desidered station
    /// </summary>
    /// <param name="Station">Desired aeronautical station</param>
    /// <param name="API_TOKEN">AVWX personal Token</param>
    /// <returns>String containing only TAF</returns>
    public static string GetTaf(string Station, string API_TOKEN) { return GetTafAsync(Station, API_TOKEN).Result; }
    /// <summary>
    /// Obtain the current AIRAC Cycle number
    /// </summary>
    /// <returns>String that contains AIRAC Cycle number</returns>
    public static string GetCurrentAiracCycle() { return GetCurrentAiracCycleAsync().Result; }
    /// <summary>
    /// Obtain the current AIRAC Cycle expiry date
    /// </summary>
    /// <returns>String that contains AIRAC Cycle expiry date</returns>
    public static string GetCurrentAiracExpiryDate() { return GetCurrentAiracExpiryDateAsync().Result; }
    /// <summary>
    /// Get nearest station around a desidered ICAO station
    /// </summary>
    /// <param name="Station">Desidered ICAO station as Bullseye</param>
    /// <param name="numberOfStations">Number of nearest stations to find</param>
    /// <param name="onlyAirports">If true it will show up only airports</param>
    /// <param name="API_TOKEN">AVWX personal token</param>
    /// <returns>Returns a List of Airport object containing the desidered nearby airports</returns>
    public static List<Airport> GetNearestStationFromStation(string Station, int numberOfStations, bool onlyAirports, string API_TOKEN) { return GetNearestStationFromStationAsync(Station, numberOfStations, onlyAirports, API_TOKEN).Result; }
    /// <summary>
    /// Get nearest station given latitude and longitude
    /// </summary>
    /// <param name="latitude">Current latitude</param>
    /// <param name="longitude">Current longitude</param>
    /// <param name="numberOfStations">Number of nearest stations to find</param>
    /// <param name="onlyAirports">If true it will show up only airports</param>
    /// <param name="API_TOKEN">AVWX personal token</param>
    /// <returns>Returns a List of Airport object containing the desidered nearby airports</returns>
    public static List<Airport> GetNearestStationFromPosition(double latitude, double longitude, int numberOfStations, bool onlyAirports, string API_TOKEN) { return GetNearestStationFromPositionAsync(latitude, longitude, numberOfStations, onlyAirports, API_TOKEN ).Result; }


    /// <summary>
    /// Send general HTTP GET request
    /// </summary>
    /// <param name="URI"></param>
    /// <returns></returns>
    private static async Task<string> Http_GetRequest(string URI)
    {
        System.Net.HttpWebRequest request = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(URI);
        using (System.Net.HttpWebResponse response = (System.Net.HttpWebResponse)await request.GetResponseAsync())
        using (System.IO.Stream stream = response.GetResponseStream())
        using (System.IO.StreamReader reader = new System.IO.StreamReader(stream))
            return await reader.ReadToEndAsync();
    }
    public class Airport
    {
        [Newtonsoft.Json.JsonProperty("city")]
        public string City { get; set; }
        [Newtonsoft.Json.JsonProperty("country")]
        public string Country { get; set; }
        [Newtonsoft.Json.JsonProperty("elevation_ft")]
        public string Elevation { get; set; }
        [Newtonsoft.Json.JsonProperty("iata")]
        public string IATACode { get; set; }
        [Newtonsoft.Json.JsonProperty("icao")]
        public string ICAOCode { get; set; }
        [Newtonsoft.Json.JsonProperty("latitude")]
        public string Latitude { get; set; }
        [Newtonsoft.Json.JsonProperty("longitude")]
        public string Longitude { get; set; }
        [Newtonsoft.Json.JsonProperty("name")]
        public string Name { get; set; }
        [Newtonsoft.Json.JsonProperty("note")]
        public string Note { get; set; }
        public List<Runway> Runways { get; set; }
        [Newtonsoft.Json.JsonProperty("website")]
        public string Website { get; set; }
        public Airport() { }
        public Airport(string city, string country, string elevation, string iata, string icao, string latitude, string longitude, string name, string note, string website, List<Runway> runways)
        {
            this.City = city;
            this.Country = country;
            this.Elevation = elevation;
            this.IATACode = iata;
            this.ICAOCode = icao;
            this.Latitude = latitude;
            this.Longitude = longitude;
            this.Name = name;
            this.Note = note;
            this.Website = website;
            Runways = new List<Runway>();
            this.Runways = runways;
        }
    }
    public class Runway
    {
        [Newtonsoft.Json.JsonProperty("ident1")]
        public string Identification1 { get; set; }
        [Newtonsoft.Json.JsonProperty("ident2")]
        public string Identification2 { get; set; }
        [Newtonsoft.Json.JsonProperty("bearing1")]
        public string Bearing1 { get; set; }
        [Newtonsoft.Json.JsonProperty("bearing2")]
        public string Bearing2 { get; set; }
        [Newtonsoft.Json.JsonProperty("length_ft")]
        public string Length { get; set; }
        [Newtonsoft.Json.JsonProperty("surface")]
        public string Surface { get; set; }
        public Runway(string id1, string id2, string b1, string b2, string length, string surface)
        {
            this.Identification1 = id1;
            this.Identification2 = id2;
            this.Bearing1 = b1;
            this.Bearing2 = b2;
            this.Length = length;
            this.Surface = surface;
        }
        public Runway() { }
    }
    private class MetarTAF
    {
        [Newtonsoft.Json.JsonProperty("raw")]
        public string Raw { get; set; }
    }
    private class AIRAC
    {
        [Newtonsoft.Json.JsonProperty("currentAiracCycle")]
        public string Cycle { get; set; }
        [Newtonsoft.Json.JsonProperty("nextAiracDate")]
        public string ExpiryDate { get; set; }
        public AIRAC() { }
        public AIRAC(string cyc, string date) { Cycle = cyc; ExpiryDate = date; }
    }
}