using System.Linq.Expressions;

namespace Converter.Application.Queries.Length.LengthConverter
{
    public class LengthConverterQueryHandler
    {
        public static LengthConverterResponse Execute(LengthConverterQuery lengthQuery)
        {
            decimal result = -1;

            switch (lengthQuery.FromUnit.ToLower())
            {
                case "thou":
                    result = lengthQuery.Value / 1000;
                    break;
                case "inch":
                    result = lengthQuery.Value;
                    break;
                case "foot":
                    result = lengthQuery.Value * 12;
                    break;
                case "yard":
                    result = lengthQuery.Value * 36;
                    break;
                case "furlong":
                    result = lengthQuery.Value * 7920;
                    break;
            }

            switch (lengthQuery.ToUnit.ToLower())
            {
                case "thou":
                    result *= 1000;
                    break;
                case "inch":
                    break;
                case "foot":
                    result /= 12;
                    break;
                case "yard":
                    result /= 36;
                    break;
                case "furlong":
                    result /= 7920;
                    break;
                default:
                    result = -1; // Invalid unit
                    break;
            }

            return new LengthConverterResponse
            {
                Result = result
            };
        }
    }
}