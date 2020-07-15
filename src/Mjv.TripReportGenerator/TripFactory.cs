using System;
using System.Globalization;

namespace Mjv.TripReportGenerator
{
    public class TripFactory
    {
        private const string EntryTimeFormat = "HH:mm";

        public Trip CreateTripFromCommandToken(CommandToken token)
        {
            var rawStartTime = token.Arguments[1];
            var rawEndTime = token.Arguments[2];
            var rawDistance = token.Arguments[3];

            return new Trip
            {
                StartTime = DateTime.ParseExact(rawStartTime, EntryTimeFormat, CultureInfo.InvariantCulture, DateTimeStyles.AssumeLocal),
                EndTime = DateTime.ParseExact(rawEndTime, EntryTimeFormat, CultureInfo.InvariantCulture, DateTimeStyles.AssumeLocal),
                Distance = Double.Parse(rawDistance)
            };
        }
    }
}