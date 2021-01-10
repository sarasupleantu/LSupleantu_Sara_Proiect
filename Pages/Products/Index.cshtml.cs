using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Supleantu_Sara_Proiect.Data;
using Supleantu_Sara_Proiect.Models;

namespace Supleantu_Sara_Proiect.Pages.Products
{
    public class IndexModel : PageModel
    {
        private readonly Supleantu_Sara_Proiect.Data.Supleantu_Sara_ProiectContext _context;

        public IndexModel(Supleantu_Sara_Proiect.Data.Supleantu_Sara_ProiectContext context)
        {
            _context = context;
        }

        public IList<Product> Product { get;set; }
        public ProductData ProductD { get; set; }
        public int ProductID { get; set; }
        public int CategoryID { get; set; }

        public async Task OnGetAsync(int? id, int? categoryID)
        {
            ProductD = new ProductData();
            ProductD.Products = await _context.Product.Include(b => b.Shop).Include(b => b.ProductCategories).ThenInclude(b => b.Category).AsNoTracking().OrderBy(b => b.Name).ToListAsync();
            if(id != null)
            {
                ProductID = id.Value;
                Product product = ProductD.Products.Where(i => i.ID == id.Value).Single();
                ProductD.Categories = product.ProductCategories.Select(s => s.Category);
            }
        }
    }
}
