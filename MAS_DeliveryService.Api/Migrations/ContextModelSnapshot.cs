﻿// <auto-generated />
using System;
using MAS_DeliveryService.Api.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MAS_DeliveryService.Api.Migrations
{
    [DbContext(typeof(Context))]
    partial class ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.6");

            modelBuilder.Entity("ItemOrder", b =>
                {
                    b.Property<Guid>("ItemsId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("OrdersId")
                        .HasColumnType("TEXT");

                    b.HasKey("ItemsId", "OrdersId");

                    b.HasIndex("OrdersId");

                    b.ToTable("ItemOrder");
                });

            modelBuilder.Entity("ItemPackage", b =>
                {
                    b.Property<Guid>("ItemsId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("PackagesId")
                        .HasColumnType("TEXT");

                    b.HasKey("ItemsId", "PackagesId");

                    b.HasIndex("PackagesId");

                    b.ToTable("ItemPackage");
                });

            modelBuilder.Entity("MAS_DeliveryService.Api.Domain.Client", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("PersonId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("PersonId");

                    b.ToTable("Client");
                });

            modelBuilder.Entity("MAS_DeliveryService.Api.Domain.Delivery", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("CourierId")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("DateFrom")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("DateTo")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("OrderId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("CourierId", "OrderId")
                        .IsUnique();

                    b.ToTable("Deliveries");
                });

            modelBuilder.Entity("MAS_DeliveryService.Api.Domain.DriversLicense", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Categories")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("CourierId")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateIssued")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CourierId");

                    b.ToTable("DriversLicenses");
                });

            modelBuilder.Entity("MAS_DeliveryService.Api.Domain.Item", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Weight")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("MAS_DeliveryService.Api.Domain.Order", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("ClientId")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("DeliveryId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Destination")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsCancelled")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Sender")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.HasIndex("DeliveryId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("MAS_DeliveryService.Api.Domain.Package", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Comment")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("DeliveredInId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("SentInId")
                        .HasColumnType("TEXT");

                    b.Property<string>("SerialNumber")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("DeliveredInId");

                    b.HasIndex("SentInId");

                    b.HasIndex("SerialNumber")
                        .IsUnique();

                    b.ToTable("Packages");
                });

            modelBuilder.Entity("MAS_DeliveryService.Api.Domain.Person", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("ClientId")
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("TEXT");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("WorkerId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.HasIndex("WorkerId");

                    b.ToTable("Person");
                });

            modelBuilder.Entity("MAS_DeliveryService.Api.Domain.Worker", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("TEXT");

                    b.Property<int>("Discriminator")
                        .HasColumnType("INTEGER");

                    b.Property<decimal?>("MonthlySalary")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("PersonId")
                        .HasColumnType("TEXT");

                    b.Property<decimal?>("SalaryPerHour")
                        .HasColumnType("TEXT");

                    b.Property<int?>("VacationDaysLeft")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("PersonId");

                    b.ToTable("Worker");

                    b.UseTptMappingStrategy();
                });

            modelBuilder.Entity("MAS_DeliveryService.Api.Domain.Courier", b =>
                {
                    b.HasBaseType("MAS_DeliveryService.Api.Domain.Worker");

                    b.Property<Guid>("DriversLicenseId")
                        .HasColumnType("TEXT");

                    b.HasIndex("DriversLicenseId");

                    b.ToTable("Courier");
                });

            modelBuilder.Entity("MAS_DeliveryService.Api.Domain.Manager", b =>
                {
                    b.HasBaseType("MAS_DeliveryService.Api.Domain.Worker");

                    b.Property<string>("Education")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.ToTable("Manager");
                });

            modelBuilder.Entity("ItemOrder", b =>
                {
                    b.HasOne("MAS_DeliveryService.Api.Domain.Item", null)
                        .WithMany()
                        .HasForeignKey("ItemsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MAS_DeliveryService.Api.Domain.Order", null)
                        .WithMany()
                        .HasForeignKey("OrdersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ItemPackage", b =>
                {
                    b.HasOne("MAS_DeliveryService.Api.Domain.Item", null)
                        .WithMany()
                        .HasForeignKey("ItemsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MAS_DeliveryService.Api.Domain.Package", null)
                        .WithMany()
                        .HasForeignKey("PackagesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MAS_DeliveryService.Api.Domain.Client", b =>
                {
                    b.HasOne("MAS_DeliveryService.Api.Domain.Person", "Person")
                        .WithMany()
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Person");
                });

            modelBuilder.Entity("MAS_DeliveryService.Api.Domain.Delivery", b =>
                {
                    b.HasOne("MAS_DeliveryService.Api.Domain.Courier", "Courier")
                        .WithMany("Deliveries")
                        .HasForeignKey("CourierId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MAS_DeliveryService.Api.Domain.Order", "Order")
                        .WithMany()
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Courier");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("MAS_DeliveryService.Api.Domain.DriversLicense", b =>
                {
                    b.HasOne("MAS_DeliveryService.Api.Domain.Courier", "Courier")
                        .WithMany()
                        .HasForeignKey("CourierId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Courier");
                });

            modelBuilder.Entity("MAS_DeliveryService.Api.Domain.Order", b =>
                {
                    b.HasOne("MAS_DeliveryService.Api.Domain.Client", "Client")
                        .WithMany("Orders")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MAS_DeliveryService.Api.Domain.Delivery", "Delivery")
                        .WithMany()
                        .HasForeignKey("DeliveryId");

                    b.Navigation("Client");

                    b.Navigation("Delivery");
                });

            modelBuilder.Entity("MAS_DeliveryService.Api.Domain.Package", b =>
                {
                    b.HasOne("MAS_DeliveryService.Api.Domain.Order", "DeliveredIn")
                        .WithMany("DeliveredIn")
                        .HasForeignKey("DeliveredInId");

                    b.HasOne("MAS_DeliveryService.Api.Domain.Order", "SentIn")
                        .WithMany("SentIn")
                        .HasForeignKey("SentInId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DeliveredIn");

                    b.Navigation("SentIn");
                });

            modelBuilder.Entity("MAS_DeliveryService.Api.Domain.Person", b =>
                {
                    b.HasOne("MAS_DeliveryService.Api.Domain.Client", "Client")
                        .WithMany()
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MAS_DeliveryService.Api.Domain.Worker", "Worker")
                        .WithMany()
                        .HasForeignKey("WorkerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");

                    b.Navigation("Worker");
                });

            modelBuilder.Entity("MAS_DeliveryService.Api.Domain.Worker", b =>
                {
                    b.HasOne("MAS_DeliveryService.Api.Domain.Person", "Person")
                        .WithMany()
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Person");
                });

            modelBuilder.Entity("MAS_DeliveryService.Api.Domain.Courier", b =>
                {
                    b.HasOne("MAS_DeliveryService.Api.Domain.DriversLicense", "DriversLicense")
                        .WithMany()
                        .HasForeignKey("DriversLicenseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MAS_DeliveryService.Api.Domain.Worker", null)
                        .WithOne()
                        .HasForeignKey("MAS_DeliveryService.Api.Domain.Courier", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DriversLicense");
                });

            modelBuilder.Entity("MAS_DeliveryService.Api.Domain.Manager", b =>
                {
                    b.HasOne("MAS_DeliveryService.Api.Domain.Worker", null)
                        .WithOne()
                        .HasForeignKey("MAS_DeliveryService.Api.Domain.Manager", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MAS_DeliveryService.Api.Domain.Client", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("MAS_DeliveryService.Api.Domain.Order", b =>
                {
                    b.Navigation("DeliveredIn");

                    b.Navigation("SentIn");
                });

            modelBuilder.Entity("MAS_DeliveryService.Api.Domain.Courier", b =>
                {
                    b.Navigation("Deliveries");
                });
#pragma warning restore 612, 618
        }
    }
}
