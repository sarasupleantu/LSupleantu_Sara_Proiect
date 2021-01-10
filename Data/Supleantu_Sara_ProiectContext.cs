using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Supleantu_Sara_Proiect.Models;

namespace Supleantu_Sara_Proiect.Data
{
    public class Supleantu_Sara_ProiectContext : DbContext
    {
        public Supleantu_Sara_ProiectContext (DbContextOptions<Supleantu_Sara_ProiectContext> options)
            : base(options)
        {
        }

        public DbSet<Supleantu_Sara_Proiect.Models.Product> Product { get; set; }

        public DbSet<Supleantu_Sara_Proiect.Models.Shop> Shop { get; set; }

        public DbSet<Supleantu_Sara_Proiect.Models.Category> Category { get; set; }
    }
}
