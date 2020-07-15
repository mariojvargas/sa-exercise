using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Mjv.TripReportGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            var drivers = new DriverRepository();

            var tripFilePath = PromptForTripFilePath();
            Console.WriteLine($"You entered: {tripFilePath}");
            Console.WriteLine();

            if (!File.Exists(tripFilePath))
            {
                Console.WriteLine("The file does not exist");
                return;
            }

            var tokenizer = new TripFileTokenizer();
            var commandTokens = tokenizer.TokenizeTripFile(tripFilePath);

            var commandOrchestrator = new TripCommandOrchestrator(drivers);
            commandOrchestrator.Execute(commandTokens);

            DisplayReport(drivers.GetAll());
        }

        private static string PromptForTripFilePath()
        {
            Console.WriteLine("Enter path to trip file:");
            var tripFilePath = Console.ReadLine();

            return tripFilePath;
        }

        private static void DisplayReport(IEnumerable<Driver> drivers)
        {
            Console.WriteLine("REPORT:");
            Console.WriteLine("=======");

            var reports = drivers
                .Select(driver => new DriverReport(driver))
                .OrderByDescending(report => report.TotalDistance)
                .ToList();

            reports.ForEach(Console.WriteLine);

            Console.WriteLine();
        }
    }
}
