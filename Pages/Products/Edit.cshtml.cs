using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Supleantu_Sara_Proiect.Data;
using Supleantu_Sara_Proiect.Models;

namespace Supleantu_Sara_Proiect.Pages.Products
{
    public class EditModel :  ProductCategoriesPageModel
    {
        private readonly Supleantu_Sara_Proiect.Data.Supleantu_Sara_ProiectContext _context;

        public EditModel(Supleantu_Sara_Proiect.Data.Supleantu_Sara_ProiectContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Product Product { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Product = await _context.Product.Include(b => b.Shop).Include(b => b.ProductCategories).ThenInclude(b => b.Category).AsNoTracking().FirstOrDefaultAsync(m => m.ID == id);

            if (Product == null)
            {
                return NotFound();
            }

            //apelam populateAssignedCategoryData pentru a obtine informatiile necesare checkbox-urilor folosind clasa AssignedCategoryData
            PopulateAssignedCategoryData(_context, Product);

            ViewData["ShopID"] = new SelectList(_context.Set<Shop>(), "ID", "ShopName");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id, string[] selectedCategories)
        {
            if(id == null)
            {
                return NotFound();
            }
            var productToUpdate = await _context.Product.Include(i => i.Shop).Include(i => i.ProductCategories).ThenInclude(i => i.Category).FirstOrDefaultAsync(s => s.ID == id);
            if (productToUpdate == null)
            {
                return NotFound();
            }
            if (await TryUpdateModelAsync<Product>(productToUpdate, "Product", i => i.Name, i => i.Brand, i => i.Price, i => i.Quantity, i => i.Shop))
            {
                UpdateProductCategories(_context, selectedCategories, productToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            //Apelam UpdateBookCategories pentru a aplica informatiile din checkboxuri la entitatea Products care este editata
            UpdateProductCategories(_context, selectedCategories, productToUpdate);
            PopulateAssignedCategoryData(_context, productToUpdate);
            return Page();
        }
    }
}
