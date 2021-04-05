﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OrderPlacementSystem.Models.OrderPlacementSystemDB;

namespace OrderPlacementSystem.Migrations
{
    [DbContext(typeof(OrderPlacementSystemContext))]
    partial class OrderPlacementSystemContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("OrderPlacementSystem.Models.OrderPlacementSystemDB.Order_Service", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("creationDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("executeServiceDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("orderId")
                        .HasColumnType("int");

                    b.Property<int>("serviceId")
                        .HasColumnType("int");

                    b.Property<DateTime>("updatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("id");

                    b.HasIndex("orderId");

                    b.HasIndex("serviceId");

                    b.ToTable("Order_Service");
                });

            modelBuilder.Entity("OrderPlacementSystem.Models.OrderPlacementSystemDB.Orders", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("addressFrom")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("addressTo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("creationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("notes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("phoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("updatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("id");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("OrderPlacementSystem.Models.OrderPlacementSystemDB.Services", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Services");

                    b.HasData(
                        new
                        {
                            id = 1,
                            name = "Moving"
                        },
                        new
                        {
                            id = 2,
                            name = "Packing"
                        },
                        new
                        {
                            id = 3,
                            name = "Cleaning"
                        });
                });

            modelBuilder.Entity("OrderPlacementSystem.Models.OrderPlacementSystemDB.Order_Service", b =>
                {
                    b.HasOne("OrderPlacementSystem.Models.OrderPlacementSystemDB.Orders", "Order")
                        .WithMany("Order_Services")
                        .HasForeignKey("orderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OrderPlacementSystem.Models.OrderPlacementSystemDB.Services", "Service")
                        .WithMany()
                        .HasForeignKey("serviceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
