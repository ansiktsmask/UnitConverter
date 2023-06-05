using Converter.Application.Queries.Length.GetAvaiableLengthUnits;
using Converter.Application.Queries.Length.LengthConverter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Converter.ConsoleUI_BFF.Mapper
{
    public class LengthConverterQueryValidatorMapper
    {
        public static List<string> Validate(string unitFrom, string unitTo, string valueToConvert, List<GetAvaiableLengthUnitsResponse> availableUnits)
        {
            var errorList = new List<string>();
            var availableUnitNames = availableUnits.Select(x => x.Name.ToLower()).ToList();
            var availableUnitShortNames = availableUnits.Select(x => x.ShortName.ToLower()).ToList();

            decimal result = 0;
            if(!decimal.TryParse(valueToConvert, out result))
            {
                errorList.Add($"Could not convert {valueToConvert} to decimal.");
            }
            if(!availableUnitNames.Contains(unitFrom.ToLower()) && !availableUnitShortNames.Contains(unitFrom.ToLower()))
            {                
                errorList.Add($"{unitFrom} is not a valid unit to convert from");
            }
            if (!availableUnitNames.Contains(unitTo.ToLower()) && !availableUnitShortNames.Contains(unitTo.ToLower()))
            {
                errorList.Add($"{unitTo} is not a valid unit to convert to");
            }


            return errorList;
        }

        public static LengthConverterQuery Map(string unitFrom, string unitTo, string valueToConvert, List<GetAvaiableLengthUnitsResponse> availableUnits)
        {
            decimal result = 0;
            decimal.TryParse(valueToConvert, out result);

            if(availableUnits.Count(x => x.ShortName == unitFrom) > 0)
            {
                unitFrom = availableUnits.Where(x => x.ShortName.ToUpper() == unitFrom.ToUpper()).First().Name;
            }
            if (availableUnits.Count(x => x.ShortName == unitTo) > 0)
            {
                unitFrom = availableUnits.Where(x => x.ShortName.ToUpper() == unitTo.ToUpper()).First().Name;
            }

            var lengthQuery = new LengthConverterQuery {
                FromUnit = unitFrom,
                ToUnit = unitTo,
                Value = result
            };

            return lengthQuery;
        }



        public void MapResult()
        {

        }
    }
}
