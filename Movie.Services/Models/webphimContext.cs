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

        public virtual DbSet<TbCategoryMovie> TbCategoryMovie { get; set; }
        public virtual DbSet<TbMovie> TbMovie { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySQL("server=128.199.183.242;port=3306;user=huyqta;password=huyqta;database=webphim");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.0-rtm-35687");

            modelBuilder.Entity<TbCategoryMovie>(entity =>
            {
                entity.ToTable("tb_category_movie", "webphim");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CategoryName)
                    .IsRequired()
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

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CategoryId)
                    .HasColumnName("category_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ImdbId)
                    .HasColumnName("imdb_id")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.MovieName)
                    .IsRequired()
                    .HasColumnName("movie_name")
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });
        }
    }
}
