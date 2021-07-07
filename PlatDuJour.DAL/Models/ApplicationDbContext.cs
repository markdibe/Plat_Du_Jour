using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace PlatDuJour.DAL.Models
{
    public partial class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        //public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        //public virtual DbSet<AspNetRoleClaim> AspNetRoleClaims { get; set; }
        //public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        //public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        //public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        //public virtual DbSet<AspNetUserRole> AspNetUserRoles { get; set; }
        //public virtual DbSet<AspNetUserToken> AspNetUserTokens { get; set; }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<DailyPlate> DailyPlates { get; set; }
        public virtual DbSet<Ingredient> Ingredients { get; set; }
        public virtual DbSet<IngredientImage> IngredientImages { get; set; }
        public virtual DbSet<IngredientItem> IngredientItems { get; set; }
        public virtual DbSet<Item> Items { get; set; }
        public virtual DbSet<ItemImage> ItemImages { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Portfolio> Portfolios { get; set; }
        public virtual DbSet<RatingImage> RatingImages { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseSqlServer("Server=marcdibe-pc;Database=play_du_jour_db;Trusted_Connection=True;");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            //modelBuilder.Entity<AspNetRole>(entity =>
            //{
            //    entity.Property(e => e.Name).HasMaxLength(256);

            //    entity.Property(e => e.NormalizedName).HasMaxLength(256);
            //});

            //modelBuilder.Entity<AspNetRoleClaim>(entity =>
            //{
            //    entity.Property(e => e.RoleId)
            //        .IsRequired()
            //        .HasMaxLength(450);

            //    entity.HasOne(d => d.Role)
            //        .WithMany(p => p.AspNetRoleClaims)
            //        .HasForeignKey(d => d.RoleId);
            //});

            //modelBuilder.Entity<AspNetUser>(entity =>
            //{
            //    entity.Property(e => e.Discriminator).IsRequired();

            //    entity.Property(e => e.Email).HasMaxLength(256);

            //    entity.Property(e => e.Name).HasMaxLength(200);

            //    entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

            //    entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

            //    entity.Property(e => e.UserName).HasMaxLength(256);
            //});

            //modelBuilder.Entity<AspNetUserClaim>(entity =>
            //{
            //    entity.Property(e => e.UserId)
            //        .IsRequired()
            //        .HasMaxLength(450);

            //    entity.HasOne(d => d.User)
            //        .WithMany(p => p.AspNetUserClaims)
            //        .HasForeignKey(d => d.UserId);
            //});

            //modelBuilder.Entity<AspNetUserLogin>(entity =>
            //{
            //    entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

            //    entity.Property(e => e.UserId)
            //        .IsRequired()
            //        .HasMaxLength(450);

            //    entity.HasOne(d => d.User)
            //        .WithMany(p => p.AspNetUserLogins)
            //        .HasForeignKey(d => d.UserId);
            //});

            //modelBuilder.Entity<AspNetUserRole>(entity =>
            //{
            //    entity.HasKey(e => new { e.UserId, e.RoleId });

            //    entity.HasOne(d => d.Role)
            //        .WithMany(p => p.AspNetUserRoles)
            //        .HasForeignKey(d => d.RoleId);

            //    entity.HasOne(d => d.User)
            //        .WithMany(p => p.AspNetUserRoles)
            //        .HasForeignKey(d => d.UserId);
            //});

            //modelBuilder.Entity<AspNetUserToken>(entity =>
            //{
            //    entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

            //    entity.HasOne(d => d.User)
            //        .WithMany(p => p.AspNetUserTokens)
            //        .HasForeignKey(d => d.UserId);
            //});

            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.CategoryId).ValueGeneratedNever();

                entity.Property(e => e.CategoryDescription).HasMaxLength(2000);

                entity.Property(e => e.CategoryHeader).HasMaxLength(250);

                entity.Property(e => e.CategoryName)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.CategoryTitle).HasMaxLength(500);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ImageUrl).HasMaxLength(500);

                entity.Property(e => e.ParentId).HasMaxLength(500);
            });

            modelBuilder.Entity<DailyPlate>(entity =>
            {
                entity.Property(e => e.DailyPlateId).ValueGeneratedNever();

                entity.Property(e => e.Comments).HasMaxLength(1000);

                entity.Property(e => e.DateTimeToBeReady).HasColumnType("datetime");

                entity.Property(e => e.Day).HasColumnType("date");

                entity.Property(e => e.Price).HasColumnType("decimal(10, 3)");

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.DailyPlates)
                    .HasForeignKey(d => d.ItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DailyPlates_Items");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.DailyPlates)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DailyPlates_AspNetUsers");
            });

            modelBuilder.Entity<Ingredient>(entity =>
            {
                entity.Property(e => e.IngredientId).ValueGeneratedNever();

                entity.Property(e => e.IngredientDescription).HasMaxLength(2000);

                entity.Property(e => e.IngredientHeader).HasMaxLength(500);

                entity.Property(e => e.IngredientName)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.IngredientTitle).HasMaxLength(500);
            });

            modelBuilder.Entity<IngredientImage>(entity =>
            {
                entity.HasKey(e => e.ImageId);

                entity.Property(e => e.ImageId).ValueGeneratedNever();

                entity.Property(e => e.ImageTitle).HasMaxLength(200);

                entity.Property(e => e.ImageUrl).HasMaxLength(300);

                entity.HasOne(d => d.Ingredient)
                    .WithMany(p => p.IngredientImages)
                    .HasForeignKey(d => d.IngredientId)
                    .HasConstraintName("FK_IngredientImages_Ingredients");
            });

            modelBuilder.Entity<IngredientItem>(entity =>
            {
                entity.HasKey(e => e.ItemIngredientId);

                entity.Property(e => e.ItemIngredientId).ValueGeneratedNever();

                entity.Property(e => e.Quantity).HasColumnType("decimal(2, 0)");

                entity.Property(e => e.Unit).HasMaxLength(10);

                entity.HasOne(d => d.Ingredient)
                    .WithMany(p => p.IngredientItems)
                    .HasForeignKey(d => d.IngredientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_IngredientItems_Ingredients");

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.IngredientItems)
                    .HasForeignKey(d => d.ItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_IngredientItems_Items");
            });

            modelBuilder.Entity<Item>(entity =>
            {
                entity.Property(e => e.ItemId).ValueGeneratedNever();

                entity.Property(e => e.ItemDescription).HasMaxLength(500);

                entity.Property(e => e.ItemHeader).HasMaxLength(500);

                entity.Property(e => e.ItemName)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.ItemNameAr)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.ItemTitle).HasMaxLength(500);

                entity.Property(e => e.UserId).HasMaxLength(450);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Items)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Items_Categories");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Items)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_Items_AspNetUsers");
            });

            modelBuilder.Entity<ItemImage>(entity =>
            {
                entity.HasKey(e => e.ImageId);

                entity.Property(e => e.ImageId).ValueGeneratedNever();

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ImageTag).HasMaxLength(500);

                entity.Property(e => e.ImageUrl).HasMaxLength(300);

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.ItemImages)
                    .HasForeignKey(d => d.ItemId)
                    .HasConstraintName("FK_ItemImages_Items");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.OrderId).ValueGeneratedNever();

                entity.Property(e => e.Approved).HasColumnName("approved");

                entity.Property(e => e.ClientId)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.Rating)
                    .HasColumnType("decimal(1, 1)")
                    .HasColumnName("rating");

                entity.Property(e => e.RatingDescription)
                    .HasMaxLength(1000)
                    .HasColumnName("ratingDescription");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Orders_AspNetUsers");

                entity.HasOne(d => d.DailyPlate)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.DailyPlateId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Orders_DailyPlates");
            });

            modelBuilder.Entity<Portfolio>(entity =>
            {
                entity.ToTable("Portfolio");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Address).HasMaxLength(600);

                entity.Property(e => e.CellNumber).HasMaxLength(13);

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.Header).HasMaxLength(200);

                entity.Property(e => e.ImageUrl).HasMaxLength(300);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.PhoneNumber).HasMaxLength(13);

                entity.Property(e => e.Title).HasMaxLength(200);

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Portfolios)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Portfolio_AspNetUsers");
            });

            modelBuilder.Entity<RatingImage>(entity =>
            {
                entity.HasKey(e => e.ImageId);

                entity.Property(e => e.ImageId).ValueGeneratedNever();

                entity.Property(e => e.ImageTag).HasMaxLength(500);

                entity.Property(e => e.ImageUrl)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.OrderIdRateId).HasColumnName("OrderId_RateId");

                entity.HasOne(d => d.OrderIdRate)
                    .WithMany(p => p.RatingImages)
                    .HasForeignKey(d => d.OrderIdRateId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RatingImages_Orders");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
