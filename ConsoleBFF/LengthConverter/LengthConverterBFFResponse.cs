using Converter.Application.Queries.Length.LengthConverter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Converter.ConsoleUI_BFF.LengthConverter
{
    public class LengthConverterBFFResponse
    {
        public decimal ConvertedValue { get; set; }
        public bool HasErrors { get; set; }
        public List<string> ErrorList { get; set; } = new List<string>();
    }
}
