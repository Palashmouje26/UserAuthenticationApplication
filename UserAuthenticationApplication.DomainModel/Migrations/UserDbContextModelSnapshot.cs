﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using UserAuthenticationApplication.DomainModel.DbContexts;

namespace UserAuthenticationApplication.DomainModel.Migrations
{
    [DbContext(typeof(UserDbContext))]
    partial class UserDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("UserAuthenticationApplication.DomainModel.Models.UserRegistration.UserRegistration", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmailId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeletd")
                        .HasColumnType("bit");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("UserRegistration");
                });

            modelBuilder.Entity("UserAuthenticationApplication.Repository.Login.Login", b =>
                {
                    b.Property<int>("LoginId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsValidate")
                        .HasColumnType("bit");

                    b.Property<DateTime>("LoginHistory")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UserRagistrationUserId")
                        .HasColumnType("int");

                    b.HasKey("LoginId");

                    b.HasIndex("UserRagistrationUserId");

                    b.ToTable("Login");
                });

            modelBuilder.Entity("UserAuthenticationApplication.Repository.Login.Login", b =>
                {
                    b.HasOne("UserAuthenticationApplication.DomainModel.Models.UserRegistration.UserRegistration", "UserRagistration")
                        .WithMany()
                        .HasForeignKey("UserRagistrationUserId");
                });
#pragma warning restore 612, 618
        }
    }
}