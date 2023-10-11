using Infraestructure.Configuration;
using Infraestructure.DataBaseModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure
{
    public class Context:DbContext
    {
        public Context() { }

        public DbSet<CustomerDTO> Customer { get; set; }
        public DbSet<OrderDTO> Order { get; set; }

        public Task SaveChangesAsync() => SaveChangesAsync(default);

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<CustomerDTO>(new CustomerConfiguration());
            modelBuilder.ApplyConfiguration<OrderDTO>(new OrderConfiguration());
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured) return;
            optionsBuilder.UseNpgsql("Server=localhost;Port=5432;Database=tech_db;" +
                "Username = admin;Password =240400;Timeout = 300;CommandTimeout = 300");

        }
    }
}
