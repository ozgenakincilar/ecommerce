namespace NS.Business.Cart
{
    public class CartItem : ICartItem
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public string PhotoUrl { get; set; }
    }
}
