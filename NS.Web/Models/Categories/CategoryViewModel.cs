using AutoMapper;

using NS.Orm;

namespace NS.Web.Models.Categories
{
    public class CategoryViewModel
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
    }
}