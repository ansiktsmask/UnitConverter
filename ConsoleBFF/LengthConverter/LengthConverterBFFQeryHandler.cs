using Converter.Application.Queries.Length.GetAvaiableLengthUnits;
using Converter.Application.Queries.Length.LengthConverter;
using Converter.ConsoleUI_BFF.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Converter.ConsoleUI_BFF.LengthConverter
{
    public class LengthConverterBFFQeryHandler
    {
        public LengthConverterBFFResponse Execute(string unitFrom, string unitTo, string valueToConverter)
        {
            var response = new LengthConverterBFFResponse();

            var availableUnits = new GetAvaiableLengthUnitsQueryHandler().Execute(new GetAvaiableLengthUnitsQuery());

            var errorList = LengthConverterQueryValidatorMapper.Validate(unitFrom, unitTo, valueToConverter, availableUnits);

            if(errorList.Count > 0)
            {
                response.HasErrors = true;
                response.ErrorList = errorList;
            }

            var request = LengthConverterQueryValidatorMapper.Map(unitFrom, unitTo, valueToConverter, availableUnits);

            var result = LengthConverterQueryHandler.Execute(request);

            response.ConvertedValue = Math.Round(result.Result, 2);

            return response;
        }
    }
}
