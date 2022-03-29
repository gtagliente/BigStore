using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BigStoreCore.Models
{
    public partial class BigStoreContext : DbContext
    {
        //public BigStoreContext()
        //{
        //}

        public BigStoreContext(DbContextOptions<BigStoreContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<CategoryHierarchy> CategoryHierarchies { get; set; } = null!;
        public virtual DbSet<Discount> Discounts { get; set; } = null!;
        public virtual DbSet<MenuDiscount> MenuDiscounts { get; set; } = null!;
        public virtual DbSet<MenuProduct> MenuProducts { get; set; } = null!;
        public virtual DbSet<POrder> POrders { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseSqlServer("Server=VM10VPN-2202\\SQLEXPRESS;DataBase=BigStore;User ID=docsadm;Password=docsadm;TrustServerCertificate=True;");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("category");

                entity.Property(e => e.CategoryId)
                    .HasColumnName("category_id")
                    .HasDefaultValueSql("(NEXT VALUE FOR [seqitem])");

                entity.Property(e => e.Description)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("description");

                entity.Property(e => e.IsRoot).HasColumnName("is_root");
            });

            modelBuilder.Entity<CategoryHierarchy>(entity =>
            {
                entity.ToTable("category_hierarchy");

                entity.HasIndex(e => e.ChildCategory, "UQ__category__A0C2B273BAF5A04A")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ChildCategory).HasColumnName("child_category");

                entity.Property(e => e.FatherCategory).HasColumnName("father_category");

                entity.HasOne(d => d.ChildCategoryNavigation)
                    .WithOne(p => p.CategoryHierarchyChildCategoryNavigation)
                    .HasForeignKey<CategoryHierarchy>(d => d.ChildCategory)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__category___child__164452B1");

                entity.HasOne(d => d.FatherCategoryNavigation)
                    .WithMany(p => p.CategoryHierarchyFatherCategoryNavigations)
                    .HasForeignKey(d => d.FatherCategory)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__category___fathe__15502E78");
            });

            modelBuilder.Entity<Discount>(entity =>
            {
                entity.ToTable("discount");

                entity.Property(e => e.DiscountId)
                    .HasColumnName("discount_id")
                    .HasDefaultValueSql("(NEXT VALUE FOR [seqitem])");

                entity.Property(e => e.DiscountPercentage).HasColumnName("discount_percentage");

                entity.Property(e => e.Enabled)
                    .IsRequired()
                    .HasColumnName("enabled")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.FromDate)
                    .HasColumnType("date")
                    .HasColumnName("from_date")
                    .HasDefaultValueSql("(getdate()+(1))");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.Property(e => e.ToDate)
                    .HasColumnType("date")
                    .HasColumnName("to_date");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Discounts)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__discount__produc__22AA2996");
            });

            modelBuilder.Entity<MenuDiscount>(entity =>
            {
                entity.HasKey(e => e.MenuId)
                    .HasName("PK__menu_dis__4CA0FADCD23DBACD");

                entity.ToTable("menu_discount");

                entity.Property(e => e.MenuId)
                    .HasColumnName("menu_id")
                    .HasDefaultValueSql("(NEXT VALUE FOR [seqitem])");

                entity.Property(e => e.DiscountPercentage).HasColumnName("discount_percentage");

                entity.Property(e => e.Enabled)
                    .IsRequired()
                    .HasColumnName("enabled")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.FromDate)
                    .HasColumnType("date")
                    .HasColumnName("from_date")
                    .HasDefaultValueSql("(getdate()+(1))");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.ToDate)
                    .HasColumnType("date")
                    .HasColumnName("to_date");
            });

            modelBuilder.Entity<MenuProduct>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("menu_product");

                entity.HasIndex(e => new { e.ProductId, e.MenuId }, "UQ__menu_pro__93C872596CA68E5B")
                    .IsUnique();

                entity.Property(e => e.MenuId).HasColumnName("menu_id");

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.HasOne(d => d.Menu)
                    .WithMany()
                    .HasForeignKey(d => d.MenuId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__menu_prod__menu___2A4B4B5E");

                entity.HasOne(d => d.Product)
                    .WithMany()
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__menu_prod__produ__29572725");
            });

            modelBuilder.Entity<POrder>(entity =>
            {
                entity.HasKey(e => e.OrderId)
                    .HasName("PK__p_order__465962296422FD1B");

                entity.ToTable("p_order");

                entity.Property(e => e.OrderId)
                    .HasColumnName("order_id")
                    .HasDefaultValueSql("(NEXT VALUE FOR [seqorder])");

                entity.Property(e => e.Date)
                    .HasColumnType("datetime")
                    .HasColumnName("date");

                entity.Property(e => e.IsMenu).HasColumnName("is_menu");

                entity.Property(e => e.OrderState)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("order_state");

                entity.Property(e => e.ProductOrMenu).HasColumnName("product_or_menu");

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("date")
                    .HasColumnName("update_date");

                entity.HasOne(d => d.ProductOrMenuNavigation)
                    .WithMany(p => p.POrders)
                    .HasForeignKey(d => d.ProductOrMenu)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__p_order__product__35BCFE0A");

                entity.HasOne(d => d.ProductOrMenu1)
                    .WithMany(p => p.POrders)
                    .HasForeignKey(d => d.ProductOrMenu)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__p_order__product__34C8D9D1");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("product");

                entity.Property(e => e.ProductId)
                    .HasColumnName("product_id")
                    .HasDefaultValueSql("(NEXT VALUE FOR [seqitem])");

                entity.Property(e => e.CategoryId).HasColumnName("category_id");

                entity.Property(e => e.Details)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("details");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.Price)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("price");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__product__categor__1A14E395");
            });

            modelBuilder.HasSequence("seqitem");

            modelBuilder.HasSequence("seqorder");

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
