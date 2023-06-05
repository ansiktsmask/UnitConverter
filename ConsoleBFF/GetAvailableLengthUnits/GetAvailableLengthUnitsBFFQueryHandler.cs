using Converter.Application.Queries.Length.GetAvaiableLengthUnits;

namespace Converter.ConsoleUI_BFF.GetAvailableLengthUnits
{
    public class GetAvailableLengthUnitsBFFQueryHandler
    {
        public List<GetAvailableLengthUnitsBFFResponse> Execute() 
        {
            var response = new  List<GetAvailableLengthUnitsBFFResponse>();
            
            var queryHandler = new GetAvaiableLengthUnitsQueryHandler();
            var result = queryHandler.Execute(new GetAvaiableLengthUnitsQuery());

            foreach(var item in result)
            {
                response.Add(new GetAvailableLengthUnitsBFFResponse
                {
                    Name = item.Name,
                    ShortName = item.ShortName,
                });
            }

            return response;
        }
    }
}
