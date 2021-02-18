using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Vaida_Cecilia_Proiect.Models;

namespace Vaida_Cecilia_Proiect.Data
{
    public class Vaida_Cecilia_ProiectContext : DbContext
    {
        public Vaida_Cecilia_ProiectContext (DbContextOptions<Vaida_Cecilia_ProiectContext> options)
            : base(options)
        {
        }

        public DbSet<Vaida_Cecilia_Proiect.Models.Car> Car { get; set; }

        public DbSet<Vaida_Cecilia_Proiect.Models.Publisher> Publisher { get; set; }

        public DbSet<Vaida_Cecilia_Proiect.Models.Category> Category { get; set; }
    }
}
