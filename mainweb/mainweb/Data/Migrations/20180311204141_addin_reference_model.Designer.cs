using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using mainweb.Data;
using mainweb.Models;

namespace mainweb.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20180311204141_addin_reference_model")]
    partial class addin_reference_model
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("mainweb.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("mainweb.Models.CorrectResponse", b =>
                {
                    b.Property<int>("CorrectResponseId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Answer")
                        .IsRequired();

                    b.Property<int?>("ExcerciseItemId");

                    b.HasKey("CorrectResponseId");

                    b.HasIndex("ExcerciseItemId");

                    b.ToTable("CorrectResponse");
                });

            modelBuilder.Entity("mainweb.Models.DictionaryEntry", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("DicDirection");

                    b.Property<string>("Text")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Dictionary");
                });

            modelBuilder.Entity("mainweb.Models.Excercise", b =>
                {
                    b.Property<int>("ExcerciseId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ExcerciseName")
                        .IsRequired();

                    b.HasKey("ExcerciseId");

                    b.ToTable("Excercise");
                });

            modelBuilder.Entity("mainweb.Models.ExcerciseItem", b =>
                {
                    b.Property<int>("ExcerciseItemId")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("ExcerciseId");

                    b.Property<string>("Question")
                        .IsRequired();

                    b.HasKey("ExcerciseItemId");

                    b.HasIndex("ExcerciseId");

                    b.ToTable("ExcerciseItem");
                });

            modelBuilder.Entity("mainweb.Models.Lesson", b =>
                {
                    b.Property<int>("LessonId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("FilePath");

                    b.Property<int?>("LessonGroupId");

                    b.Property<string>("Title")
                        .IsRequired();

                    b.Property<string>("TrainsPath");

                    b.HasKey("LessonId");

                    b.HasIndex("LessonGroupId");

                    b.ToTable("Lessons");
                });

            modelBuilder.Entity("mainweb.Models.LessonGroup", b =>
                {
                    b.Property<int>("LessonGroupId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Title")
                        .IsRequired();

                    b.HasKey("LessonGroupId");

                    b.ToTable("LessonGroups");
                });

            modelBuilder.Entity("mainweb.Models.ProgressViewModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ExcerciseName");

                    b.Property<int>("PointsAvailable");

                    b.Property<int>("PointsEarned");

                    b.Property<DateTime>("TimeTaken");

                    b.HasKey("Id");

                    b.ToTable("ProgressViewModel");
                });

            modelBuilder.Entity("mainweb.Models.Test", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ApplicationUserId");

                    b.Property<int>("ExcerciseId");

                    b.Property<int>("PointsAvailable");

                    b.Property<int>("PointsEarned");

                    b.Property<DateTime>("TimeTaken");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationUserId");

                    b.ToTable("Test");
                });

            modelBuilder.Entity("mainweb.Models.Trainer", b =>
                {
                    b.Property<int>("TrainerId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Original")
                        .IsRequired();

                    b.HasKey("TrainerId");

                    b.ToTable("Trainer");
                });

            modelBuilder.Entity("mainweb.Models.TrainerCar", b =>
                {
                    b.Property<int>("TrainerCarId")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("HasWheels");

                    b.Property<int>("Style");

                    b.Property<int?>("TrainerId");

                    b.HasKey("TrainerCarId");

                    b.HasIndex("TrainerId");

                    b.ToTable("TrainerCar");
                });

            modelBuilder.Entity("mainweb.Models.TrainerCorrectResponse", b =>
                {
                    b.Property<int>("TrainerCorrectResponseId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Answer")
                        .IsRequired();

                    b.Property<int?>("TrainerCarId");

                    b.HasKey("TrainerCorrectResponseId");

                    b.HasIndex("TrainerCarId");

                    b.ToTable("TrainerCorrectResponse");
                });

            modelBuilder.Entity("mainweb.Models.Translation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("DictionaryEntryId");

                    b.Property<string>("Text")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("DictionaryEntryId");

                    b.ToTable("Translations");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("mainweb.Models.CorrectResponse", b =>
                {
                    b.HasOne("mainweb.Models.ExcerciseItem")
                        .WithMany("CorrectResponses")
                        .HasForeignKey("ExcerciseItemId");
                });

            modelBuilder.Entity("mainweb.Models.ExcerciseItem", b =>
                {
                    b.HasOne("mainweb.Models.Excercise")
                        .WithMany("ExcerciseItems")
                        .HasForeignKey("ExcerciseId");
                });

            modelBuilder.Entity("mainweb.Models.Lesson", b =>
                {
                    b.HasOne("mainweb.Models.LessonGroup", "LessonGroup")
                        .WithMany("Lessons")
                        .HasForeignKey("LessonGroupId");
                });

            modelBuilder.Entity("mainweb.Models.Test", b =>
                {
                    b.HasOne("mainweb.Models.ApplicationUser")
                        .WithMany("TestsTaken")
                        .HasForeignKey("ApplicationUserId");
                });

            modelBuilder.Entity("mainweb.Models.TrainerCar", b =>
                {
                    b.HasOne("mainweb.Models.Trainer")
                        .WithMany("Cars")
                        .HasForeignKey("TrainerId");
                });

            modelBuilder.Entity("mainweb.Models.TrainerCorrectResponse", b =>
                {
                    b.HasOne("mainweb.Models.TrainerCar")
                        .WithMany("CorrectResponses")
                        .HasForeignKey("TrainerCarId");
                });

            modelBuilder.Entity("mainweb.Models.Translation", b =>
                {
                    b.HasOne("mainweb.Models.DictionaryEntry")
                        .WithMany("Translatins")
                        .HasForeignKey("DictionaryEntryId");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Claims")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("mainweb.Models.ApplicationUser")
                        .WithMany("Claims")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("mainweb.Models.ApplicationUser")
                        .WithMany("Logins")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("mainweb.Models.ApplicationUser")
                        .WithMany("Roles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
