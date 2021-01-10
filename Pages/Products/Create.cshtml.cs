using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Supleantu_Sara_Proiect.Data;
using Supleantu_Sara_Proiect.Models;

namespace Supleantu_Sara_Proiect.Pages.Products
{
    public class CreateModel : ProductCategoriesPageModel
    {
        private readonly Supleantu_Sara_Proiect.Data.Supleantu_Sara_ProiectContext _context;

        public CreateModel(Supleantu_Sara_Proiect.Data.Supleantu_Sara_ProiectContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["ShopID"] = new SelectList(_context.Set<Shop>(), "ID", "ShopName");
            var product = new Product();
            product.ProductCategories = new List<ProductCategory>();
            PopulateAssignedCategoryData(_context, product);
            return Page();
        }

        [BindProperty]
        public Product Product { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(string[] selectedCategories)
        {
            var newProduct = new Product();
            if(selectedCategories != null)
            {
                newProduct.ProductCategories = new List<ProductCategory>();
                foreach (var cat in selectedCategories)
                {
                    var catToAdd = new ProductCategory
                    {
                        CategoryID = int.Parse(cat)
                    };
                    newProduct.ProductCategories.Add(catToAdd);
                }
            }
            if(await TryUpdateModelAsync<Product>(newProduct, "Product", i => i.Name, i => i.Brand, i => i.Price, i => i.Quantity, i => i.ShopID))
            {
                _context.Product.Add(newProduct);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            PopulateAssignedCategoryData(_context, newProduct);
            return Page();
        }
    }
}
