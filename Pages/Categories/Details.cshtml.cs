using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Supleantu_Sara_Proiect.Data;
using Supleantu_Sara_Proiect.Models;

namespace Supleantu_Sara_Proiect.Pages.Categories
{
    public class DetailsModel : PageModel
    {
        private readonly Supleantu_Sara_Proiect.Data.Supleantu_Sara_ProiectContext _context;

        public DetailsModel(Supleantu_Sara_Proiect.Data.Supleantu_Sara_ProiectContext context)
        {
            _context = context;
        }

        public Category Category { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Category = await _context.Category.FirstOrDefaultAsync(m => m.ID == id);

            if (Category == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
