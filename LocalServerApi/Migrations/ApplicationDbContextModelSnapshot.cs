﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace IdentityService.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("IdentityService.DataBase.Key", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("AuthorizationKey")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("Expire")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("GuidId")
                        .HasColumnType("uuid");

                    b.Property<int>("UserRegisterDataId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("UserRegisterDataId");

                    b.ToTable("Keys");
                });

            modelBuilder.Entity("IdentityService.DataBase.UserLoginData", b =>
                {
                    b.Property<int>("IdLogin")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("IdLogin"));

                    b.Property<string>("ClientId")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)");

                    b.Property<string>("ResponseType")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<int>("UserRegisterDataId")
                        .HasColumnType("integer");

                    b.HasKey("IdLogin");

                    b.HasIndex("UserRegisterDataId");

                    b.ToTable("UserLoginData");
                });

            modelBuilder.Entity("IdentityService.DataBase.UserRegisterData", b =>
                {
                    b.Property<int>("IdRegister")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("IdRegister"));

                    b.Property<string>("ClientId")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("CodeChallenge")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.Property<string>("CodeChallengeMethod")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<string>("Firstname")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("Lastname")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)");

                    b.Property<string>("RedirectUri")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.Property<string>("ResponseType")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("Scope")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("IdRegister");

                    b.ToTable("UserRegisterData");
                });

            modelBuilder.Entity("IdentityService.DataBase.Key", b =>
                {
                    b.HasOne("IdentityService.DataBase.UserRegisterData", "UserRegisterData")
                        .WithMany("Keys")
                        .HasForeignKey("UserRegisterDataId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserRegisterData");
                });

            modelBuilder.Entity("IdentityService.DataBase.UserLoginData", b =>
                {
                    b.HasOne("IdentityService.DataBase.UserRegisterData", "UserRegisterData")
                        .WithMany("Userlogindata")
                        .HasForeignKey("UserRegisterDataId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserRegisterData");
                });

            modelBuilder.Entity("IdentityService.DataBase.UserRegisterData", b =>
                {
                    b.Navigation("Keys");

                    b.Navigation("Userlogindata");
                });
#pragma warning restore 612, 618
        }
    }
}
