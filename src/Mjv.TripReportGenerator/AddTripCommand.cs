namespace Mjv.TripReportGenerator
{
    public class AddTripCommand : ICommand
    {
        private IDriverRepository _driverRepository;

        public AddTripCommand(IDriverRepository driverRepository)
        {
            _driverRepository = driverRepository;
        }

        public void Execute(CommandToken token)
        {
            var driverName = token.Arguments[0];
            var tripFactory = new TripFactory();
            var trip = tripFactory.CreateTripFromCommandToken(token);
            _driverRepository.AddTrip(driverName, trip);
        }
    }
}
