using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Movie.Services.Models
{
    public partial class webphimContext : DbContext
    {
        private string database;

        public webphimContext()
        {
            database = "webphim";
        }

        public webphimContext(string db)
        {
            database = db;
        }

        public webphimContext(DbContextOptions<webphimContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TbAccount> TbAccount { get; set; }
        public virtual DbSet<TbActor> TbActor { get; set; }
        public virtual DbSet<TbCategoryMovie> TbCategoryMovie { get; set; }
        public virtual DbSet<TbComment> TbComment { get; set; }
        public virtual DbSet<TbCrawl> TbCrawl { get; set; }
        public virtual DbSet<TbMovie> TbMovie { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                if (string.IsNullOrWhiteSpace(database)) database = "webphim";
                //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySQL("Server=128.199.183.242;User Id=huyqta;Password=huyqta;Database=" + database);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.0-rtm-35687");

            modelBuilder.Entity<TbAccount>(entity =>
            {
                entity.ToTable("tb_account", database);

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.AccountType)
                    .HasColumnName("account_type")
                    .HasColumnType("int(11)");

                entity.Property(e => e.AdminToken)
                    .HasColumnName("admin_token")
                    .HasMaxLength(500)
                    .IsUnicode(false);

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

            modelBuilder.Entity<TbActor>(entity =>
            {
                entity.ToTable("tb_actor", database);

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ActorName)
                    .IsRequired()
                    .HasColumnName("actor_name")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.ActorType)
                    .IsRequired()
                    .HasColumnName("actor_type")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Title)
                    .HasColumnName("title")
                    .HasMaxLength(2000)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TbCategoryMovie>(entity =>
            {
                entity.ToTable("tb_category_movie", database);

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

            modelBuilder.Entity<TbComment>(entity =>
            {
                entity.ToTable("tb_comment", database);

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Comment)
                    .IsRequired()
                    .HasColumnName("comment")
                    .HasMaxLength(4000)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.IsValidated)
                    .HasColumnName("is_validated")
                    .HasColumnType("tinyint(1)")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.MovieId)
                    .HasColumnName("movie_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.PostedDatetime).HasColumnName("posted_datetime");

                entity.Property(e => e.ReplyCommentId)
                    .HasColumnName("reply_comment_id")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TbCrawl>(entity =>
            {
                entity.ToTable("tb_crawl", database);

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CrawlUrl)
                    .HasColumnName("crawl_url")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.IsSuccess)
                    .HasColumnName("is_success")
                    .HasColumnType("int(1)")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.SiteName)
                    .HasColumnName("site_name")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.SiteUrl)
                    .HasColumnName("site_url")
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TbMovie>(entity =>
            {
                entity.ToTable("tb_movie", database);

                entity.HasIndex(e => e.CategoryId)
                    .HasName("category_id_2");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ActorTag)
                    .HasColumnName("actor_tag")
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasDefaultValueSql("\"\"");

                entity.Property(e => e.CategoryId)
                    .HasColumnName("category_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CategoryTag)
                    .HasColumnName("category_tag")
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasDefaultValueSql("\"\"");

                entity.Property(e => e.CountLike)
                    .HasColumnName("count_like")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("95");

                entity.Property(e => e.CountView)
                    .HasColumnName("count_view")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("97");

                entity.Property(e => e.Country)
                    .HasColumnName("country")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(4000)
                    .IsUnicode(false);

                entity.Property(e => e.GoogleDrive)
                    .HasColumnName("google_drive")
                    .HasMaxLength(2000)
                    .IsUnicode(false);

                entity.Property(e => e.ImageUrl)
                    .HasColumnName("image_url")
                    .HasMaxLength(2000)
                    .IsUnicode(false);

                entity.Property(e => e.ImdbId)
                    .HasColumnName("imdb_id")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.MovieName)
                    .IsRequired()
                    .HasColumnName("movie_name")
                    .HasMaxLength(2000)
                    .IsUnicode(false);

                entity.Property(e => e.MovieTag)
                    .HasColumnName("movie_tag")
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasDefaultValueSql("\"\"");

                entity.Property(e => e.MovieType)
                    .HasColumnName("movie_type")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PosterUrl)
                    .HasColumnName("poster_url")
                    .HasMaxLength(2000)
                    .IsUnicode(false);

                entity.Property(e => e.ReleaseDate).HasColumnName("release_date");

                entity.Property(e => e.StudioTag)
                    .HasColumnName("studio_tag")
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasDefaultValueSql("\"\"");

                entity.Property(e => e.Trailer)
                    .HasColumnName("trailer")
                    .HasMaxLength(2000)
                    .IsUnicode(false);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.TbMovie)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("tb_movie_ibfk_1");

                entity.HasQueryFilter(d => d.GoogleDrive != string.Empty);
            });

            modelBuilder.Entity<TbMoviePhimmoi>(entity =>
            {
                entity.ToTable("tb_movie_phimmoi", "webphim");

                entity.HasIndex(e => e.CategoryId)
                    .HasName("category_id_2");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ActorTag)
                    .HasColumnName("actor_tag")
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasDefaultValueSql("\"\"");

                entity.Property(e => e.CategoryId)
                    .HasColumnName("category_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CategoryTag)
                    .HasColumnName("category_tag")
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasDefaultValueSql("\"\"");

                entity.Property(e => e.CountLike)
                    .HasColumnName("count_like")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("95");

                entity.Property(e => e.CountView)
                    .HasColumnName("count_view")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("97");

                entity.Property(e => e.Country)
                    .HasColumnName("country")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(4000)
                    .IsUnicode(false);

                entity.Property(e => e.GoogleDrive)
                    .HasColumnName("google_drive")
                    .HasMaxLength(2000)
                    .IsUnicode(false);

                entity.Property(e => e.ImageUrl)
                    .HasColumnName("image_url")
                    .HasMaxLength(2000)
                    .IsUnicode(false);

                entity.Property(e => e.ImdbId)
                    .HasColumnName("imdb_id")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.MovieName)
                    .IsRequired()
                    .HasColumnName("movie_name")
                    .HasMaxLength(2000)
                    .IsUnicode(false);

                entity.Property(e => e.MovieTag)
                    .HasColumnName("movie_tag")
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasDefaultValueSql("\"\"");

                entity.Property(e => e.MovieType)
                    .HasColumnName("movie_type")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PosterUrl)
                    .HasColumnName("poster_url")
                    .HasMaxLength(2000)
                    .IsUnicode(false);

                entity.Property(e => e.ReleaseDate).HasColumnName("release_date");

                entity.Property(e => e.StudioTag)
                    .HasColumnName("studio_tag")
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasDefaultValueSql("\"\"");

                entity.Property(e => e.Trailer)
                    .HasColumnName("trailer")
                    .HasMaxLength(2000)
                    .IsUnicode(false);
            });
        }
    }
}
