using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Supleantu_Sara_Proiect.Data;
using Supleantu_Sara_Proiect.Models;

namespace Supleantu_Sara_Proiect.Pages.Shops
{
    public class IndexModel : PageModel
    {
        private readonly Supleantu_Sara_Proiect.Data.Supleantu_Sara_ProiectContext _context;

        public IndexModel(Supleantu_Sara_Proiect.Data.Supleantu_Sara_ProiectContext context)
        {
            _context = context;
        }

        public IList<Shop> Shop { get;set; }

        public async Task OnGetAsync()
        {
            Shop = await _context.Shop.ToListAsync();
        }
    }
}
