﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SchedulerModule.EfCoreSetUp;

namespace SchedulerModule.Migrations
{
    [DbContext(typeof(SchedulerModelDbContext))]
    partial class SchedulerModelDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SchedulerModule.Models.AppointmentDetails", b =>
                {
                    b.Property<int>("VisitId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("AppointmentEnddate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("AppointmentStartdate")
                        .HasColumnType("datetime2");

                    b.Property<int>("SlotId")
                        .HasColumnType("int");

                    b.Property<string>("VisitDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VisitTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("createdBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("createdOn")
                        .HasColumnType("datetime2");

                    b.Property<int>("doctorId")
                        .HasColumnType("int");

                    b.Property<int>("patientId")
                        .HasColumnType("int");

                    b.Property<int>("updatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("updatedOn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("visitDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("visitStatusId")
                        .HasColumnType("int");

                    b.HasKey("VisitId");

                    b.HasIndex("visitStatusId");

                    b.ToTable("appointmentDetails");
                });

            modelBuilder.Entity("SchedulerModule.Models.Slots", b =>
                {
                    b.Property<int>("SlotId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<TimeSpan>("SlotEnd")
                        .HasColumnType("time");

                    b.Property<TimeSpan>("SlotStart")
                        .HasColumnType("time");

                    b.Property<string>("SlotTiming")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SlotId");

                    b.ToTable("Slots");

                    b.HasData(
                        new
                        {
                            SlotId = 1,
                            SlotEnd = new TimeSpan(0, 11, 0, 0, 0),
                            SlotStart = new TimeSpan(0, 10, 0, 0, 0),
                            SlotTiming = "10AM - 11AM"
                        },
                        new
                        {
                            SlotId = 2,
                            SlotEnd = new TimeSpan(0, 12, 0, 0, 0),
                            SlotStart = new TimeSpan(0, 11, 0, 0, 0),
                            SlotTiming = "11 AM - 12 PM"
                        },
                        new
                        {
                            SlotId = 3,
                            SlotEnd = new TimeSpan(0, 13, 0, 0, 0),
                            SlotStart = new TimeSpan(0, 12, 0, 0, 0),
                            SlotTiming = "12 PM - 1 PM"
                        },
                        new
                        {
                            SlotId = 4,
                            SlotEnd = new TimeSpan(0, 14, 0, 0, 0),
                            SlotStart = new TimeSpan(0, 13, 0, 0, 0),
                            SlotTiming = "1 PM - 2PM"
                        },
                        new
                        {
                            SlotId = 5,
                            SlotEnd = new TimeSpan(0, 15, 0, 0, 0),
                            SlotStart = new TimeSpan(0, 14, 0, 0, 0),
                            SlotTiming = "2 PM - 3 PM"
                        },
                        new
                        {
                            SlotId = 6,
                            SlotEnd = new TimeSpan(0, 16, 0, 0, 0),
                            SlotStart = new TimeSpan(0, 15, 0, 0, 0),
                            SlotTiming = "3 PM - 4 PM"
                        },
                        new
                        {
                            SlotId = 7,
                            SlotEnd = new TimeSpan(0, 17, 0, 0, 0),
                            SlotStart = new TimeSpan(0, 16, 0, 0, 0),
                            SlotTiming = "4 PM - 5 PM"
                        });
                });

            modelBuilder.Entity("SchedulerModule.Models.VisitStatuses", b =>
                {
                    b.Property<int>("VisitStatusId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("VisitStatusName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("VisitStatusId");

                    b.ToTable("visitStatuses");
                });

            modelBuilder.Entity("SchedulerModule.Models.AppointmentDetails", b =>
                {
                    b.HasOne("SchedulerModule.Models.VisitStatuses", "visitStatuses")
                        .WithMany()
                        .HasForeignKey("visitStatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("visitStatuses");
                });
#pragma warning restore 612, 618
        }
    }
}
