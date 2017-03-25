namespace NS.Web.Models.Products
{
    public class ProductDetailViewModel : ProductViewModel
    {
        public short? UnitsInStock { get; set; }
        public bool Discontinued { get; set; }
        public int? CategoryID { get; set; }
    }
}