using System;
using System.Collections.Generic;
using GreenCare.API.Models;
using Microsoft.EntityFrameworkCore;

namespace GreenCare.API.Data;

public partial class GreenCareDbContext : DbContext
{
    public GreenCareDbContext()
    {
    }

    public GreenCareDbContext(DbContextOptions<GreenCareDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Account> Accounts { get; set; }

    public virtual DbSet<Appointment> Appointments { get; set; }

    public virtual DbSet<Payment> Payments { get; set; }

    public virtual DbSet<PlantCareLog> PlantCareLogs { get; set; }

    public virtual DbSet<PlantType> PlantTypes { get; set; }

    public virtual DbSet<Review> Reviews { get; set; }

    public virtual DbSet<Service> Services { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=ConnectionStrings:DefaultConnection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Account__3213E83FA101EC62");

            entity.ToTable("Account");

            entity.HasIndex(e => e.Email, "UQ__Account__AB6E6164CFFC0F72").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Address)
                .HasColumnType("text")
                .HasColumnName("address");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("password");
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("phone");
            entity.Property(e => e.Role)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("role");
        });

        modelBuilder.Entity<Appointment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Appointm__3213E83FB36790CB");

            entity.ToTable("Appointment");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AppointmentDateTime)
                .HasColumnType("datetime")
                .HasColumnName("appointmentDateTime");
            entity.Property(e => e.CustomerId).HasColumnName("customerId");
            entity.Property(e => e.ExpertId).HasColumnName("expertId");
            entity.Property(e => e.ServiceId).HasColumnName("serviceId");
            entity.Property(e => e.Status)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasDefaultValue("pending")
                .HasColumnName("status");

            entity.HasOne(d => d.Customer).WithMany(p => p.AppointmentCustomers)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Appointme__custo__534D60F1");

            entity.HasOne(d => d.Expert).WithMany(p => p.AppointmentExperts)
                .HasForeignKey(d => d.ExpertId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Appointme__exper__5441852A");

            entity.HasOne(d => d.Service).WithMany(p => p.Appointments)
                .HasForeignKey(d => d.ServiceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Appointme__servi__619B8048");
        });

        modelBuilder.Entity<Payment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Payment__3213E83FE8BC8AB7");

            entity.ToTable("Payment");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Amount)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("amount");
            entity.Property(e => e.AppointmentId).HasColumnName("appointmentId");
            entity.Property(e => e.PaymentDateTime)
                .HasColumnType("datetime")
                .HasColumnName("paymentDateTime");
            entity.Property(e => e.PaymentMethod)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("paymentMethod");

            entity.HasOne(d => d.Appointment).WithMany(p => p.Payments)
                .HasForeignKey(d => d.AppointmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Payment__appoint__59063A47");
        });

        modelBuilder.Entity<PlantCareLog>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PlantCar__3213E83F42A7C187");

            entity.ToTable("PlantCareLog");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AppointmentId).HasColumnName("appointmentId");
            entity.Property(e => e.ExpertId).HasColumnName("expertId");
            entity.Property(e => e.LogDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("logDate");
            entity.Property(e => e.Notes)
                .HasColumnType("text")
                .HasColumnName("notes");

            entity.HasOne(d => d.Appointment).WithMany(p => p.PlantCareLogs)
                .HasForeignKey(d => d.AppointmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PlantCare__appoi__6383C8BA");

            entity.HasOne(d => d.Expert).WithMany(p => p.PlantCareLogs)
                .HasForeignKey(d => d.ExpertId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PlantCare__exper__5FB337D6");
        });

        modelBuilder.Entity<PlantType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PlantTyp__3213E83F0ED2C91C");

            entity.ToTable("PlantType");

            entity.HasIndex(e => e.Name, "UQ__PlantTyp__72E12F1B37359DAF").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Review>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Review__3213E83F397DB346");

            entity.ToTable("Review");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Comment)
                .HasColumnType("text")
                .HasColumnName("comment");
            entity.Property(e => e.CustomerId).HasColumnName("customerId");
            entity.Property(e => e.Rating).HasColumnName("rating");
            entity.Property(e => e.ServiceId).HasColumnName("serviceId");

            entity.HasOne(d => d.Customer).WithMany(p => p.Reviews)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Review__customer__5CD6CB2B");

            entity.HasOne(d => d.Service).WithMany(p => p.Reviews)
                .HasForeignKey(d => d.ServiceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Review__serviceI__628FA481");
        });

        modelBuilder.Entity<Service>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Service__3213E83FB205D515");

            entity.ToTable("Service");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.ExpertId).HasColumnName("expertId");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.PlantTypeId).HasColumnName("plantTypeId");
            entity.Property(e => e.Price)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("price");

            entity.HasOne(d => d.Expert).WithMany(p => p.Services)
                .HasForeignKey(d => d.ExpertId)
                .HasConstraintName("FK__Service__expertI__5070F446");

            entity.HasOne(d => d.PlantType).WithMany(p => p.Services)
                .HasForeignKey(d => d.PlantTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Service__plantTy__6477ECF3");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
