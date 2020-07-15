using System;
using System.Linq;
using System.Text;

namespace Mjv.TripReportGenerator
{
    public class DriverReport
    {
        private Driver _driver;

        public DriverReport(Driver driver)
        {
            _driver = driver;
        }

        public string Name => _driver.Name;

        public double TotalDistance => _driver.Trips.Count == 0
            ? 0
            : _driver.Trips.Sum(x => x.Distance);

        public double AverageSpeedPerHour => _driver.Trips.Count == 0
            ? 0
            : _driver.Trips
                .Select(x => new TripReport(x))
                .Average(x => x.SpeedPerHour);


        override public string ToString()
        {
            var sb = new StringBuilder($"{Name}: {TotalDistance:N0} miles");

            if (TotalDistance > 0)
            {
                sb.Append($" @ {AverageSpeedPerHour:N0} mph");
            }

            return sb.ToString();
        }
    }
}