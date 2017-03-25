namespace NS.Web.Models.Products
{
    public class ProductViewModel
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public decimal? UnitPrice { get; set; }
        public string ImageUrl { get; set; }
    }
}