﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ShoppingCartApp.Models.Models;

namespace ShoppingCartApp.Models.Migrations
{
    [DbContext(typeof(ShoppingCartDBContext))]
    [Migration("20211123043518_Added FK in Answers")]
    partial class AddedFKinAnswers
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ShoppingCartApp.Models.Models.Roles", b =>
                {
                    b.Property<int>("PKRoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasColumnType("VARCHAR(200)")
                        .HasMaxLength(200);

                    b.HasKey("PKRoleId");

                    b.ToTable("Role","User");
                });

            modelBuilder.Entity("ShoppingCartApp.Models.Models.SecurityAnswers", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Answers")
                        .IsRequired()
                        .HasColumnType("VARCHAR(500)");

                    b.Property<string>("FKQuestionId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("FKQuestionId");

                    b.ToTable("SecurityAnswers","User");
                });

            modelBuilder.Entity("ShoppingCartApp.Models.Models.SecurityQuestions", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<string>("Questions")
                        .IsRequired()
                        .HasColumnType("VARCHAR(500)");

                    b.HasKey("Id");

                    b.ToTable("SecurityQuestions","User");
                });

            modelBuilder.Entity("ShoppingCartApp.Models.Models.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("VARCHAR(500)");

                    b.Property<string>("EmailId")
                        .IsRequired()
                        .HasColumnType("VARCHAR(200)");

                    b.Property<string>("FKQuestionId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("FKRoleId")
                        .HasColumnType("int");

                    b.Property<string>("IPAddress")
                        .IsRequired()
                        .HasColumnType("VARCHAR(500)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("VARCHAR(50)");

                    b.Property<string>("PhoneNo")
                        .IsRequired()
                        .HasColumnType("VARCHAR(200)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("VARCHAR(200)");

                    b.HasKey("Id");

                    b.HasIndex("FKQuestionId");

                    b.HasIndex("FKRoleId");

                    b.ToTable("User","User");
                });

            modelBuilder.Entity("ShoppingCartApp.Models.Models.SecurityAnswers", b =>
                {
                    b.HasOne("ShoppingCartApp.Models.Models.SecurityQuestions", "SecurityQuestions")
                        .WithMany()
                        .HasForeignKey("FKQuestionId");
                });

            modelBuilder.Entity("ShoppingCartApp.Models.Models.User", b =>
                {
                    b.HasOne("ShoppingCartApp.Models.Models.SecurityQuestions", "SecurityQuestions")
                        .WithMany()
                        .HasForeignKey("FKQuestionId");

                    b.HasOne("ShoppingCartApp.Models.Models.Roles", "Roles")
                        .WithMany()
                        .HasForeignKey("FKRoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
