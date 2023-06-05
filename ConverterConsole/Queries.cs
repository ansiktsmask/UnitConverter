using Converter.ConsoleUI_BFF.GetAvailableLengthUnits;
using Converter.ConsoleUI_BFF.LengthConverter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Converter.ConsoleUI
{
    public class Queries
    {
        public static string GetAvailableCommands() 
        {
            var stringBuilder = new StringBuilder();

            stringBuilder.AppendLine("help: displays a list of commands");
            stringBuilder.AppendLine("exit: exits the application");
            stringBuilder.AppendLine("units: displays a list of units to convert from/to");
            stringBuilder.AppendLine("[antal] in [frånEnhet] [tillEnhet]: the format to input conversion in");

            return stringBuilder.ToString();
        }

        public static string GetAvailableUnitsString() {
            var queryHandler = new GetAvailableLengthUnitsBFFQueryHandler();

            StringBuilder stringBuilder = new StringBuilder();
            var result = queryHandler.Execute();

            foreach (var item in result)
            {
                stringBuilder.AppendLine($"{item.Name} ({item.ShortName})");
            }
            return stringBuilder.ToString();
        }

        public List<GetAvailableLengthUnitsBFFResponse> GetAvailableUnits()
        {
            var queryHandler = new GetAvailableLengthUnitsBFFQueryHandler();
            return queryHandler.Execute();
        }

        public LengthConverterBFFResponse DoConversion(List<string> conversionProperties)
        {
            return new LengthConverterBFFResponse();
        }
    }
}
