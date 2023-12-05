using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Models;

public partial class StoresDbContext : DbContext
{
    public StoresDbContext()
    {
    }

    public StoresDbContext(DbContextOptions<StoresDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Delivery> Deliveries { get; set; }

    public virtual DbSet<Groupproduct> Groupproducts { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Sale> Sales { get; set; }

    public virtual DbSet<Store> Stores { get; set; }

    public virtual DbSet<Supplier> Suppliers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySQL("server=localhost;user=root;password=12345;database=stores_db");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Delivery>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("deliveries");

            entity.HasIndex(e => e.ProductId, "deliveries-product_idx");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DateTime)
                .HasColumnType("datetime")
                .HasColumnName("dateTime");
            entity.Property(e => e.DeliveryCost).HasColumnName("deliveryCost");
            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.Quantity).HasColumnName("quantity");

            entity.HasOne(d => d.Product).WithMany(p => p.Deliveries)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("deliveries-product");
        });

        modelBuilder.Entity<Groupproduct>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("groupproducts");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Description)
                .HasMaxLength(1000)
                .HasColumnName("description");
            entity.Property(e => e.NameGroupproducts)
                .HasMaxLength(250)
                .HasColumnName("name_groupproducts");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("products");

            entity.HasIndex(e => e.GroupProductsId, "products-group_idx");

            entity.HasIndex(e => e.SuplierId, "products-suplier_idx");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AvailableQuantity).HasColumnName("availableQuantity");
            entity.Property(e => e.Description)
                .HasMaxLength(1000)
                .HasColumnName("description");
            entity.Property(e => e.GroupProductsId).HasColumnName("groupProducts_id");
            entity.Property(e => e.NameProducts)
                .HasMaxLength(250)
                .HasColumnName("name_products");
            entity.Property(e => e.Price).HasColumnName("price");
            entity.Property(e => e.SuplierId).HasColumnName("suplier_id");

            entity.HasOne(d => d.GroupProducts).WithMany(p => p.Products)
                .HasForeignKey(d => d.GroupProductsId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("products-group");

            entity.HasOne(d => d.Suplier).WithMany(p => p.Products)
                .HasForeignKey(d => d.SuplierId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("products-suplier");
        });

        modelBuilder.Entity<Sale>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("sales");

            entity.HasIndex(e => e.ProductId, "sales-product_idx");

            entity.HasIndex(e => e.StoreId, "sales-store_idx");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DateTime)
                .HasColumnType("datetime")
                .HasColumnName("dateTime");
            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.Quantity).HasColumnName("quantity");
            entity.Property(e => e.SalesAmount).HasColumnName("salesAmount");
            entity.Property(e => e.StoreId).HasColumnName("store_id");

            entity.HasOne(d => d.Product).WithMany(p => p.Sales)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("sales-product");

            entity.HasOne(d => d.Store).WithMany(p => p.Sales)
                .HasForeignKey(d => d.StoreId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("sales-store");
        });

        modelBuilder.Entity<Store>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("stores");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.NameStores)
                .HasMaxLength(250)
                .HasColumnName("name_stores");
            entity.Property(e => e.SocialNetwork)
                .HasColumnType("enum('Instagram','Facebook','TikTok','Telegram','Viber')")
                .HasColumnName("socialNetwork");
        });

        modelBuilder.Entity<Supplier>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("suppliers");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Contacts)
                .HasMaxLength(350)
                .HasColumnName("contacts");
            entity.Property(e => e.NameSuppliers)
                .HasMaxLength(250)
                .HasColumnName("name_suppliers");
            entity.Property(e => e.Rating)
                .HasPrecision(3)
                .HasColumnName("rating");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
