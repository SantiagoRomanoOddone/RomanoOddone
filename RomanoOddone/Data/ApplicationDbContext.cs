using Microsoft.EntityFrameworkCore;
using RomanoOddone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RomanoOddone.Data
{
    public class ApplicationDbContext : DbContext
    {
        //tiene que estar el constructor con parámetro
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Auto> Auto { get; set; }     

    }
}
