using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Diplom_popitka1.Models
{
    public partial class diplom_popitca1Context : DbContext
    {
        public diplom_popitca1Context()
        {
        }

        public diplom_popitca1Context(DbContextOptions<diplom_popitca1Context> options)
            : base(options)
        {
        }

        public virtual DbSet<BlockRoom> BlockRoom { get; set; }
        public virtual DbSet<ChatMessages> ChatMessages { get; set; }
        public virtual DbSet<ChatRoom> ChatRoom { get; set; }
        public virtual DbSet<Clients> Clients { get; set; }
        public virtual DbSet<Logining> Logining { get; set; }
        public virtual DbSet<Mechanics> Mechanics { get; set; }
        public virtual DbSet<MotorcycleSparePartsStock> MotorcycleSparePartsStock { get; set; }
        public virtual DbSet<MotorcyclesToClient> MotorcyclesToClient { get; set; }
        public virtual DbSet<Notes> Notes { get; set; }
        public virtual DbSet<Places> Places { get; set; }
        public virtual DbSet<RepairRequests> RepairRequests { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<Services> Services { get; set; }
        public virtual DbSet<TakeMotoToWork> TakeMotoToWork { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=-PC\\MSSQLSERVER01;Database=diplom_popitca1;Trusted_Connection=True; TrustServerCertificate=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BlockRoom>(entity =>
            {
                entity.HasKey(e => e.IdBlock)
                    .HasName("PK__BlockRoo__B888406B4CF43700");

                entity.Property(e => e.IdBlock).HasColumnName("id_block");

                entity.Property(e => e.IdChatroom).HasColumnName("id_chatroom");

                entity.Property(e => e.LockEndTime).HasColumnType("datetime");

                entity.Property(e => e.LockStartTime).HasColumnType("datetime");

                entity.HasOne(d => d.IdChatroomNavigation)
                    .WithMany(p => p.BlockRoom)
                    .HasForeignKey(d => d.IdChatroom)
                    .HasConstraintName("FK__BlockRoom__id_ch__66603565");
            });

            modelBuilder.Entity<ChatMessages>(entity =>
            {
                entity.HasKey(e => e.IdMess)
                    .HasName("PK__ChatMess__68A1E1B7515CD21D");

                entity.Property(e => e.IdMess).HasColumnName("id_mess");

                entity.Property(e => e.IdChatroom).HasColumnName("id_chatroom");

                entity.Property(e => e.IdRole).HasColumnName("id_role");

                entity.Property(e => e.Status)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TextMessage)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Timestampp).HasColumnType("datetime");

                entity.HasOne(d => d.IdChatroomNavigation)
                    .WithMany(p => p.ChatMessages)
                    .HasForeignKey(d => d.IdChatroom)
                    .HasConstraintName("FK__ChatMessa__id_ch__628FA481");

                entity.HasOne(d => d.IdRoleNavigation)
                    .WithMany(p => p.ChatMessages)
                    .HasForeignKey(d => d.IdRole)
                    .HasConstraintName("FK__ChatMessa__id_ro__6383C8BA");
            });

            modelBuilder.Entity<ChatRoom>(entity =>
            {
                entity.HasKey(e => e.IdChatroom)
                    .HasName("PK__ChatRoom__111EC98C7E29B2A1");

                entity.Property(e => e.IdChatroom).HasColumnName("id_chatroom");

                entity.Property(e => e.IdClient).HasColumnName("id_client");

                entity.HasOne(d => d.IdClientNavigation)
                    .WithMany(p => p.ChatRoom)
                    .HasForeignKey(d => d.IdClient)
                    .HasConstraintName("FK__ChatRoom__id_cli__5FB337D6");
            });

            modelBuilder.Entity<Clients>(entity =>
            {
                entity.HasKey(e => e.IdClient)
                    .HasName("PK__Clients__6EC2B6C0791B8B7C");

                entity.Property(e => e.IdClient).HasColumnName("id_client");

                entity.Property(e => e.Fullname)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Telephone)
                    .HasMaxLength(11)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Logining>(entity =>
            {
                entity.HasKey(e => e.IdLoginUser)
                    .HasName("PK__Logining__8826F5FAA9F0754B");

                entity.Property(e => e.IdLoginUser).HasColumnName("id_login_user");

                entity.Property(e => e.IdRole).HasColumnName("id_role");

                entity.Property(e => e.IdUser).HasColumnName("id_user");

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdRoleNavigation)
                    .WithMany(p => p.Logining)
                    .HasForeignKey(d => d.IdRole)
                    .HasConstraintName("FK__Logining__id_rol__4E88ABD4");
            });

            modelBuilder.Entity<Mechanics>(entity =>
            {
                entity.HasKey(e => e.IdMechanic)
                    .HasName("PK__Mechanic__CB1EAF1FE524580C");

                entity.Property(e => e.IdMechanic).HasColumnName("id_mechanic");

                entity.Property(e => e.Fullname)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Telephone)
                    .HasMaxLength(11)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MotorcycleSparePartsStock>(entity =>
            {
                entity.HasKey(e => e.IdSpare)
                    .HasName("PK__Motorcyc__704D2D2D8D243C4F");

                entity.Property(e => e.IdSpare).HasColumnName("id_spare");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MotorcyclesToClient>(entity =>
            {
                entity.HasKey(e => e.IdMotoCl)
                    .HasName("PK__Motorcyc__FD3C2D9F798C0A9F");

                entity.Property(e => e.IdMotoCl).HasColumnName("id_motoCl");

                entity.Property(e => e.IdClient).HasColumnName("id_client");

                entity.Property(e => e.Model)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.YearRelease).HasColumnType("date");

                entity.HasOne(d => d.IdClientNavigation)
                    .WithMany(p => p.MotorcyclesToClient)
                    .HasForeignKey(d => d.IdClient)
                    .HasConstraintName("FK__Motorcycl__id_cl__44FF419A");
            });

            modelBuilder.Entity<Notes>(entity =>
            {
                entity.HasKey(e => e.IdNote)
                    .HasName("PK__Notes__26991A709EAB099A");

                entity.Property(e => e.IdNote).HasColumnName("id_note");

                entity.Property(e => e.Content)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.DateTime)
                    .HasColumnName("Date_Time")
                    .HasColumnType("datetime");

                entity.Property(e => e.Execution)
                    .HasMaxLength(1)
                    .IsFixedLength();

                entity.Property(e => e.IdMechanic).HasColumnName("id_mechanic");

                entity.Property(e => e.IdRequest).HasColumnName("id_request");

                entity.HasOne(d => d.IdMechanicNavigation)
                    .WithMany(p => p.Notes)
                    .HasForeignKey(d => d.IdMechanic)
                    .HasConstraintName("FK__Notes__id_mechan__5CD6CB2B");

                entity.HasOne(d => d.IdRequestNavigation)
                    .WithMany(p => p.Notes)
                    .HasForeignKey(d => d.IdRequest)
                    .HasConstraintName("FK__Notes__id_reques__5BE2A6F2");
            });

            modelBuilder.Entity<Places>(entity =>
            {
                entity.HasKey(e => e.IdPlace)
                    .HasName("PK__Places__04D478F45F16BC08");

                entity.Property(e => e.IdPlace).HasColumnName("id_place");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<RepairRequests>(entity =>
            {
                entity.HasKey(e => e.IdRequest)
                    .HasName("PK__RepairRe__7ADC39FC16AF9C24");

                entity.Property(e => e.IdRequest).HasColumnName("id_request");

                entity.Property(e => e.IdMechanic).HasColumnName("id_mechanic");

                entity.Property(e => e.IdMotoCl).HasColumnName("id_motoCl");

                entity.Property(e => e.Places)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Problem)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Report)
                    .HasMaxLength(550)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdMechanicNavigation)
                    .WithMany(p => p.RepairRequests)
                    .HasForeignKey(d => d.IdMechanic)
                    .HasConstraintName("FK__RepairReq__id_me__4BAC3F29");

                entity.HasOne(d => d.IdMotoClNavigation)
                    .WithMany(p => p.RepairRequests)
                    .HasForeignKey(d => d.IdMotoCl)
                    .HasConstraintName("FK__RepairReq__id_mo__4AB81AF0");
            });

            modelBuilder.Entity<Roles>(entity =>
            {
                entity.HasKey(e => e.IdRole)
                    .HasName("PK__Roles__3D48441D0071E5E2");

                entity.Property(e => e.IdRole).HasColumnName("id_role");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Services>(entity =>
            {
                entity.HasKey(e => e.IdService)
                    .HasName("PK__Services__D06FB5A853D2AD2E");

                entity.Property(e => e.IdService).HasColumnName("id_service");

                entity.Property(e => e.Cost).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TakeMotoToWork>(entity =>
            {
                entity.HasKey(e => e.IdTakemoto)
                    .HasName("PK__TakeMoto__3A4D04AA751F5731");

                entity.Property(e => e.IdTakemoto).HasColumnName("Id_takemoto");

                entity.Property(e => e.Mileage)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Model)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
