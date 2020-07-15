using System.Collections.Generic;

namespace Mjv.TripReportGenerator
{
    public class Driver
    {
        public Driver()
        {
            Trips = new List<Trip>();
        }

        public string Name { get; set; }
        public IList<Trip> Trips { get; }
    }
}