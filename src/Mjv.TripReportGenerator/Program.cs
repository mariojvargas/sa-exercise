using System;
using System.Linq;

namespace Mjv.TripReportGenerator
{
    class Program
    {
        const string DefaultPathBecauseIAmLazy = @"example-trip.txt";

        static void Main(string[] args)
        {
            var drivers = new DriverRepository();

            var tripFilePath = PromptForTripFilePath();
            Console.WriteLine($"You entered: {tripFilePath}");
            Console.WriteLine();

            var tokenizer = new TripFileTokenizer();
            var commandTokens = tokenizer.TokenizeTripFile(tripFilePath);
            foreach (var token in commandTokens)
            {
                var driverName = token.Arguments[0];

                switch (token.CommandName.ToUpperInvariant())
                {
                    case "DRIVER":
                        drivers.Add(driverName);
                        break;

                    case "TRIP":
                        var tripFactory = new TripFactory();
                        var trip = tripFactory.CreateTripFromCommandToken(token);
                        drivers.AddTrip(driverName, trip);
                        break;
                }
            }

            // foreach (var driver in drivers.Values)
            // {
            //     foreach (var trip in driver.Trips)
            //     {
            //         var tripReport = new TripReport(trip);
            //         Console.WriteLine($"{driver.Name}: d: {trip.Distance} | t:{tripReport.Time} | {tripReport.Time.TotalSeconds} | v:{tripReport.SpeedPerHour}");
            //     }
            // }

            var reports = drivers.GetAll()
                .Select(driver => new DriverReport(driver))
                .OrderByDescending(report => report.TotalDistance)
                .ToList();

            reports.ForEach(Console.WriteLine);
        }


        private static string PromptForTripFilePath()
        {
            Console.WriteLine("Enter path to trip file:");
            var tripFilePath = Console.ReadLine();
            if (String.IsNullOrWhiteSpace(tripFilePath))
            {
                tripFilePath = DefaultPathBecauseIAmLazy;
            }

            return tripFilePath;
        }
    }
}
