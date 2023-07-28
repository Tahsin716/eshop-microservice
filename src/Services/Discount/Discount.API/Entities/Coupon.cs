namespace Discount.API.Entities
{
    public class Coupon
    {
        public int id { get; set; }
        public string productname { get; set; } = string.Empty;
        public string description { get; set; } = string.Empty;
        public int amount { get; set; }
    }
}
