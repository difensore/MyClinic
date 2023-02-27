using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace MyClinic.DAL.Models;

public partial class MyClinicContext : IdentityDbContext<User, IdentityRole, string>
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
            entity.ToTable("Appointment");

            entity.Property(e => e.Date).HasColumnType("datetime");
            entity.Property(e => e.Doctor).HasMaxLength(450);
            entity.Property(e => e.Patient).HasMaxLength(450);

            entity.HasOne(d => d.DoctorNavigation).WithMany(p => p.AppointmentDoctorNavigations)
                .HasForeignKey(d => d.Doctor)
                .HasConstraintName("FK_Appointment_AspNetUsers");

            entity.HasOne(d => d.PatientNavigation).WithMany(p => p.AppointmentPatientNavigations)
                .HasForeignKey(d => d.Patient)
                .HasConstraintName("FK_Appointment_AspNetUsers1");
        });

        OnModelCreatingPartial(modelBuilder);
        base.OnModelCreating(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
