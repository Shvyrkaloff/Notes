﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Notes.Persistence;

#nullable disable

namespace Notes.Persistence.Migrations
{
    [DbContext(typeof(NotesDbContext))]
    [Migration("20230430143943_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Notes.Application.Entities.Author.Domain.Author", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateUpdated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("RoleId")
                        .HasColumnType("int");

                    b.Property<string>("UserCreated")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("UserUpdated")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("Authors");
                });

            modelBuilder.Entity("Notes.Application.Entities.InformationSystem.Domain.InformationSystem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateUpdated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserCreated")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("UserUpdated")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.HasKey("Id");

                    b.ToTable("InformationSystems");
                });

            modelBuilder.Entity("Notes.Application.Entities.Priority.Domain.Priority", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Priorities");
                });

            modelBuilder.Entity("Notes.Application.Entities.Role.Domain.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("Notes.Application.Entities.Task.Domain.CatalogTask", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateUpdated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("InformationSystemId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int?>("PriorityId")
                        .HasColumnType("int");

                    b.Property<int?>("TaskAuthorId")
                        .HasColumnType("int");

                    b.Property<int?>("TaskExecutorId")
                        .HasColumnType("int");

                    b.Property<int?>("TaskStatusId")
                        .HasColumnType("int");

                    b.Property<string>("UserCreated")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("UserUpdated")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.HasKey("Id");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.HasIndex("InformationSystemId");

                    b.HasIndex("PriorityId");

                    b.HasIndex("TaskAuthorId");

                    b.HasIndex("TaskExecutorId");

                    b.HasIndex("TaskStatusId");

                    b.ToTable("CatalogTasks");
                });

            modelBuilder.Entity("Notes.Application.Entities.TaskStatus.Domain.TaskStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateUpdated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserCreated")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("UserUpdated")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.HasKey("Id");

                    b.ToTable("TaskStatuses");
                });

            modelBuilder.Entity("Notes.Application.Entities.Author.Domain.Author", b =>
                {
                    b.HasOne("Notes.Application.Entities.Role.Domain.Role", "Role")
                        .WithMany("Authors")
                        .HasForeignKey("RoleId");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("Notes.Application.Entities.Task.Domain.CatalogTask", b =>
                {
                    b.HasOne("Notes.Application.Entities.InformationSystem.Domain.InformationSystem", "InformationSystem")
                        .WithMany("Tasks")
                        .HasForeignKey("InformationSystemId");

                    b.HasOne("Notes.Application.Entities.Priority.Domain.Priority", "Priority")
                        .WithMany("Tasks")
                        .HasForeignKey("PriorityId");

                    b.HasOne("Notes.Application.Entities.Author.Domain.Author", "TaskAuthor")
                        .WithMany("AssignedTasks")
                        .HasForeignKey("TaskAuthorId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Notes.Application.Entities.Author.Domain.Author", "TaskExecutor")
                        .WithMany("ExecutableTasks")
                        .HasForeignKey("TaskExecutorId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Notes.Application.Entities.TaskStatus.Domain.TaskStatus", "TaskStatus")
                        .WithMany()
                        .HasForeignKey("TaskStatusId");

                    b.Navigation("InformationSystem");

                    b.Navigation("Priority");

                    b.Navigation("TaskAuthor");

                    b.Navigation("TaskExecutor");

                    b.Navigation("TaskStatus");
                });

            modelBuilder.Entity("Notes.Application.Entities.Author.Domain.Author", b =>
                {
                    b.Navigation("AssignedTasks");

                    b.Navigation("ExecutableTasks");
                });

            modelBuilder.Entity("Notes.Application.Entities.InformationSystem.Domain.InformationSystem", b =>
                {
                    b.Navigation("Tasks");
                });

            modelBuilder.Entity("Notes.Application.Entities.Priority.Domain.Priority", b =>
                {
                    b.Navigation("Tasks");
                });

            modelBuilder.Entity("Notes.Application.Entities.Role.Domain.Role", b =>
                {
                    b.Navigation("Authors");
                });
#pragma warning restore 612, 618
        }
    }
}