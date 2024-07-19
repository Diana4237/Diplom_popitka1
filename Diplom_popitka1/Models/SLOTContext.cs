using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Diplom_popitka1.Models
{
    public partial class SLOTContext : DbContext
    {
        public SLOTContext()
        {
        }

        public SLOTContext(DbContextOptions<SLOTContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Accessoirie> Accessoirie { get; set; }
        public virtual DbSet<Consumable> Consumable { get; set; }
        public virtual DbSet<Equipment> Equipment { get; set; }
        public virtual DbSet<MotorTechnics> MotorTechnics { get; set; }
        public virtual DbSet<SparePart> SparePart { get; set; }
        public virtual DbSet<Tire> Tire { get; set; }
        public virtual DbSet<TypeAccessoiries> TypeAccessoiries { get; set; }
        public virtual DbSet<TypeConsumable> TypeConsumable { get; set; }
        public virtual DbSet<TypeMotorTechnics> TypeMotorTechnics { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=-PC\\MSSQLSERVER01;Database=SLOT;Trusted_Connection=True; TrustServerCertificate=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Accessoirie>(entity =>
            {
                entity.HasKey(e => e.IdAccessoirie)
                    .HasName("PK__Accessoi__1F6343E51FF1EA32");

                entity.Property(e => e.IdAccessoirie).HasColumnName("Id_accessoirie");

                entity.Property(e => e.Cost).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.IdTypeAccessoiries).HasColumnName("Id_type_accessoiries");

                entity.Property(e => e.NameAccessoirie)
                    .HasColumnName("Name_accessoirie")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdTypeAccessoiriesNavigation)
                    .WithMany(p => p.Accessoirie)
                    .HasForeignKey(d => d.IdTypeAccessoiries)
                    .HasConstraintName("FK__Accessoir__Id_ty__48CFD27E");
            });

            modelBuilder.Entity<Consumable>(entity =>
            {
                entity.HasKey(e => e.IdConsumable)
                    .HasName("PK__Consumab__E718E2A01E756C22");

                entity.Property(e => e.IdConsumable).HasColumnName("Id_consumable");

                entity.Property(e => e.Cost).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.IdTypeConsumable).HasColumnName("Id_type_consumable");

                entity.Property(e => e.NameConsumable)
                    .HasColumnName("Name_consumable")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdTypeConsumableNavigation)
                    .WithMany(p => p.Consumable)
                    .HasForeignKey(d => d.IdTypeConsumable)
                    .HasConstraintName("FK__Consumabl__Id_ty__440B1D61");
            });

            modelBuilder.Entity<Equipment>(entity =>
            {
                entity.HasKey(e => e.IdEquipment)
                    .HasName("PK__Equipmen__DC7CBD123BBB153B");

                entity.Property(e => e.IdEquipment).HasColumnName("Id_equipment");

                entity.Property(e => e.Color)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Cost).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.NameEquipment)
                    .HasColumnName("Name_equipment")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Size)
                    .HasMaxLength(5)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MotorTechnics>(entity =>
            {
                entity.HasKey(e => e.IdMotorTechnics)
                    .HasName("PK__Motor_te__456427B7583B6D6F");

                entity.ToTable("Motor_technics");

                entity.Property(e => e.IdMotorTechnics).HasColumnName("Id_motor_technics");

                entity.Property(e => e.Cost).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.DefinitionMotorTechnics)
                    .HasColumnName("Definition_motor_technics")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.EngineCapacity).HasColumnName("Engine_capacity");

                entity.Property(e => e.IdTypeMotorTechnics).HasColumnName("Id_type_motor_technics");

                entity.Property(e => e.Purpose)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Transmission)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdTypeMotorTechnicsNavigation)
                    .WithMany(p => p.MotorTechnics)
                    .HasForeignKey(d => d.IdTypeMotorTechnics)
                    .HasConstraintName("FK__Motor_tec__Id_ty__398D8EEE");
            });

            modelBuilder.Entity<SparePart>(entity =>
            {
                entity.HasKey(e => e.IdSparePart)
                    .HasName("PK__Spare_pa__54A856B8F04F5408");

                entity.ToTable("Spare_part");

                entity.Property(e => e.IdSparePart).HasColumnName("Id_spare_part");

                entity.Property(e => e.Color)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Cost).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.NameSparePart)
                    .HasColumnName("Name_spare_part")
                    .HasMaxLength(150)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Tire>(entity =>
            {
                entity.HasKey(e => e.IdTire)
                    .HasName("PK__Tire__70A6A7DF8DB52030");

                entity.Property(e => e.IdTire).HasColumnName("Id_tire");

                entity.Property(e => e.Color)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Cost).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.NameTire)
                    .HasColumnName("Name_tire")
                    .HasMaxLength(150)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TypeAccessoiries>(entity =>
            {
                entity.HasKey(e => e.IdTypeAccessoiries)
                    .HasName("PK__Type_acc__F7D0BB0A6D8E27EF");

                entity.ToTable("Type_accessoiries");

                entity.Property(e => e.IdTypeAccessoiries).HasColumnName("Id_type_accessoiries");

                entity.Property(e => e.NameTypeAccessoiries)
                    .HasColumnName("Name_type_accessoiries")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TypeConsumable>(entity =>
            {
                entity.HasKey(e => e.IdTypeConsumable)
                    .HasName("PK__Type_con__09CF37AB6962BE80");

                entity.ToTable("Type_consumable");

                entity.Property(e => e.IdTypeConsumable).HasColumnName("Id_type_consumable");

                entity.Property(e => e.NameType)
                    .HasColumnName("Name_type")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TypeMotorTechnics>(entity =>
            {
                entity.HasKey(e => e.IdTypeMotorTechnics)
                    .HasName("PK__Type_mot__ACB1379EBE1A9D31");

                entity.ToTable("Type_motor_technics");

                entity.Property(e => e.IdTypeMotorTechnics).HasColumnName("Id_type_motor_technics");

                entity.Property(e => e.NameTypeMotorTechnics)
                    .HasColumnName("Name_type_motor_technics")
                    .HasMaxLength(150)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
