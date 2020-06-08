namespace InfrastuctureLayer.Models
{
    public class Remark
    {
        public bool IsNewFare { get; set; }
        public string Value { get; set; }

        public override string ToString()
        {
            return $"Remark -> {Value} IsNewFare -> {IsNewFare}";
        }
    }
}