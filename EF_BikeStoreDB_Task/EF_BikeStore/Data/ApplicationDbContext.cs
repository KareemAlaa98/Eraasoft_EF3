using System;
using System.Collections.Generic;
using EF_BikeStore.Models;
using Microsoft.EntityFrameworkCore;

namespace EF_BikeStore.Data;

public partial class ApplicationDbContext : DbContext
{
    public ApplicationDbContext()
    {
    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Brand> Brands { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<NewView> NewViews { get; set; }

    public virtual DbSet<Notification> Notifications { get; set; }

    public virtual DbSet<Notificationss> Notificationsses { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderItem> OrderItems { get; set; }

    public virtual DbSet<OrderItemsLog> OrderItemsLogs { get; set; }

    public virtual DbSet<OrdersCompleted> OrdersCompleteds { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<SourceTable> SourceTables { get; set; }

    public virtual DbSet<Staff> Staffs { get; set; }

    public virtual DbSet<Stock> Stocks { get; set; }

    public virtual DbSet<Store> Stores { get; set; }

    public virtual DbSet<TargetTable> TargetTables { get; set; }

    public virtual DbSet<TestTable> TestTables { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=BikeStores;Integrated Security=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Brand>(entity =>
        {
            entity.HasKey(e => e.BrandId).HasName("PK__brands__5E5A8E275D52A9DA");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("PK__categori__D54EE9B423B2653B");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CustomerId).HasName("PK__customer__CD65CB8548C726A0");
        });

        modelBuilder.Entity<NewView>(entity =>
        {
            entity.ToView("new_view");
        });

        modelBuilder.Entity<Notification>(entity =>
        {
            entity.HasKey(e => e.NotificationId).HasName("PK__notifica__E059842F73F13C5B");
        });

        modelBuilder.Entity<Notificationss>(entity =>
        {
            entity.HasKey(e => e.NotificationId).HasName("PK__notifica__E059842FB99F943A");

            entity.ToTable("notificationss", "sales", tb => tb.HasTrigger("instead_of_update_delete"));
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("PK__orders__4659622946D5460F");

            entity.ToTable("orders", "sales", tb =>
                {
                    tb.HasTrigger("Notify_Insertion");
                    tb.HasTrigger("prevent_order_insertion");
                });

            entity.HasOne(d => d.Customer).WithMany(p => p.Orders)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__orders__customer__47DBAE45");

            entity.HasOne(d => d.Staff).WithMany(p => p.Orders)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__orders__staff_id__49C3F6B7");

            entity.HasOne(d => d.Store).WithMany(p => p.Orders).HasConstraintName("FK__orders__store_id__48CFD27E");
        });

        modelBuilder.Entity<OrderItem>(entity =>
        {
            entity.HasKey(e => new { e.OrderId, e.ItemId }).HasName("PK__order_it__837942D48C8FE9CE");

            entity.ToTable("order_items", "sales", tb => tb.HasTrigger("trg_insert_order_items"));

            entity.HasOne(d => d.Order).WithMany(p => p.OrderItems).HasConstraintName("FK__order_ite__order__4D94879B");

            entity.HasOne(d => d.Product).WithMany(p => p.OrderItems).HasConstraintName("FK__order_ite__produ__4E88ABD4");
        });

        modelBuilder.Entity<OrderItemsLog>(entity =>
        {
            entity.HasKey(e => e.LogId).HasName("PK__order_it__9E2397E0227914B3");
        });

        modelBuilder.Entity<OrdersCompleted>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("PK__orders_c__4659622978B48734");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PK__products__47027DF5E6AA2E75");

            entity.HasOne(d => d.Brand).WithMany(p => p.Products).HasConstraintName("FK__products__brand___3C69FB99");

            entity.HasOne(d => d.Category).WithMany(p => p.Products).HasConstraintName("FK__products__catego__3B75D760");
        });

        modelBuilder.Entity<SourceTable>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__source_t__3213E83FB2C7F5ED");

            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<Staff>(entity =>
        {
            entity.HasKey(e => e.StaffId).HasName("PK__staffs__1963DD9CDA7555AD");

            entity.HasOne(d => d.Manager).WithMany(p => p.InverseManager).HasConstraintName("FK__staffs__manager___44FF419A");

            entity.HasOne(d => d.Store).WithMany(p => p.Staff).HasConstraintName("FK__staffs__store_id__440B1D61");
        });

        modelBuilder.Entity<Stock>(entity =>
        {
            entity.HasKey(e => new { e.StoreId, e.ProductId }).HasName("PK__stocks__E68284D32DEE7F75");

            entity.HasOne(d => d.Product).WithMany(p => p.Stocks).HasConstraintName("FK__stocks__product___52593CB8");

            entity.HasOne(d => d.Store).WithMany(p => p.Stocks).HasConstraintName("FK__stocks__store_id__5165187F");
        });

        modelBuilder.Entity<Store>(entity =>
        {
            entity.HasKey(e => e.StoreId).HasName("PK__stores__A2F2A30CFF79FDD8");
        });

        modelBuilder.Entity<TargetTable>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__target_t__3213E83F5FE23526");

            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<TestTable>(entity =>
        {
            entity.HasKey(e => e.TestId).HasName("PK__test_tab__F3FF1C021BB1443F");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
