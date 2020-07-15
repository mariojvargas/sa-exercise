using System;

namespace Mjv.TripReportGenerator
{
    public class TripReport
    {
        private Trip _trip;

        public TripReport(Trip trip)
        {
            _trip = trip;
        }

        public TimeSpan Time => _trip.EndTime - _trip.StartTime;
        public double SpeedPerHour => _trip.Distance / Time.TotalHours;
    }
}