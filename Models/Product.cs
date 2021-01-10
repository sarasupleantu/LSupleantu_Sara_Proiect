using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Supleantu_Sara_Proiect.Models
{
    public class Product
    {
        public int ID { get; set; }
        [Required, StringLength(250, MinimumLength = 3)]
        [Display(Name ="Product Name")]
        public string Name { get; set; }
        public string Brand { get; set; }
        [Range(1,500)]
        [Column(TypeName ="decimal(6, 2)")]
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public int ShopID { get; set; }
        public Shop Shop { get; set; }
        public ICollection<ProductCategory> ProductCategories { get; set; }
    }
}
