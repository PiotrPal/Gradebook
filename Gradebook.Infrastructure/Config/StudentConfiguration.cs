﻿using Gradebook.Domain.Entities;
using Gradebook.Infrastructure.Config.Converters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gradebook.Infrastructure.Config {
    public class StudentConfiguration : BaseEntityConfiguration<Student>{
        public override void Configure(EntityTypeBuilder<Student> builder) {
            builder.ToTable("Student");

            builder.Property(s => s.FirstName)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(s => s.LastName)
                .HasMaxLength(50)
                .IsRequired();

            builder.HasIndex(s => s.Email)
                .IsUnique();

            builder.Property(s => s.Email)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(s => s.DateOfBirth)
                .HasConversion<DateOnlyConverter>()
                .HasColumnType("date")
                .IsRequired();

            builder.Property(s => s.YearEnrolled)
                .IsRequired();

            base.Configure(builder);
        }
    }
}
