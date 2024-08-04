﻿// <auto-generated />
using System;
using GradeBookMicroservice.Infrastructure.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace GradeBookMicroservice.Infrastructure.EntityFramework.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240804002150_Grades")]
    partial class Grades
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("GradeBookMicroservice.Domain.Entities.Grade", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("GradedTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("Mark")
                        .HasColumnType("integer");

                    b.Property<Guid?>("StudentId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("StudentId1")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("TeacherId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("TeacherId1")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("StudentId");

                    b.HasIndex("StudentId1");

                    b.HasIndex("TeacherId");

                    b.HasIndex("TeacherId1");

                    b.ToTable("Grades");
                });

            modelBuilder.Entity("GradeBookMicroservice.Domain.Entities.Group", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("character varying(10)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Groups");
                });

            modelBuilder.Entity("GradeBookMicroservice.Domain.Entities.Lesson", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("ClassTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("GroupId")
                        .HasColumnType("uuid");

                    b.Property<int>("State")
                        .HasColumnType("integer");

                    b.Property<Guid>("TeacherId2")
                        .HasColumnType("uuid");

                    b.Property<string>("Topic")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("Id");

                    b.HasIndex("GroupId");

                    b.HasIndex("TeacherId2");

                    b.ToTable("Lessons");
                });

            modelBuilder.Entity("GradeBookMicroservice.Domain.Entities.Student", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("GroupId")
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("Id");

                    b.HasIndex("GroupId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("GradeBookMicroservice.Domain.Entities.Teacher", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("Id");

                    b.ToTable("Teachers");
                });

            modelBuilder.Entity("LessonStudent", b =>
                {
                    b.Property<Guid>("StudentId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("_lessonsId")
                        .HasColumnType("uuid");

                    b.HasKey("StudentId", "_lessonsId");

                    b.HasIndex("_lessonsId");

                    b.ToTable("LessonStudent");
                });

            modelBuilder.Entity("GradeBookMicroservice.Domain.Entities.Grade", b =>
                {
                    b.HasOne("GradeBookMicroservice.Domain.Entities.Student", null)
                        .WithMany("RecievedGrades")
                        .HasForeignKey("StudentId");

                    b.HasOne("GradeBookMicroservice.Domain.Entities.Student", "Student")
                        .WithMany("_grades")
                        .HasForeignKey("StudentId1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GradeBookMicroservice.Domain.Entities.Teacher", null)
                        .WithMany("AssignedGrades")
                        .HasForeignKey("TeacherId");

                    b.HasOne("GradeBookMicroservice.Domain.Entities.Teacher", "Teacher")
                        .WithMany("_grades")
                        .HasForeignKey("TeacherId1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Student");

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("GradeBookMicroservice.Domain.Entities.Lesson", b =>
                {
                    b.HasOne("GradeBookMicroservice.Domain.Entities.Group", "Group")
                        .WithMany()
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GradeBookMicroservice.Domain.Entities.Teacher", "Teacher")
                        .WithMany("_lessons")
                        .HasForeignKey("TeacherId2")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Group");

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("GradeBookMicroservice.Domain.Entities.Student", b =>
                {
                    b.HasOne("GradeBookMicroservice.Domain.Entities.Group", "Group")
                        .WithMany("Students")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Group");
                });

            modelBuilder.Entity("LessonStudent", b =>
                {
                    b.HasOne("GradeBookMicroservice.Domain.Entities.Student", null)
                        .WithMany()
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GradeBookMicroservice.Domain.Entities.Lesson", null)
                        .WithMany()
                        .HasForeignKey("_lessonsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GradeBookMicroservice.Domain.Entities.Group", b =>
                {
                    b.Navigation("Students");
                });

            modelBuilder.Entity("GradeBookMicroservice.Domain.Entities.Student", b =>
                {
                    b.Navigation("RecievedGrades");

                    b.Navigation("_grades");
                });

            modelBuilder.Entity("GradeBookMicroservice.Domain.Entities.Teacher", b =>
                {
                    b.Navigation("AssignedGrades");

                    b.Navigation("_grades");

                    b.Navigation("_lessons");
                });
#pragma warning restore 612, 618
        }
    }
}
