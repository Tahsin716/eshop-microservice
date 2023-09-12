namespace Shopping.Aggregator.Models
{
    public class ShoppingModel
    {
        public string UserName { get; set; } = string.Empty;
        public BasketModel BasketWithProducts { get; set; } = new BasketModel();
        public IEnumerable<OrderResponseModel> Orders { get; set; } = Enumerable.Empty<OrderResponseModel>();
    }
}
