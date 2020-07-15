using System;
using System.Collections.Generic;

namespace Mjv.TripReportGenerator
{
    public interface IDriverRepository
    {
        void Add(string name);
        void AddTrip(string driverName, Trip trip);
    }

    public class DriverRepository : IDriverRepository
    {
        private static IDictionary<string, Driver> Drivers = new Dictionary<string, Driver>(StringComparer.InvariantCultureIgnoreCase);

        public void Add(string name)
        {
            Drivers.Add(name, new Driver()
            {
                Name = name
            });
        }

        public void AddTrip(string driverName, Trip trip)
        {
            Drivers[driverName].Trips.Add(trip);
        }

        internal IEnumerable<Driver> GetAll() => Drivers.Values;
    }
}
