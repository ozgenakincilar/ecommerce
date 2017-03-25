using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NS.Web.Models.Cart
{
    public class CartItemViewModel
    {
        [Required]
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        [Required]
        public int Quantity { get; set; }
        public string PhotoUrl { get; set; }
    }
}