using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Supleantu_Sara_Proiect.Models
{
    public class Shop
    {
        public int ID { get; set; }
        [Display(Name = "Shop Name")]
        public string ShopName { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
