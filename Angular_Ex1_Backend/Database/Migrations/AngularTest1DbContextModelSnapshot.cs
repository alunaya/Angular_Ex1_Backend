﻿// <auto-generated />
using System;
using Angular_Ex1_Backend.Database.CodeFirst;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Angular_Ex1_Backend.Database.Migrations
{
    [DbContext(typeof(AngularTest1DbContext))]
    partial class AngularTest1DbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("Angular_Ex1_Backend.Database.CodeFirst.Months", b =>
                {
                    b.Property<Guid>("MonthId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime");

                    b.HasKey("MonthId");

                    b.ToTable("Months");
                });

            modelBuilder.Entity("Angular_Ex1_Backend.Database.CodeFirst.ReservationCoverage", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<string>("InstanceType")
                        .HasColumnType("longtext");

                    b.Property<Guid?>("MonthsMonthId")
                        .HasColumnType("char(36)");

                    b.Property<float>("ReservedHours")
                        .HasColumnType("float");

                    b.Property<float>("TotalHours")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("MonthsMonthId");

                    b.ToTable("ReservationCoverages");
                });

            modelBuilder.Entity("Angular_Ex1_Backend.Database.CodeFirst.ServicesBill", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<decimal>("Bill")
                        .HasColumnType("decimal(65,30)");

                    b.Property<Guid?>("MonthsMonthId")
                        .HasColumnType("char(36)");

                    b.Property<string>("ServicesName")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("MonthsMonthId");

                    b.ToTable("ServicesBill");
                });

            modelBuilder.Entity("Angular_Ex1_Backend.Database.CodeFirst.ReservationCoverage", b =>
                {
                    b.HasOne("Angular_Ex1_Backend.Database.CodeFirst.Months", "Months")
                        .WithMany("ReservationCoverages")
                        .HasForeignKey("MonthsMonthId");

                    b.Navigation("Months");
                });

            modelBuilder.Entity("Angular_Ex1_Backend.Database.CodeFirst.ServicesBill", b =>
                {
                    b.HasOne("Angular_Ex1_Backend.Database.CodeFirst.Months", "Months")
                        .WithMany("ServicesBills")
                        .HasForeignKey("MonthsMonthId");

                    b.Navigation("Months");
                });

            modelBuilder.Entity("Angular_Ex1_Backend.Database.CodeFirst.Months", b =>
                {
                    b.Navigation("ReservationCoverages");

                    b.Navigation("ServicesBills");
                });
#pragma warning restore 612, 618
        }
    }
}
