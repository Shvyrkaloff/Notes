﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Notes.Persistence;

#nullable disable

namespace Notes.Persistence.Migrations
{
    [DbContext(typeof(NotesDbContext))]
    partial class NotesDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "First developer",
                            RoleId = 1
                        },
                        new
                        {
                            Id = 2,
                            Name = "Second developer",
                            RoleId = 1
                        },
                        new
                        {
                            Id = 3,
                            Name = "First analyst",
                            RoleId = 2
                        },
                        new
                        {
                            Id = 4,
                            Name = "Second analyst",
                            RoleId = 2
                        },
                        new
                        {
                            Id = 5,
                            Name = "First support",
                            RoleId = 3
                        },
                        new
                        {
                            Id = 6,
                            Name = "Second support",
                            RoleId = 3
                        },
                        new
                        {
                            Id = 7,
                            Name = "First tester",
                            RoleId = 4
                        },
                        new
                        {
                            Id = 8,
                            Name = "Second tester",
                            RoleId = 4
                        });
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

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "The main information system"
                        });
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

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "The highest"
                        },
                        new
                        {
                            Id = 2,
                            Name = "High"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Medium"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Low"
                        });
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

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Developer"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Analyst"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Support"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Tester"
                        });
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

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Awaiting execution"
                        },
                        new
                        {
                            Id = 2,
                            Name = "At work"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Awaiting verification"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Done"
                        });
                });

            modelBuilder.Entity("Notes.Application.Entities.User.Domain.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AuthorId")
                        .HasColumnType("int");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AuthorId = 1,
                            Password = "user1",
                            Username = "user1"
                        },
                        new
                        {
                            Id = 2,
                            AuthorId = 2,
                            Password = "user2",
                            Username = "user2"
                        },
                        new
                        {
                            Id = 3,
                            AuthorId = 3,
                            Password = "user3",
                            Username = "user3"
                        },
                        new
                        {
                            Id = 4,
                            AuthorId = 4,
                            Password = "user4",
                            Username = "user4"
                        },
                        new
                        {
                            Id = 5,
                            AuthorId = 5,
                            Password = "user5",
                            Username = "user5"
                        },
                        new
                        {
                            Id = 6,
                            AuthorId = 6,
                            Password = "user6",
                            Username = "user6"
                        },
                        new
                        {
                            Id = 7,
                            AuthorId = 7,
                            Password = "user7",
                            Username = "user7"
                        },
                        new
                        {
                            Id = 8,
                            AuthorId = 8,
                            Password = "user8",
                            Username = "user8"
                        });
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

            modelBuilder.Entity("Notes.Application.Entities.User.Domain.User", b =>
                {
                    b.HasOne("Notes.Application.Entities.Author.Domain.Author", "Author")
                        .WithMany()
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");
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
