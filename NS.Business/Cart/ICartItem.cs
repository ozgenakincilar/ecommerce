namespace NS.Business.Cart
{
    public interface ICartItem
    {
        int ProductId { get; set; }
        string ProductName { get; set; }
        decimal UnitPrice { get; set; }
        int Quantity { get; set; }
        string PhotoUrl { get; set; }
    }
}
