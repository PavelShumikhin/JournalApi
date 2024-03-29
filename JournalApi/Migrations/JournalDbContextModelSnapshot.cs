﻿// <auto-generated />
using System;
using JournalApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace JournalApi.Migrations
{
    [DbContext(typeof(JournalDbContext))]
    partial class JournalDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("JournalApi.Model.Entitys.Access.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("UsersGroupId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("UsersGroupId");

                    b.ToTable("Users", (string)null);
                });

            modelBuilder.Entity("JournalApi.Model.Entitys.Access.UsersGroup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("GroupName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("UsersGroups", (string)null);
                });

            modelBuilder.Entity("JournalApi.Model.Entitys.Journal.StudyGrade", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Grade")
                        .HasColumnType("integer");

                    b.Property<int>("StudyOccupationId")
                        .HasColumnType("integer");

                    b.Property<int>("StudyStudentId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("StudyGrade", (string)null);
                });

            modelBuilder.Entity("JournalApi.Model.Entitys.Journal.StudyGroup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("StudyGroup", (string)null);
                });

            modelBuilder.Entity("JournalApi.Model.Entitys.Journal.StudyOccupation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("StudyGroupId")
                        .HasColumnType("integer");

                    b.Property<int>("StudySubjectId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("TimeOccupation")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("StudyGroupId");

                    b.HasIndex("StudySubjectId");

                    b.ToTable("StudyOccupation", (string)null);
                });

            modelBuilder.Entity("JournalApi.Model.Entitys.Journal.StudyStudent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("SecondName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("StudyGroupId")
                        .HasColumnType("integer");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("StudyGroupId");

                    b.HasIndex("UserId");

                    b.ToTable("StudyStudent", (string)null);
                });

            modelBuilder.Entity("JournalApi.Model.Entitys.Journal.StudySubject", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("StudySubject", (string)null);
                });

            modelBuilder.Entity("JournalApi.Model.Entitys.Access.User", b =>
                {
                    b.HasOne("JournalApi.Model.Entitys.Access.UsersGroup", "UsersGroup")
                        .WithMany("Users")
                        .HasForeignKey("UsersGroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UsersGroup");
                });

            modelBuilder.Entity("JournalApi.Model.Entitys.Journal.StudyOccupation", b =>
                {
                    b.HasOne("JournalApi.Model.Entitys.Journal.StudyGroup", "StudyGroup")
                        .WithMany()
                        .HasForeignKey("StudyGroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("JournalApi.Model.Entitys.Journal.StudySubject", "StudySubject")
                        .WithMany()
                        .HasForeignKey("StudySubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("StudyGroup");

                    b.Navigation("StudySubject");
                });

            modelBuilder.Entity("JournalApi.Model.Entitys.Journal.StudyStudent", b =>
                {
                    b.HasOne("JournalApi.Model.Entitys.Journal.StudyGroup", "StudyGroup")
                        .WithMany()
                        .HasForeignKey("StudyGroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("JournalApi.Model.Entitys.Access.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("StudyGroup");

                    b.Navigation("User");
                });

            modelBuilder.Entity("JournalApi.Model.Entitys.Access.UsersGroup", b =>
                {
                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
