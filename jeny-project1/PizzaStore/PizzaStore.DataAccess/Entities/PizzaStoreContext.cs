using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PizzaStore.DataAccess.Entities
{
    public partial class PizzaStoreContext : DbContext
    {
        public PizzaStoreContext()
        {
        }

        public PizzaStoreContext(DbContextOptions<PizzaStoreContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cart> Cart { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<Inventory> Inventory { get; set; }
        public virtual DbSet<OrderList> OrderList { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<PurOrder> PurOrder { get; set; }
        public virtual DbSet<Store> Store { get; set; }

        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Cart>(entity =>
            {
                entity.ToTable("Cart", "pizza");

                entity.Property(e => e.CartId).ValueGeneratedNever();

                entity.Property(e => e.Qty).HasColumnName("QTY");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Cart)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductId_cart_ProductId");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("Customer", "pizza");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<Inventory>(entity =>
            {
                entity.ToTable("Inventory", "pizza");

                entity.Property(e => e.InventoryId).ValueGeneratedNever();

                entity.Property(e => e.Qty).HasColumnName("QTY");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Inventory)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductId_Inventory_ProductId");

                entity.HasOne(d => d.Store)
                    .WithMany(p => p.Inventory)
                    .HasForeignKey(d => d.StoreId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_StoreId_Inventory_StoreId");
            });

            modelBuilder.Entity<OrderList>(entity =>
            {
                entity.ToTable("OrderList", "pizza");

                entity.Property(e => e.OrderListId).ValueGeneratedNever();

                entity.Property(e => e.UnitPrice).HasColumnType("money");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderList)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK_OrderId_Order_PurOrder");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.OrderList)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK_ProductId_Product_ProductId");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Product", "pizza");

                entity.Property(e => e.ProductId).ValueGeneratedNever();

                entity.Property(e => e.Cost).HasColumnType("money");

                entity.Property(e => e.ProductName)
                    .IsRequired()
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<PurOrder>(entity =>
            {
                entity.HasKey(e => e.OrderId)
                    .HasName("PK__PurOrder__C3905BCFCB001AFE");

                entity.ToTable("PurOrder", "pizza");

                entity.Property(e => e.OrderDate).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Total).HasColumnType("money");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.PurOrder)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK_CustomerId_Customer_CustomerId");

                entity.HasOne(d => d.Store)
                    .WithMany(p => p.PurOrder)
                    .HasForeignKey(d => d.StoreId)
                    .HasConstraintName("FK_StoreId_Store_StoreId");
            });

            modelBuilder.Entity<Store>(entity =>
            {
                entity.ToTable("Store", "pizza");

                entity.Property(e => e.StoreId).ValueGeneratedNever();

                entity.Property(e => e.StoreLoc)
                    .IsRequired()
                    .HasMaxLength(20);
            });
        }
    }
}
