using Microsoft.EntityFrameworkCore;

namespace GreenCare.API.Models;

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
            entity.HasKey(e => e.Id).HasName("PK__Account__3213E83FFDC331C3");

            entity.ToTable("Account");

            entity.HasIndex(e => e.Email, "UQ__Account__AB6E6164E5D8E3F3").IsUnique();

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
            entity.HasKey(e => e.Id).HasName("PK__Appointm__3213E83F21AD481A");

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
                .HasConstraintName("FK__Appointme__custo__5629CD9C");

            entity.HasOne(d => d.Expert).WithMany(p => p.AppointmentExperts)
                .HasForeignKey(d => d.ExpertId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Appointme__exper__5812160E");

            entity.HasOne(d => d.Service).WithMany(p => p.Appointments)
                .HasForeignKey(d => d.ServiceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Appointme__servi__571DF1D5");
        });

        modelBuilder.Entity<Payment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Payment__3213E83FD3869395");

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
            entity.Property(e => e.Status)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasDefaultValue("pending")
                .HasColumnName("status");

            entity.HasOne(d => d.Appointment).WithMany(p => p.Payments)
                .HasForeignKey(d => d.AppointmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Payment__appoint__5DCAEF64");
        });

        modelBuilder.Entity<PlantCareLog>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PlantCar__3213E83F254392B5");

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
                .HasConstraintName("FK__PlantCare__appoi__66603565");

            entity.HasOne(d => d.Expert).WithMany(p => p.PlantCareLogs)
                .HasForeignKey(d => d.ExpertId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PlantCare__exper__656C112C");
        });

        modelBuilder.Entity<PlantType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PlantTyp__3213E83F5BB5BABB");

            entity.ToTable("PlantType");

            entity.HasIndex(e => e.Name, "UQ__PlantTyp__72E12F1BDC344B37").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Review>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Review__3213E83F366FB311");

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
                .HasConstraintName("FK__Review__customer__60A75C0F");

            entity.HasOne(d => d.Service).WithMany(p => p.Reviews)
                .HasForeignKey(d => d.ServiceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Review__serviceI__619B8048");
        });

        modelBuilder.Entity<Service>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Service__3213E83F2529732C");

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
                .HasConstraintName("FK__Service__expertI__5165187F");

            entity.HasOne(d => d.PlantType).WithMany(p => p.Services)
                .HasForeignKey(d => d.PlantTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Service__plantTy__5070F446");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
