﻿// <auto-generated />
using System;
using CustomFramework.SampleWebApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CustomFramework.SampleWebApi.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20180527141725_EntityIndexUpdate")]
    partial class EntityIndexUpdate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.0-rc1-32029")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CustomFramework.SampleWebApi.Models.Course", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CourseNo")
                        .HasColumnName("course_no");

                    b.Property<DateTime>("CreateDateTime")
                        .HasColumnName("create_date_time");

                    b.Property<DateTime?>("DeleteDateTime")
                        .HasColumnName("delete_date_time");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("name")
                        .HasMaxLength(25);

                    b.Property<int>("Status")
                        .HasColumnName("status");

                    b.Property<int>("TeacherId")
                        .HasColumnName("teacher_id");

                    b.Property<DateTime?>("UpdateDateTime")
                        .HasColumnName("update_date_time");

                    b.HasKey("Id")
                        .HasName("pk_courses");

                    b.HasIndex("CourseNo")
                        .IsUnique()
                        .HasName("ix_courses_course_no");

                    b.HasIndex("TeacherId")
                        .HasName("ix_courses_teacher_id");

                    b.ToTable("courses");
                });

            modelBuilder.Entity("CustomFramework.SampleWebApi.Models.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreateDateTime")
                        .HasColumnName("create_date_time");

                    b.Property<DateTime?>("DeleteDateTime")
                        .HasColumnName("delete_date_time");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("name")
                        .HasMaxLength(25);

                    b.Property<int>("Status")
                        .HasColumnName("status");

                    b.Property<int>("StudentNo")
                        .HasColumnName("student_no");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnName("surname")
                        .HasMaxLength(25);

                    b.Property<DateTime?>("UpdateDateTime")
                        .HasColumnName("update_date_time");

                    b.HasKey("Id")
                        .HasName("pk_students");

                    b.HasIndex("StudentNo")
                        .IsUnique()
                        .HasName("ix_students_student_no");

                    b.ToTable("students");
                });

            modelBuilder.Entity("CustomFramework.SampleWebApi.Models.StudentCourse", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CourseId")
                        .HasColumnName("course_id");

                    b.Property<DateTime>("CreateDateTime")
                        .HasColumnName("create_date_time");

                    b.Property<DateTime?>("DeleteDateTime")
                        .HasColumnName("delete_date_time");

                    b.Property<int>("Status")
                        .HasColumnName("status");

                    b.Property<int>("StudentId")
                        .HasColumnName("student_id");

                    b.Property<DateTime?>("UpdateDateTime")
                        .HasColumnName("update_date_time");

                    b.HasKey("Id")
                        .HasName("pk_student_courses");

                    b.HasIndex("CourseId")
                        .HasName("ix_student_courses_course_id");

                    b.HasIndex("StudentId")
                        .HasName("ix_student_courses_student_id");

                    b.ToTable("student_courses");
                });

            modelBuilder.Entity("CustomFramework.SampleWebApi.Models.Teacher", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreateDateTime")
                        .HasColumnName("create_date_time");

                    b.Property<DateTime?>("DeleteDateTime")
                        .HasColumnName("delete_date_time");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("name")
                        .HasMaxLength(25);

                    b.Property<int>("Status")
                        .HasColumnName("status");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnName("surname")
                        .HasMaxLength(25);

                    b.Property<int>("TeacherNo")
                        .HasColumnName("teacher_no");

                    b.Property<DateTime?>("UpdateDateTime")
                        .HasColumnName("update_date_time");

                    b.HasKey("Id")
                        .HasName("pk_teachers");

                    b.HasIndex("TeacherNo")
                        .IsUnique()
                        .HasName("ix_teachers_teacher_no");

                    b.ToTable("teachers");
                });

            modelBuilder.Entity("CustomFramework.WebApiUtils.Authorization.Models.Claim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreateDateTime")
                        .HasColumnName("create_date_time");

                    b.Property<string>("CustomClaim")
                        .IsRequired()
                        .HasColumnName("custom_claim")
                        .HasMaxLength(100);

                    b.Property<DateTime?>("DeleteDateTime")
                        .HasColumnName("delete_date_time");

                    b.Property<int>("Status")
                        .HasColumnName("status");

                    b.Property<DateTime?>("UpdateDateTime")
                        .HasColumnName("update_date_time");

                    b.HasKey("Id")
                        .HasName("pk_claims");

                    b.HasIndex("CustomClaim")
                        .HasName("ix_claims_custom_claim");

                    b.ToTable("claims");
                });

            modelBuilder.Entity("CustomFramework.WebApiUtils.Authorization.Models.ClientApplication", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClientApplicationCode")
                        .IsRequired()
                        .HasColumnName("client_application_code")
                        .HasMaxLength(6);

                    b.Property<string>("ClientApplicationName")
                        .IsRequired()
                        .HasColumnName("client_application_name")
                        .HasMaxLength(20);

                    b.Property<string>("ClientApplicationPassword")
                        .IsRequired()
                        .HasColumnName("client_application_password")
                        .HasMaxLength(50);

                    b.Property<DateTime>("CreateDateTime")
                        .HasColumnName("create_date_time");

                    b.Property<DateTime?>("DeleteDateTime")
                        .HasColumnName("delete_date_time");

                    b.Property<int>("Status")
                        .HasColumnName("status");

                    b.Property<DateTime?>("UpdateDateTime")
                        .HasColumnName("update_date_time");

                    b.HasKey("Id")
                        .HasName("pk_client_applications");

                    b.HasIndex("ClientApplicationCode")
                        .HasName("ix_client_applications_client_application_code");

                    b.HasIndex("ClientApplicationName")
                        .HasName("ix_client_applications_client_application_name");

                    b.HasIndex("ClientApplicationPassword")
                        .HasName("ix_client_applications_client_application_password");

                    b.ToTable("client_applications");

                    b.HasData(
                        new { Id = 1, ClientApplicationCode = "web", ClientApplicationName = "web", ClientApplicationPassword = "JKz11+7SGUkWbuJeMLHV/iRxdmumk5mUrdFRjjtjRqU=", CreateDateTime = new DateTime(2018, 5, 27, 17, 17, 25, 178, DateTimeKind.Local), Status = 1 }
                    );
                });

            modelBuilder.Entity("CustomFramework.WebApiUtils.Authorization.Models.ClientApplicationUtil", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ClientApplicationId")
                        .HasColumnName("client_application_id");

                    b.Property<DateTime>("CreateDateTime")
                        .HasColumnName("create_date_time");

                    b.Property<DateTime?>("DeleteDateTime")
                        .HasColumnName("delete_date_time");

                    b.Property<string>("SpecialValue")
                        .IsRequired()
                        .HasColumnName("special_value")
                        .HasMaxLength(100);

                    b.Property<int>("Status")
                        .HasColumnName("status");

                    b.Property<DateTime?>("UpdateDateTime")
                        .HasColumnName("update_date_time");

                    b.HasKey("Id")
                        .HasName("pk_client_application_utils");

                    b.HasIndex("ClientApplicationId")
                        .IsUnique()
                        .HasName("ix_client_application_utils_client_application_id");

                    b.ToTable("client_application_utils");

                    b.HasData(
                        new { Id = 1, ClientApplicationId = 1, CreateDateTime = new DateTime(2018, 5, 27, 17, 17, 25, 179, DateTimeKind.Local), SpecialValue = "cywC2RISmodkyFPQOt4QMw==", Status = 1 }
                    );
                });

            modelBuilder.Entity("CustomFramework.WebApiUtils.Authorization.Models.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreateDateTime")
                        .HasColumnName("create_date_time");

                    b.Property<DateTime?>("DeleteDateTime")
                        .HasColumnName("delete_date_time");

                    b.Property<string>("Description")
                        .HasColumnName("description")
                        .HasMaxLength(255);

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasColumnName("role_name")
                        .HasMaxLength(25);

                    b.Property<int>("Status")
                        .HasColumnName("status");

                    b.Property<DateTime?>("UpdateDateTime")
                        .HasColumnName("update_date_time");

                    b.HasKey("Id")
                        .HasName("pk_roles");

                    b.HasIndex("RoleName")
                        .HasName("ix_roles_role_name");

                    b.ToTable("roles");

                    b.HasData(
                        new { Id = 1, CreateDateTime = new DateTime(2018, 5, 27, 17, 17, 25, 181, DateTimeKind.Local), Description = "Administration Role", RoleName = "Administrator", Status = 1 },
                        new { Id = 2, CreateDateTime = new DateTime(2018, 5, 27, 17, 17, 25, 181, DateTimeKind.Local), Description = "Default User Role", RoleName = "NormalUser", Status = 1 },
                        new { Id = 3, CreateDateTime = new DateTime(2018, 5, 27, 17, 17, 25, 181, DateTimeKind.Local), Description = "User for data writer like stats", RoleName = "DataWriter", Status = 1 }
                    );
                });

            modelBuilder.Entity("CustomFramework.WebApiUtils.Authorization.Models.RoleClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ClaimId")
                        .HasColumnName("claim_id");

                    b.Property<DateTime>("CreateDateTime")
                        .HasColumnName("create_date_time");

                    b.Property<DateTime?>("DeleteDateTime")
                        .HasColumnName("delete_date_time");

                    b.Property<int>("RoleId")
                        .HasColumnName("role_id");

                    b.Property<int>("Status")
                        .HasColumnName("status");

                    b.Property<DateTime?>("UpdateDateTime")
                        .HasColumnName("update_date_time");

                    b.HasKey("Id")
                        .HasName("pk_role_claims");

                    b.HasIndex("ClaimId")
                        .HasName("ix_role_claims_claim_id");

                    b.HasIndex("RoleId")
                        .HasName("ix_role_claims_role_id");

                    b.ToTable("role_claims");
                });

            modelBuilder.Entity("CustomFramework.WebApiUtils.Authorization.Models.RoleEntityClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("CanCreate")
                        .HasColumnName("can_create");

                    b.Property<bool>("CanDelete")
                        .HasColumnName("can_delete");

                    b.Property<bool>("CanSelect")
                        .HasColumnName("can_select");

                    b.Property<bool>("CanUpdate")
                        .HasColumnName("can_update");

                    b.Property<DateTime>("CreateDateTime")
                        .HasColumnName("create_date_time");

                    b.Property<DateTime?>("DeleteDateTime")
                        .HasColumnName("delete_date_time");

                    b.Property<string>("Entity")
                        .IsRequired()
                        .HasColumnName("entity")
                        .HasMaxLength(50);

                    b.Property<int>("RoleId")
                        .HasColumnName("role_id");

                    b.Property<int>("Status")
                        .HasColumnName("status");

                    b.Property<DateTime?>("UpdateDateTime")
                        .HasColumnName("update_date_time");

                    b.HasKey("Id")
                        .HasName("pk_role_entity_claims");

                    b.HasIndex("RoleId", "Entity", "CanCreate", "CanSelect", "CanUpdate", "CanDelete")
                        .HasName("ix_role_entity_claims_role_id_entity_can_create_can_select_can_update_can_delete");

                    b.ToTable("role_entity_claims");

                    b.HasData(
                        new { Id = 1, CanCreate = true, CanDelete = true, CanSelect = true, CanUpdate = true, CreateDateTime = new DateTime(2018, 5, 27, 17, 17, 25, 182, DateTimeKind.Local), Entity = "Claim", RoleId = 1, Status = 1 },
                        new { Id = 2, CanCreate = true, CanDelete = true, CanSelect = true, CanUpdate = true, CreateDateTime = new DateTime(2018, 5, 27, 17, 17, 25, 182, DateTimeKind.Local), Entity = "ClientApplicationUtil", RoleId = 1, Status = 1 },
                        new { Id = 3, CanCreate = true, CanDelete = true, CanSelect = true, CanUpdate = true, CreateDateTime = new DateTime(2018, 5, 27, 17, 17, 25, 182, DateTimeKind.Local), Entity = "ClientApplication", RoleId = 1, Status = 1 },
                        new { Id = 4, CanCreate = true, CanDelete = true, CanSelect = true, CanUpdate = true, CreateDateTime = new DateTime(2018, 5, 27, 17, 17, 25, 182, DateTimeKind.Local), Entity = "UserClaim", RoleId = 1, Status = 1 },
                        new { Id = 5, CanCreate = true, CanDelete = true, CanSelect = true, CanUpdate = true, CreateDateTime = new DateTime(2018, 5, 27, 17, 17, 25, 182, DateTimeKind.Local), Entity = "UserEntityClaim", RoleId = 1, Status = 1 },
                        new { Id = 6, CanCreate = true, CanDelete = true, CanSelect = true, CanUpdate = true, CreateDateTime = new DateTime(2018, 5, 27, 17, 17, 25, 182, DateTimeKind.Local), Entity = "UserRole", RoleId = 1, Status = 1 },
                        new { Id = 7, CanCreate = true, CanDelete = true, CanSelect = true, CanUpdate = true, CreateDateTime = new DateTime(2018, 5, 27, 17, 17, 25, 182, DateTimeKind.Local), Entity = "UserUtil", RoleId = 1, Status = 1 },
                        new { Id = 8, CanCreate = true, CanDelete = true, CanSelect = true, CanUpdate = true, CreateDateTime = new DateTime(2018, 5, 27, 17, 17, 25, 182, DateTimeKind.Local), Entity = "User", RoleId = 1, Status = 1 },
                        new { Id = 9, CanCreate = true, CanDelete = true, CanSelect = true, CanUpdate = true, CreateDateTime = new DateTime(2018, 5, 27, 17, 17, 25, 182, DateTimeKind.Local), Entity = "RoleClaim", RoleId = 1, Status = 1 },
                        new { Id = 10, CanCreate = true, CanDelete = true, CanSelect = true, CanUpdate = true, CreateDateTime = new DateTime(2018, 5, 27, 17, 17, 25, 182, DateTimeKind.Local), Entity = "RoleEntityClaim", RoleId = 1, Status = 1 },
                        new { Id = 11, CanCreate = true, CanDelete = true, CanSelect = true, CanUpdate = true, CreateDateTime = new DateTime(2018, 5, 27, 17, 17, 25, 182, DateTimeKind.Local), Entity = "Role", RoleId = 1, Status = 1 },
                        new { Id = 12, CanCreate = true, CanDelete = true, CanSelect = true, CanUpdate = true, CreateDateTime = new DateTime(2018, 5, 27, 17, 17, 25, 182, DateTimeKind.Local), Entity = "Student", RoleId = 1, Status = 1 },
                        new { Id = 13, CanCreate = true, CanDelete = true, CanSelect = true, CanUpdate = true, CreateDateTime = new DateTime(2018, 5, 27, 17, 17, 25, 182, DateTimeKind.Local), Entity = "Course", RoleId = 1, Status = 1 },
                        new { Id = 14, CanCreate = true, CanDelete = true, CanSelect = true, CanUpdate = true, CreateDateTime = new DateTime(2018, 5, 27, 17, 17, 25, 182, DateTimeKind.Local), Entity = "Teacher", RoleId = 1, Status = 1 },
                        new { Id = 15, CanCreate = true, CanDelete = true, CanSelect = true, CanUpdate = true, CreateDateTime = new DateTime(2018, 5, 27, 17, 17, 25, 182, DateTimeKind.Local), Entity = "StudentCourse", RoleId = 1, Status = 1 }
                    );
                });

            modelBuilder.Entity("CustomFramework.WebApiUtils.Authorization.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccessFailedCount")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("access_failed_count")
                        .HasDefaultValue(0);

                    b.Property<DateTime>("CreateDateTime")
                        .HasColumnName("create_date_time");

                    b.Property<DateTime?>("DeleteDateTime")
                        .HasColumnName("delete_date_time");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnName("email")
                        .HasMaxLength(100);

                    b.Property<string>("EmailConfirmCode")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnName("email_confirm_code")
                        .HasMaxLength(6)
                        .HasDefaultValue("813271");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnName("email_confirmed");

                    b.Property<bool>("Lockout")
                        .HasColumnName("lockout");

                    b.Property<DateTime?>("LockoutEndDateTime")
                        .HasColumnName("lockout_end_date_time")
                        .HasMaxLength(256);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnName("password")
                        .HasMaxLength(256);

                    b.Property<int>("Status")
                        .HasColumnName("status");

                    b.Property<DateTime?>("UpdateDateTime")
                        .HasColumnName("update_date_time");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnName("user_name")
                        .HasMaxLength(25);

                    b.HasKey("Id")
                        .HasName("pk_users");

                    b.HasIndex("Email")
                        .HasName("ix_users_email");

                    b.HasIndex("Password")
                        .HasName("ix_users_password");

                    b.HasIndex("UserName")
                        .HasName("ix_users_user_name");

                    b.ToTable("users");

                    b.HasData(
                        new { Id = 1, AccessFailedCount = 0, CreateDateTime = new DateTime(2018, 5, 27, 17, 17, 25, 180, DateTimeKind.Local), Email = "admin@admin.org", EmailConfirmCode = "9988", EmailConfirmed = false, Lockout = false, Password = "92yHgHc7LcPpWNFwv/zmxNVTGCCCXHHxoKk2uLrItwc=", Status = 1, UserName = "admin" }
                    );
                });

            modelBuilder.Entity("CustomFramework.WebApiUtils.Authorization.Models.UserClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ClaimId")
                        .HasColumnName("claim_id");

                    b.Property<DateTime>("CreateDateTime")
                        .HasColumnName("create_date_time");

                    b.Property<DateTime?>("DeleteDateTime")
                        .HasColumnName("delete_date_time");

                    b.Property<int>("Status")
                        .HasColumnName("status");

                    b.Property<DateTime?>("UpdateDateTime")
                        .HasColumnName("update_date_time");

                    b.Property<int>("UserId")
                        .HasColumnName("user_id");

                    b.HasKey("Id")
                        .HasName("pk_user_claims");

                    b.HasIndex("ClaimId")
                        .HasName("ix_user_claims_claim_id");

                    b.HasIndex("UserId")
                        .HasName("ix_user_claims_user_id");

                    b.ToTable("user_claims");
                });

            modelBuilder.Entity("CustomFramework.WebApiUtils.Authorization.Models.UserEntityClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("CanCreate")
                        .HasColumnName("can_create");

                    b.Property<bool>("CanDelete")
                        .HasColumnName("can_delete");

                    b.Property<bool>("CanSelect")
                        .HasColumnName("can_select");

                    b.Property<bool>("CanUpdate")
                        .HasColumnName("can_update");

                    b.Property<DateTime>("CreateDateTime")
                        .HasColumnName("create_date_time");

                    b.Property<DateTime?>("DeleteDateTime")
                        .HasColumnName("delete_date_time");

                    b.Property<string>("Entity")
                        .IsRequired()
                        .HasColumnName("entity")
                        .HasMaxLength(50);

                    b.Property<int>("Status")
                        .HasColumnName("status");

                    b.Property<DateTime?>("UpdateDateTime")
                        .HasColumnName("update_date_time");

                    b.Property<int>("UserId")
                        .HasColumnName("user_id");

                    b.HasKey("Id")
                        .HasName("pk_user_entity_claims");

                    b.HasIndex("UserId", "Entity", "CanCreate", "CanSelect", "CanUpdate", "CanDelete")
                        .HasName("ix_user_entity_claims_user_id_entity_can_create_can_select_can_update_can_delete");

                    b.ToTable("user_entity_claims");
                });

            modelBuilder.Entity("CustomFramework.WebApiUtils.Authorization.Models.UserRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreateDateTime")
                        .HasColumnName("create_date_time");

                    b.Property<DateTime?>("DeleteDateTime")
                        .HasColumnName("delete_date_time");

                    b.Property<int>("RoleId")
                        .HasColumnName("role_id");

                    b.Property<int>("Status")
                        .HasColumnName("status");

                    b.Property<DateTime?>("UpdateDateTime")
                        .HasColumnName("update_date_time");

                    b.Property<int>("UserId")
                        .HasColumnName("user_id");

                    b.HasKey("Id")
                        .HasName("pk_user_roles");

                    b.HasIndex("RoleId")
                        .HasName("ix_user_roles_role_id");

                    b.HasIndex("UserId")
                        .HasName("ix_user_roles_user_id");

                    b.ToTable("user_roles");
                });

            modelBuilder.Entity("CustomFramework.WebApiUtils.Authorization.Models.UserUtil", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreateDateTime")
                        .HasColumnName("create_date_time");

                    b.Property<DateTime?>("DeleteDateTime")
                        .HasColumnName("delete_date_time");

                    b.Property<string>("SpecialValue")
                        .IsRequired()
                        .HasColumnName("special_value")
                        .HasMaxLength(100);

                    b.Property<int>("Status")
                        .HasColumnName("status");

                    b.Property<DateTime?>("UpdateDateTime")
                        .HasColumnName("update_date_time");

                    b.Property<int>("UserId")
                        .HasColumnName("user_id");

                    b.HasKey("Id")
                        .HasName("pk_user_utils");

                    b.HasIndex("UserId")
                        .IsUnique()
                        .HasName("ix_user_utils_user_id");

                    b.ToTable("user_utils");

                    b.HasData(
                        new { Id = 1, CreateDateTime = new DateTime(2018, 5, 27, 17, 17, 25, 180, DateTimeKind.Local), SpecialValue = "x5B5A/9MpqPoJGDc4C7Fxw==", Status = 1, UserId = 1 }
                    );
                });

            modelBuilder.Entity("CustomFramework.SampleWebApi.Models.Course", b =>
                {
                    b.HasOne("CustomFramework.SampleWebApi.Models.Teacher", "Teacher")
                        .WithMany("Courses")
                        .HasForeignKey("TeacherId")
                        .HasConstraintName("fk_courses_teachers_teacher_id")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("CustomFramework.SampleWebApi.Models.StudentCourse", b =>
                {
                    b.HasOne("CustomFramework.SampleWebApi.Models.Course", "Course")
                        .WithMany("StudentCourses")
                        .HasForeignKey("CourseId")
                        .HasConstraintName("fk_student_courses_courses_course_id")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("CustomFramework.SampleWebApi.Models.Student", "Student")
                        .WithMany("StudentCourses")
                        .HasForeignKey("StudentId")
                        .HasConstraintName("fk_student_courses_students_student_id")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("CustomFramework.WebApiUtils.Authorization.Models.ClientApplicationUtil", b =>
                {
                    b.HasOne("CustomFramework.WebApiUtils.Authorization.Models.ClientApplication", "ClientApplication")
                        .WithOne("ClientApplicationUtil")
                        .HasForeignKey("CustomFramework.WebApiUtils.Authorization.Models.ClientApplicationUtil", "ClientApplicationId")
                        .HasConstraintName("fk_client_application_utils_client_applications_client_application_id")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("CustomFramework.WebApiUtils.Authorization.Models.RoleClaim", b =>
                {
                    b.HasOne("CustomFramework.WebApiUtils.Authorization.Models.Claim", "Claim")
                        .WithMany("RoleClaims")
                        .HasForeignKey("ClaimId")
                        .HasConstraintName("fk_role_claims_claims_claim_id")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("CustomFramework.WebApiUtils.Authorization.Models.Role", "Role")
                        .WithMany("RoleClaims")
                        .HasForeignKey("RoleId")
                        .HasConstraintName("fk_role_claims_roles_role_id")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("CustomFramework.WebApiUtils.Authorization.Models.RoleEntityClaim", b =>
                {
                    b.HasOne("CustomFramework.WebApiUtils.Authorization.Models.Role", "Role")
                        .WithMany("RoleEntityClaims")
                        .HasForeignKey("RoleId")
                        .HasConstraintName("fk_role_entity_claims_roles_role_id")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("CustomFramework.WebApiUtils.Authorization.Models.UserClaim", b =>
                {
                    b.HasOne("CustomFramework.WebApiUtils.Authorization.Models.Claim", "Claim")
                        .WithMany("UserClaims")
                        .HasForeignKey("ClaimId")
                        .HasConstraintName("fk_user_claims_claims_claim_id")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("CustomFramework.WebApiUtils.Authorization.Models.User", "User")
                        .WithMany("UserClaims")
                        .HasForeignKey("UserId")
                        .HasConstraintName("fk_user_claims_users_user_id")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("CustomFramework.WebApiUtils.Authorization.Models.UserEntityClaim", b =>
                {
                    b.HasOne("CustomFramework.WebApiUtils.Authorization.Models.User", "User")
                        .WithMany("UserEntityClaims")
                        .HasForeignKey("UserId")
                        .HasConstraintName("fk_user_entity_claims_users_user_id")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("CustomFramework.WebApiUtils.Authorization.Models.UserRole", b =>
                {
                    b.HasOne("CustomFramework.WebApiUtils.Authorization.Models.Role", "Role")
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleId")
                        .HasConstraintName("fk_user_roles_roles_role_id")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("CustomFramework.WebApiUtils.Authorization.Models.User", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId")
                        .HasConstraintName("fk_user_roles_users_user_id")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("CustomFramework.WebApiUtils.Authorization.Models.UserUtil", b =>
                {
                    b.HasOne("CustomFramework.WebApiUtils.Authorization.Models.User", "User")
                        .WithOne("UserUtil")
                        .HasForeignKey("CustomFramework.WebApiUtils.Authorization.Models.UserUtil", "UserId")
                        .HasConstraintName("fk_user_utils_users_user_id")
                        .OnDelete(DeleteBehavior.Restrict);
                });
#pragma warning restore 612, 618
        }
    }
}
