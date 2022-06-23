﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using UserManagementModule.Data;

#nullable disable

namespace UserManagementModule.Data.Migrations
{
    [DbContext(typeof(UserManagementDbContext))]
    partial class UserManagementDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("UserManagementModule.Domain.model.AccessRule", b =>
                {
                    b.Property<int>("AccessRuleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AccessRuleId"), 1L, 1);

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Permission")
                        .HasColumnType("bit");

                    b.Property<string>("RuleName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AccessRuleId");

                    b.ToTable("AccessRule");

                    b.HasData(
                        new
                        {
                            AccessRuleId = 1,
                            CreatedBy = "NUWANW",
                            CreatedDate = new DateTime(2022, 6, 23, 8, 53, 34, 544, DateTimeKind.Local).AddTicks(6115),
                            Permission = true,
                            RuleName = "CUSTOMER_PROFILE_ACCESS"
                        });
                });

            modelBuilder.Entity("UserManagementModule.Domain.model.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Person");
                });

            modelBuilder.Entity("UserManagementModule.Domain.model.UserGroup", b =>
                {
                    b.Property<int>("UserGroupId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserGroupId"), 1L, 1);

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("GroupName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("UserGroupId");

                    b.ToTable("UserGroup");

                    b.HasData(
                        new
                        {
                            UserGroupId = 1,
                            CreatedBy = "NUWANW",
                            CreatedDate = new DateTime(2022, 6, 23, 8, 53, 34, 544, DateTimeKind.Local).AddTicks(6061),
                            GroupName = "FRONTDESK"
                        },
                        new
                        {
                            UserGroupId = 2,
                            CreatedBy = "NUWANW",
                            CreatedDate = new DateTime(2022, 6, 23, 8, 53, 34, 544, DateTimeKind.Local).AddTicks(6063),
                            GroupName = "RECEPTIONIST"
                        });
                });

            modelBuilder.Entity("UserManagementModule.Domain.model.UserGroupRuleAssignment", b =>
                {
                    b.Property<int>("UserGroupId")
                        .HasColumnType("int");

                    b.Property<int>("AccessRuleId")
                        .HasColumnType("int");

                    b.HasKey("UserGroupId", "AccessRuleId");

                    b.HasIndex("AccessRuleId");

                    b.ToTable("UserGroupRuleAssignment");

                    b.HasData(
                        new
                        {
                            UserGroupId = 1,
                            AccessRuleId = 1
                        },
                        new
                        {
                            UserGroupId = 2,
                            AccessRuleId = 1
                        });
                });

            modelBuilder.Entity("UserManagementModule.Domain.model.Administrator", b =>
                {
                    b.HasBaseType("UserManagementModule.Domain.model.Person");

                    b.Property<string>("Privilege")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("Administrator", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedBy = "NUWANW",
                            CreatedDate = new DateTime(2022, 6, 23, 8, 53, 34, 544, DateTimeKind.Local).AddTicks(5887),
                            Email = "JOHN@GMAIL.COM",
                            FirstName = "JOHN",
                            LastName = "DOE",
                            Privilege = "ADMINISTRATOR"
                        });
                });

            modelBuilder.Entity("UserManagementModule.Domain.model.SystemUser", b =>
                {
                    b.HasBaseType("UserManagementModule.Domain.model.Person");

                    b.Property<string>("AttachedCustomerId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserGroupId")
                        .HasColumnType("int");

                    b.HasIndex("UserGroupId");

                    b.ToTable("SystemUser", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 2,
                            CreatedBy = "NUWANW",
                            CreatedDate = new DateTime(2022, 6, 23, 8, 53, 34, 544, DateTimeKind.Local).AddTicks(6007),
                            Email = "SMITH@GMAIL.COM",
                            FirstName = "GEORGE",
                            LastName = "SMITH",
                            AttachedCustomerId = "100001",
                            UserGroupId = 1
                        });
                });

            modelBuilder.Entity("UserManagementModule.Domain.model.UserGroupRuleAssignment", b =>
                {
                    b.HasOne("UserManagementModule.Domain.model.AccessRule", "AccessRule")
                        .WithMany("UserGroupRuleAssignments")
                        .HasForeignKey("AccessRuleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UserManagementModule.Domain.model.UserGroup", "UserGroup")
                        .WithMany("UserGroupRuleAssignments")
                        .HasForeignKey("UserGroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AccessRule");

                    b.Navigation("UserGroup");
                });

            modelBuilder.Entity("UserManagementModule.Domain.model.Administrator", b =>
                {
                    b.HasOne("UserManagementModule.Domain.model.Person", null)
                        .WithOne()
                        .HasForeignKey("UserManagementModule.Domain.model.Administrator", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("UserManagementModule.Domain.model.SystemUser", b =>
                {
                    b.HasOne("UserManagementModule.Domain.model.Person", null)
                        .WithOne()
                        .HasForeignKey("UserManagementModule.Domain.model.SystemUser", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.HasOne("UserManagementModule.Domain.model.UserGroup", "UserGroup")
                        .WithMany("Users")
                        .HasForeignKey("UserGroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserGroup");
                });

            modelBuilder.Entity("UserManagementModule.Domain.model.AccessRule", b =>
                {
                    b.Navigation("UserGroupRuleAssignments");
                });

            modelBuilder.Entity("UserManagementModule.Domain.model.UserGroup", b =>
                {
                    b.Navigation("UserGroupRuleAssignments");

                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
