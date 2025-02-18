﻿// <auto-generated />
using System;
using CoffeeShopMVC.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CoffeeShopMVC.Migrations
{
    [DbContext(typeof(CoffeeShopMVCContext))]
    partial class CoffeeShopMVCContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("CoffeeShopMVC.Models.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("email");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("pk_customers");

                    b.ToTable("customers", (string)null);
                });

            modelBuilder.Entity("CoffeeShopMVC.Models.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<int?>("OrderId")
                        .HasColumnType("integer")
                        .HasColumnName("order_id");

                    b.Property<int>("PriceInCents")
                        .HasColumnType("integer")
                        .HasColumnName("price_in_cents");

                    b.HasKey("Id")
                        .HasName("pk_items");

                    b.HasIndex("OrderId")
                        .HasDatabaseName("ix_items_order_id");

                    b.ToTable("items", (string)null);
                });

            modelBuilder.Entity("CoffeeShopMVC.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("DateCreated")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("date_created");

                    b.Property<int>("OrderCustomerId")
                        .HasColumnType("integer")
                        .HasColumnName("order_customer_id");

                    b.HasKey("Id")
                        .HasName("pk_orders");

                    b.HasIndex("OrderCustomerId")
                        .HasDatabaseName("ix_orders_order_customer_id");

                    b.ToTable("orders", (string)null);
                });

            modelBuilder.Entity("CoffeeShopMVC.Models.Item", b =>
                {
                    b.HasOne("CoffeeShopMVC.Models.Order", "Order")
                        .WithMany("ListOfItems")
                        .HasForeignKey("OrderId")
                        .HasConstraintName("fk_items_orders_order_id");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("CoffeeShopMVC.Models.Order", b =>
                {
                    b.HasOne("CoffeeShopMVC.Models.Customer", "OrderCustomer")
                        .WithMany("Orders")
                        .HasForeignKey("OrderCustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_orders_customers_order_customer_id");

                    b.Navigation("OrderCustomer");
                });

            modelBuilder.Entity("CoffeeShopMVC.Models.Customer", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("CoffeeShopMVC.Models.Order", b =>
                {
                    b.Navigation("ListOfItems");
                });
#pragma warning restore 612, 618
        }
    }
}
