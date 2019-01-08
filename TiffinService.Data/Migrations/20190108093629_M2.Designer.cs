﻿// <auto-generated />
using System;
using AngularPOC.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AngularPOC.Data.Migrations
{
    [DbContext(typeof(AngularPOCDbContext))]
    [Migration("20190108093629_M2")]
    partial class M2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AngularPOC.Entities.CityMaster", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CityName");

                    b.Property<int>("StateId");

                    b.HasKey("Id");

                    b.HasIndex("StateId");

                    b.ToTable("CityMaster");
                });

            modelBuilder.Entity("AngularPOC.Entities.CountryMaster", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CountryName");

                    b.HasKey("Id");

                    b.ToTable("CountryMaster");
                });

            modelBuilder.Entity("AngularPOC.Entities.StateMaster", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CountryId");

                    b.Property<string>("StateName");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("StateMaster");
                });

            modelBuilder.Entity("AngularPOC.Entities.UserMaster", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address");

                    b.Property<int?>("CityId");

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<byte>("Gender");

                    b.Property<string>("Hobbies");

                    b.Property<string>("IsDocsSubmited");

                    b.Property<bool>("IsVerified");

                    b.Property<string>("LastName");

                    b.Property<string>("Password");

                    b.Property<string>("UserName");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.ToTable("UserMaster");
                });

            modelBuilder.Entity("AngularPOC.Entities.CityMaster", b =>
                {
                    b.HasOne("AngularPOC.Entities.StateMaster", "State")
                        .WithMany("Cities")
                        .HasForeignKey("StateId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AngularPOC.Entities.StateMaster", b =>
                {
                    b.HasOne("AngularPOC.Entities.CountryMaster", "Country")
                        .WithMany("States")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AngularPOC.Entities.UserMaster", b =>
                {
                    b.HasOne("AngularPOC.Entities.CityMaster", "City")
                        .WithMany()
                        .HasForeignKey("CityId");
                });
#pragma warning restore 612, 618
        }
    }
}
