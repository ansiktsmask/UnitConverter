namespace Converter.Application.Queries.Length.LengthConverter
{
    public class LengthConverterQuery
    {
        public string FromUnit { get; set; } = string.Empty;
        public string ToUnit { get; set; } = string.Empty;
        public decimal Value { get; set; }
    }
}
