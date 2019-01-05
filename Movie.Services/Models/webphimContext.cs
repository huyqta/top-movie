using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Movie.Services.Models
{
    public partial class webphimContext : DbContext
    {
        public webphimContext()
        {
        }

        public webphimContext(DbContextOptions<webphimContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TbAccount> TbAccount { get; set; }
        public virtual DbSet<TbCategoryMovie> TbCategoryMovie { get; set; }
        public virtual DbSet<TbMovie> TbMovie { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySQL("Server=128.199.183.242;User Id=huyqta;Password=huyqta;Database=webphim");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.0-rtm-35687");

            modelBuilder.Entity<TbAccount>(entity =>
            {
                entity.ToTable("tb_account", "webphim");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.AccountType)
                    .HasColumnName("account_type")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasColumnName("username")
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TbCategoryMovie>(entity =>
            {
                entity.ToTable("tb_category_movie", "webphim");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CategoryName)
                    .HasColumnName("category_name")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.ParentId)
                    .HasColumnName("parent_id")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<TbMovie>(entity =>
            {
                entity.ToTable("tb_movie", "webphim");

                entity.HasIndex(e => e.CategoryId)
                    .HasName("category_id_2");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CategoryId)
                    .HasColumnName("category_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Country)
                    .HasColumnName("country")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.GoogleDrive)
                    .HasColumnName("google_drive")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.ImdbId)
                    .HasColumnName("imdb_id")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.MovieName)
                    .IsRequired()
                    .HasColumnName("movie_name")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.MovieType)
                    .HasColumnName("movie_type")
                    .HasColumnType("tinyint(4)")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.ReleaseDate).HasColumnName("release_date");

                entity.Property(e => e.Trailer)
                    .HasColumnName("trailer")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.TbMovie)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("tb_movie_ibfk_1");
            });
        }
    }
}
