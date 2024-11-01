﻿// <auto-generated />
using System;
using AgizVeDisSagligi.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AgizVeDisSagligi.Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20241031064909_yeni")]
    partial class yeni
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AgizVeDisSagligi.Entity.Entites.Goal", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Frequency")
                        .HasColumnType("int");

                    b.Property<string>("HedefAdi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Periot")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PeriotLevel")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Goals");
                });

            modelBuilder.Entity("AgizVeDisSagligi.Entity.Entites.Situation", b =>
                {
                    b.Property<Guid>("SituationID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("GoalId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("HedefAdi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SituationName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("SituationID");

                    b.HasIndex("GoalId");

                    b.HasIndex("UserId");

                    b.ToTable("Situations");
                });

            modelBuilder.Entity("AgizVeDisSagligi.Entity.Entites.User", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateOnly>("BirthDate")
                        .HasColumnType("date");

                    b.Property<int?>("ConfirmCode")
                        .HasColumnType("int");

                    b.Property<string>("Mail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Passaword")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SurName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("AgizVeDisSagligi.Entity.Entites.Goal", b =>
                {
                    b.HasOne("AgizVeDisSagligi.Entity.Entites.User", "User")
                        .WithMany("Goals")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("User");
                });

            modelBuilder.Entity("AgizVeDisSagligi.Entity.Entites.Situation", b =>
                {
                    b.HasOne("AgizVeDisSagligi.Entity.Entites.Goal", "Goal")
                        .WithMany("Situationes")
                        .HasForeignKey("GoalId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AgizVeDisSagligi.Entity.Entites.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("Goal");

                    b.Navigation("User");
                });

            modelBuilder.Entity("AgizVeDisSagligi.Entity.Entites.Goal", b =>
                {
                    b.Navigation("Situationes");
                });

            modelBuilder.Entity("AgizVeDisSagligi.Entity.Entites.User", b =>
                {
                    b.Navigation("Goals");
                });
#pragma warning restore 612, 618
        }
    }
}