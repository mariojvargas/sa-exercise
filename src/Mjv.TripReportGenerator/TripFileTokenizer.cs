using System;
using System.Collections.Generic;
using System.IO;

namespace Mjv.TripReportGenerator
{
    public class TripFileTokenizer
    {
        public IReadOnlyCollection<CommandToken> TokenizeTripFile(string tripFilePath)
        {
            var entries = new List<CommandToken>();
            using (var sr = File.OpenText(tripFilePath))
            {
                for (var currentLine = sr.ReadLine(); currentLine != null; currentLine = sr.ReadLine())
                {
                    if (currentLine.Length > 0)
                    {
                        entries.Add(TokenizeLine(currentLine));
                    }

                }
            }

            return entries;
        }

        public CommandToken TokenizeLine(string currentLine)
        {
            const char tokenSeparator = ' ';
            const int initialSplitCount = 2;

            var tokens = currentLine?.Split(tokenSeparator, initialSplitCount, StringSplitOptions.RemoveEmptyEntries);
            if (tokens.Length == 0)
            {
                return null;
            }

            return new CommandToken
            {
                CommandName = tokens[0],
                Arguments = tokens[1].Split(tokenSeparator, StringSplitOptions.RemoveEmptyEntries)
            };
        }
    }
}