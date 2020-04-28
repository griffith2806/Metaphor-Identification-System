using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ConcreteNounsAPI.Models
{
    public partial class ConcreteNounsDbContext : DbContext
    {
        public ConcreteNounsDbContext()
        {
        }

        public ConcreteNounsDbContext(DbContextOptions<ConcreteNounsDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Animal> Animal { get; set; }
        public virtual DbSet<Artifact> Artifact { get; set; }
        public virtual DbSet<Body> Body { get; set; }
        public virtual DbSet<ConRating> ConRating { get; set; }
        public virtual DbSet<Concrete> Concrete { get; set; }
        public virtual DbSet<Food> Food { get; set; }
        public virtual DbSet<Group> Group { get; set; }
        public virtual DbSet<LocationN> LocationN { get; set; }
        public virtual DbSet<Object> Object { get; set; }
        public virtual DbSet<Person> Person { get; set; }
        public virtual DbSet<Plant> Plant { get; set; }
        public virtual DbSet<Shape> Shape { get; set; }
        public virtual DbSet<State> State { get; set; }
        public virtual DbSet<Substance> Substance { get; set; }
        public virtual DbSet<Time> Time { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=(LocalDB)\\MSSQLLocalDB;Database=ConcreteNounsDb;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Animal>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Animal1)
                    .IsRequired()
                    .HasColumnName("Animal");
            });

            modelBuilder.Entity<Artifact>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Artifact1).HasColumnName("Artifact");
            });

            modelBuilder.Entity<Body>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Body1)
                    .IsRequired()
                    .HasColumnName("Body");
            });

            modelBuilder.Entity<ConRating>(entity =>
            {
                entity.Property(e => e.Id).HasMaxLength(50);

                entity.Property(e => e.Bigram)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ConcM).HasColumnName("Conc_M");

                entity.Property(e => e.ConcSd)
                    .IsRequired()
                    .HasColumnName("Conc_SD")
                    .HasMaxLength(50);

                entity.Property(e => e.DomPos)
                    .IsRequired()
                    .HasColumnName("Dom_Pos")
                    .HasMaxLength(50);

                entity.Property(e => e.PercentKnown)
                    .IsRequired()
                    .HasColumnName("Percent_known")
                    .HasMaxLength(50);

                entity.Property(e => e.Subtlex)
                    .IsRequired()
                    .HasColumnName("SUBTLEX")
                    .HasMaxLength(50);

                entity.Property(e => e.Unknown)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Word)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Concrete>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.ConcM).HasColumnName("Conc#M");

                entity.Property(e => e.ConcSd).HasColumnName("Conc#SD");

                entity.Property(e => e.PercentKnown).HasColumnName("Percent_known");
            });

            modelBuilder.Entity<Food>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Food1)
                    .IsRequired()
                    .HasColumnName("Food");
            });

            modelBuilder.Entity<Group>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Group1)
                    .IsRequired()
                    .HasColumnName("Group");
            });

            modelBuilder.Entity<LocationN>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Location).IsRequired();
            });

            modelBuilder.Entity<Object>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Object1).HasColumnName("Object");
            });

            modelBuilder.Entity<Person>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Person1).HasColumnName("Person");
            });

            modelBuilder.Entity<Plant>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Plant1)
                    .IsRequired()
                    .HasColumnName("Plant");
            });

            modelBuilder.Entity<Shape>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Shape1).HasColumnName("Shape");
            });

            modelBuilder.Entity<State>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.State1).HasColumnName("State");
            });

            modelBuilder.Entity<Substance>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Substance1)
                    .IsRequired()
                    .HasColumnName("Substance");
            });

            modelBuilder.Entity<Time>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Time1)
                    .IsRequired()
                    .HasColumnName("Time");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
