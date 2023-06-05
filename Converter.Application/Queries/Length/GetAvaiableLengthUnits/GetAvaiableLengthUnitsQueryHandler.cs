using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Converter.Application.Queries.Length.GetAvaiableLengthUnits
{
    public class GetAvaiableLengthUnitsQueryHandler
    {
        public List<GetAvaiableLengthUnitsResponse> Execute(GetAvaiableLengthUnitsQuery query)
        {
            var response = new List<GetAvaiableLengthUnitsResponse>();

            response.Add(new GetAvaiableLengthUnitsResponse { Name= "Thou", ShortName = "th" });
            response.Add(new GetAvaiableLengthUnitsResponse { Name = "Inch", ShortName = "in" });
            response.Add(new GetAvaiableLengthUnitsResponse { Name = "Foot", ShortName = "ft" });
            response.Add(new GetAvaiableLengthUnitsResponse { Name = "Yard", ShortName = "yd" });
            response.Add(new GetAvaiableLengthUnitsResponse { Name = "Furlong", ShortName = "fur" });

            response = response.Where(x => String.IsNullOrEmpty(query.Name) || x.Name == query.Name).ToList();

            return response;
        }
    }
}
