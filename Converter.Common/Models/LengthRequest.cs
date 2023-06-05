namespace Converter.Common.Models
{
    public class LengthRequest
    {
        public string FromUnit { get; set; } = string.Empty; 
        public string ToUnit { get; set;} = string.Empty;
        public decimal Value { get; set; }
    }

    public class LengthQueryResponse
    {
        public decimal Result { get; set; }
    }
}
