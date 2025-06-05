using EjsTema5.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjsTema5
{
    public class AppDbContext : DbContext
    {
        public DbSet<StudentDTO> Students { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=localhost;Database=EjsTema5;User Id=sa;Password=yourStrong(!)Password;");
            }
        }
    }
}