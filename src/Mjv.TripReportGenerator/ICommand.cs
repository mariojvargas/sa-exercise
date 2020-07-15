namespace Mjv.TripReportGenerator
{
    public interface ICommand
    {
        void Execute(CommandToken token);
    }
}
