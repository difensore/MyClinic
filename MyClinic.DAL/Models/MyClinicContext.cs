using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MyClinic;

public partial class MyClinicContext : DbContext
{
    public MyClinicContext()
    {
    }

    public MyClinicContext(DbContextOptions<MyClinicContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Appointment> Appointments { get; set; }

    

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Appointment>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Appointment");

            entity.Property(e => e.Date).HasColumnType("datetime");
            entity.Property(e => e.Doctor).HasMaxLength(450);
            entity.Property(e => e.Id).HasMaxLength(450);
            entity.Property(e => e.Patient)
                .HasMaxLength(450)
                .IsFixedLength();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
