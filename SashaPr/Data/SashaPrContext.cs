using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SashaPr.Models;

namespace SashaPr.Data
{
    public class SashaPrContext : DbContext
    {
        public SashaPrContext (DbContextOptions<SashaPrContext> options)
            : base(options)
        {
        }

        public DbSet<SashaPr.Models.DBModelBook> DBModelBook { get; set; } = default!;
    }
}
