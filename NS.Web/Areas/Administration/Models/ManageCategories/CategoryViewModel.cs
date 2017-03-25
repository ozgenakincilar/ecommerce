using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace NS.Web.Areas.Administration.Models.Categories
{
    public class CategoryViewModel
    {
        public int CategoryID { get; set; }

        [Display(Name = "Kategori Adı")]
        [Required(ErrorMessage = "Kategori adı boş geçilemez.")]
        public string CategoryName { get; set; }

        [Display(Name = "Açıklaması")]
        [Required(ErrorMessage = "Kategori açıklaması boş geçilemez.")]
        [UIHint("tinymce_full"), AllowHtml]
        public string Description { get; set; }
    }
}