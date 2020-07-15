namespace Mjv.TripReportGenerator
{
    public class AddDriverCommand : ICommand
    {
        private IDriverRepository _driverRepository;

        public AddDriverCommand(IDriverRepository driverRepository)
        {
            _driverRepository = driverRepository;
        }

        public void Execute(CommandToken token)
        {
            var driverName = token.Arguments[0];
            _driverRepository.Add(driverName);
        }
    }
}
