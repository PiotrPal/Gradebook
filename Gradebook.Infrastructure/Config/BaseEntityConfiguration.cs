using Gradebook.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gradebook.Infrastructure.Config {
    public abstract class BaseEntityConfiguration<TBase> : IEntityTypeConfiguration<TBase> where TBase : Entity {
        public virtual void Configure(EntityTypeBuilder<TBase> builder) {
            builder.HasKey(x => x.ID);

            builder.Property(x => x.CreatedAt)
                .HasColumnType("datetime2(0)")
                .IsRequired();

            builder.Property(x => x.UpdatedAt)
                .HasColumnType("datetime2(0)")
                .IsRequired();
        }
    }
}
