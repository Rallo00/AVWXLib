using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static string ICAO_STATION, TOKEN = "MWlQgmuag-2MaxWtKGxCmdFnjoNBvmaadnYUOl86nq4";
        static void Main(string[] args)
        {
            //////////// TEST PROMPT ////////////
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Enter a ICAO station: ");
            Console.ForegroundColor = ConsoleColor.White;
            ICAO_STATION = Console.ReadLine();
            GetInformation(ICAO_STATION);

            Console.ReadKey();
        }
        static async void GetInformation(string ICAO_STATION)
        {
            //Getting airport information
            AVWXLib.Airport airport = await AVWXLib.GetStationInfoAsync(ICAO_STATION, TOKEN);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(">> AIRPORT RESULT");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"Airport: {airport.Name}");
            Console.WriteLine($"City: {airport.City}");
            Console.WriteLine($"Country: {airport.Country}");
            Console.WriteLine($"IATA: {airport.IATACode}");
            Console.WriteLine($"Elevation: {airport.Elevation}");
            Console.WriteLine($"Latitude: {airport.Latitude}");
            Console.WriteLine($"Longitude: {airport.Longitude}");
            Console.WriteLine($"Note: {airport.Note}");
            Console.WriteLine($"Website: {airport.Website}");

            //Showing runway information
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(">> RUNWAY");
            Console.ForegroundColor = ConsoleColor.White;
            foreach (AVWXLib.Runway r in airport.Runways)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Runway: {r.Identification1}/{r.Identification2}");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"Real bearing: {r.Bearing1}/{r.Bearing2}");
                Console.WriteLine($"Surface: {r.Surface}");
                Console.WriteLine($"Length: {r.Length} ft");
            }

            //Getting METAR information
            string METAR = await AVWXLib.GetMetarAsync(ICAO_STATION, TOKEN);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(">> METAR RESULT");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(METAR);

            //Getting TAF information
            string TAF = await AVWXLib.GetTafAsync(ICAO_STATION, TOKEN);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(">> TAF RESULT");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(TAF);

            //Getting AIRAC
            string AIRAC = await AVWXLib.GetCurrentAiracCycleAsync();
            string AIRAC_exp_date = await AVWXLib.GetCurrentAiracExpiryDateAsync();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(">> AIRAC RESULT");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(AIRAC + "\t" + AIRAC_exp_date);
        }
    }
}
