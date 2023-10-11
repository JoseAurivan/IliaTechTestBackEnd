using Infraestructure.DataBaseModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Configuration
{
    public class OrderConfiguration : IEntityTypeConfiguration<OrderDTO>
    {
        public void Configure(EntityTypeBuilder<OrderDTO> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Description);
            builder.HasOne(x => x.Customer).WithMany(x => x.Orders).HasForeignKey(x => x.CustomerId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
