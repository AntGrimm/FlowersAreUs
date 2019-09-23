﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using flowersareus;

namespace flowersareus.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20190923013446_ChangedPhoneNumberToString")]
    partial class ChangedPhoneNumberToString
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.2.0-rtm-35687")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("FlowersAreUs.Models.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateOrdered");

                    b.Property<int>("LocationId");

                    b.Property<int?>("LocationsId");

                    b.Property<string>("Name");

                    b.Property<int>("NumberInStock");

                    b.Property<double>("Price");

                    b.Property<string>("ShortDescription");

                    b.Property<int>("Sku");

                    b.HasKey("Id");

                    b.HasIndex("LocationsId");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("FlowersAreUs.Models.Locations", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<string>("ManagerName");

                    b.Property<string>("PhoneNumber");

                    b.HasKey("Id");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("FlowersAreUs.Models.Item", b =>
                {
                    b.HasOne("FlowersAreUs.Models.Locations", "Locations")
                        .WithMany("Items")
                        .HasForeignKey("LocationsId");
                });
#pragma warning restore 612, 618
        }
    }
}