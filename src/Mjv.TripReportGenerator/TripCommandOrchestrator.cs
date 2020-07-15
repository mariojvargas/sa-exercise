using System;
using System.Collections.Generic;

namespace Mjv.TripReportGenerator
{
    public class TripCommandOrchestrator
    {
        private IDictionary<string, ICommand> _commands;
        private IDriverRepository _driverRepository;

        public TripCommandOrchestrator(IDriverRepository driverRepository)
        {
            _driverRepository = driverRepository;
            _commands = BuildCommands();
        }

        public void Execute(IReadOnlyCollection<CommandToken> commandTokens)
        {
            foreach (var token in commandTokens)
            {
                if (_commands.ContainsKey(token.CommandName))
                {
                    _commands[token.CommandName].Execute(token);
                }
            }
        }

        private IDictionary<string, ICommand> BuildCommands()
        {
            return new Dictionary<string, ICommand>(StringComparer.InvariantCultureIgnoreCase)
            {
                [CommandName.Driver] = new AddDriverCommand(_driverRepository),
                [CommandName.Trip] = new AddTripCommand(_driverRepository)
            };
        }
    }
}
