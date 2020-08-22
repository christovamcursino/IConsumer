﻿// <auto-generated />
using System;
using IConsumer.Microservices.OrderMicroservice.Infra.DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace IConsumer.Microservices.OrderMicroservice.Infra.DataAccess.Migrations
{
    [DbContext(typeof(OrderContext))]
    partial class OrderContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("Order")
                .HasAnnotation("ProductVersion", "3.1.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("IConsumer.Microservices.OrderMicroservice.Domain.AggregatesModel.OrderAggregate.Order", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CustomerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("OrderStatusId")
                        .HasColumnType("int");

                    b.Property<bool>("PaymentApproved")
                        .HasColumnType("bit");

                    b.Property<string>("PaymentId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("TableId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("OrderStatusId");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("IConsumer.Microservices.OrderMicroservice.Domain.AggregatesModel.OrderAggregate.OrderItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<Guid>("OrderId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ProductName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderItem");
                });

            modelBuilder.Entity("IConsumer.Microservices.OrderMicroservice.Domain.AggregatesModel.OrderAggregate.OrderStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StatusId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("OrderStatus");
                });

            modelBuilder.Entity("IConsumer.Microservices.OrderMicroservice.Domain.AggregatesModel.OrderAggregate.OrderTracking", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("OrderId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("OrderStatusId")
                        .HasColumnType("int");

                    b.Property<DateTime>("TrackingDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("OrderStatusId");

                    b.ToTable("OrderTracking");
                });

            modelBuilder.Entity("IConsumer.Microservices.OrderMicroservice.Domain.AggregatesModel.OrderAggregate.Order", b =>
                {
                    b.HasOne("IConsumer.Microservices.OrderMicroservice.Domain.AggregatesModel.OrderAggregate.OrderStatus", "OrderStatus")
                        .WithMany()
                        .HasForeignKey("OrderStatusId");
                });

            modelBuilder.Entity("IConsumer.Microservices.OrderMicroservice.Domain.AggregatesModel.OrderAggregate.OrderItem", b =>
                {
                    b.HasOne("IConsumer.Microservices.OrderMicroservice.Domain.AggregatesModel.OrderAggregate.Order", "Order")
                        .WithMany("OrderItens")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("IConsumer.Microservices.OrderMicroservice.Domain.AggregatesModel.OrderAggregate.OrderTracking", b =>
                {
                    b.HasOne("IConsumer.Microservices.OrderMicroservice.Domain.AggregatesModel.OrderAggregate.Order", "Order")
                        .WithMany("TrackingHistory")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("IConsumer.Microservices.OrderMicroservice.Domain.AggregatesModel.OrderAggregate.OrderStatus", "OrderStatus")
                        .WithMany()
                        .HasForeignKey("OrderStatusId");
                });
#pragma warning restore 612, 618
        }
    }
}
