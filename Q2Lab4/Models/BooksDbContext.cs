using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Q2Lab4.Models
{
    public partial class BooksDbContext : DbContext
    {
        public BooksDbContext()
        {
        }

        public BooksDbContext(DbContextOptions<BooksDbContext> options)
            : base(options)
        {
        }
        //table names   
        public virtual DbSet<Author> Authors { get; set; } = null!;
        public virtual DbSet<Title> Titles { get; set; } = null!;

        //connection string
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\ProjectModels;Initial Catalog=\"C:\\USERS\\NOVEE\\SOURCE\\REPOS\\LAB04 - SOLUTION TEMPLATE\\LAB04 - SOLUTION TEMPLATE\\Q2LAB4\\DATABASE\\BOOKS.MDF\";Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>(entity =>
            {
                entity.Property(e => e.AuthorId).HasColumnName("AuthorID");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasMany(d => d.Isbns)
                    .WithMany(p => p.Authors)
                    .UsingEntity<Dictionary<string, object>>(
                        "AuthorIsbn",
                        l => l.HasOne<Title>().WithMany().HasForeignKey("Isbn").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_AuthorISBN_Titles"),
                        r => r.HasOne<Author>().WithMany().HasForeignKey("AuthorId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_AuthorISBN_Authors"),
                        j =>
                        {
                            j.HasKey("AuthorId", "Isbn");

                            j.ToTable("AuthorISBN");

                            j.IndexerProperty<int>("AuthorId").HasColumnName("AuthorID");

                            j.IndexerProperty<string>("Isbn").HasMaxLength(20).IsUnicode(false).HasColumnName("ISBN");
                        });
            });

            modelBuilder.Entity<Title>(entity =>
            {
                entity.HasKey(e => e.Isbn);

                entity.Property(e => e.Isbn)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("ISBN");

                entity.Property(e => e.Copyright)
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.Title1)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Title");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
