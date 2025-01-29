using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Hospital_management.Models;

public partial class HealthcareDbContext : DbContext
{
    public HealthcareDbContext()
    {
    }

    public HealthcareDbContext(DbContextOptions<HealthcareDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Encounter> Encounters { get; set; }

    public virtual DbSet<Hospital> Hospitals { get; set; }

    public virtual DbSet<Patient> Patients { get; set; }

    public virtual DbSet<Practitioner> Practitioners { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("server=DESKTOP-ATTBD8G\\SQLEXPRESS; database=HealthcareDB;trusted_connection=true ;encrypt=false");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Encounter>(entity =>
        {
            entity.HasKey(e => e.EncounterId).HasName("PK__Encounte__CDF1340F401A7D83");

            entity.ToTable("Encounter");

            entity.Property(e => e.EncounterId).HasColumnName("encounter_id");
            entity.Property(e => e.Diagnosis).HasColumnName("diagnosis");
            entity.Property(e => e.EncounterDate).HasColumnName("encounter_date");
            entity.Property(e => e.EncounterType)
                .HasMaxLength(50)
                .HasColumnName("encounter_type");
            entity.Property(e => e.HospitalId).HasColumnName("hospital_id");
            entity.Property(e => e.PatientId).HasColumnName("patient_id");
            entity.Property(e => e.PractitionerId).HasColumnName("practitioner_id");
            entity.Property(e => e.Treatment).HasColumnName("treatment");

            entity.HasOne(d => d.Hospital).WithMany(p => p.Encounters)
                .HasForeignKey(d => d.HospitalId)
                .HasConstraintName("FK__Encounter__hospi__47DBAE45");

            entity.HasOne(d => d.Patient).WithMany(p => p.Encounters)
                .HasForeignKey(d => d.PatientId)
                .HasConstraintName("FK__Encounter__patie__45F365D3");

            entity.HasOne(d => d.Practitioner).WithMany(p => p.Encounters)
                .HasForeignKey(d => d.PractitionerId)
                .HasConstraintName("FK__Encounter__pract__46E78A0C");
        });

        modelBuilder.Entity<Hospital>(entity =>
        {
            entity.HasKey(e => e.HospitalId).HasName("PK__Hospital__DFF4167FBC242D62");

            entity.ToTable("Hospital");

            entity.HasIndex(e => e.Email, "UQ__Hospital__AB6E6164F25AA03A").IsUnique();

            entity.Property(e => e.HospitalId).HasColumnName("hospital_id");
            entity.Property(e => e.Address).HasColumnName("address");
            entity.Property(e => e.City)
                .HasMaxLength(100)
                .HasColumnName("city");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .HasColumnName("email");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.Phone)
                .HasMaxLength(15)
                .HasColumnName("phone");
            entity.Property(e => e.State)
                .HasMaxLength(100)
                .HasColumnName("state");
        });

        modelBuilder.Entity<Patient>(entity =>
        {
            entity.HasKey(e => e.PatientId).HasName("PK__Patient__4D5CE476E103BB44");

            entity.ToTable("Patient");

            entity.HasIndex(e => e.Email, "UQ__Patient__AB6E6164051F3534").IsUnique();

            entity.HasIndex(e => e.Phone, "UQ__Patient__B43B145F8C766A2E").IsUnique();

            entity.Property(e => e.PatientId).HasColumnName("patient_id");
            entity.Property(e => e.Address).HasColumnName("address");
            entity.Property(e => e.AdmissionDate).HasColumnName("admission_date");
            entity.Property(e => e.DateOfBirth).HasColumnName("date_of_birth");
            entity.Property(e => e.DischargeDate).HasColumnName("discharge_date");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .HasColumnName("email");
            entity.Property(e => e.FirstName)
                .HasMaxLength(100)
                .HasColumnName("first_name");
            entity.Property(e => e.Gender)
                .HasMaxLength(10)
                .HasColumnName("gender");
            entity.Property(e => e.HospitalId).HasColumnName("hospital_id");
            entity.Property(e => e.LastName)
                .HasMaxLength(100)
                .HasColumnName("last_name");
            entity.Property(e => e.Phone)
                .HasMaxLength(15)
                .HasColumnName("phone");

            entity.HasOne(d => d.Hospital).WithMany(p => p.Patients)
                .HasForeignKey(d => d.HospitalId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK__Patient__hospita__3D5E1FD2");
        });

        modelBuilder.Entity<Practitioner>(entity =>
        {
            entity.HasKey(e => e.PractitionerId).HasName("PK__Practiti__8091DF6CF260D7FD");

            entity.ToTable("Practitioner");

            entity.HasIndex(e => e.Email, "UQ__Practiti__AB6E61641F799FD4").IsUnique();

            entity.HasIndex(e => e.Phone, "UQ__Practiti__B43B145F23173781").IsUnique();

            entity.Property(e => e.PractitionerId).HasColumnName("practitioner_id");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .HasColumnName("email");
            entity.Property(e => e.FirstName)
                .HasMaxLength(100)
                .HasColumnName("first_name");
            entity.Property(e => e.HospitalId).HasColumnName("hospital_id");
            entity.Property(e => e.LastName)
                .HasMaxLength(100)
                .HasColumnName("last_name");
            entity.Property(e => e.Phone)
                .HasMaxLength(15)
                .HasColumnName("phone");
            entity.Property(e => e.Specialization)
                .HasMaxLength(255)
                .HasColumnName("specialization");

            entity.HasOne(d => d.Hospital).WithMany(p => p.Practitioners)
                .HasForeignKey(d => d.HospitalId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK__Practitio__hospi__4222D4EF");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
