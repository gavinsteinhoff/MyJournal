﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using MyJournal.Data;
using System;

namespace MyJournal.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20190415222140_removeUserFromCustomtemplates")]
    partial class removeUserFromCustomtemplates
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.3-rtm-10026")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
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
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
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

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
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

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
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

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("MyJournal.Models.ApplicationUser", b =>
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
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("MyJournal.Models.CustomModels.ApiData", b =>
                {
                    b.Property<int>("ApiDataID");

                    b.Property<int>("DailyInformationID");

                    b.Property<int?>("DocumentTonesDocumentToneID");

                    b.HasKey("ApiDataID");

                    b.HasIndex("DocumentTonesDocumentToneID");

                    b.ToTable("ApiDatas");
                });

            modelBuilder.Entity("MyJournal.Models.CustomModels.ApiData+DocumentTone", b =>
                {
                    b.Property<int>("DocumentToneID")
                        .ValueGeneratedOnAdd();

                    b.HasKey("DocumentToneID");

                    b.ToTable("DocumentTone");
                });

            modelBuilder.Entity("MyJournal.Models.CustomModels.ApiData+SentenceTone", b =>
                {
                    b.Property<int>("SentenceToneID")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("ApiDataID");

                    b.Property<string>("Text");

                    b.HasKey("SentenceToneID");

                    b.HasIndex("ApiDataID");

                    b.ToTable("SentenceTone");
                });

            modelBuilder.Entity("MyJournal.Models.CustomModels.ApiData+Tone", b =>
                {
                    b.Property<int>("ToneID")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("DocumentToneID");

                    b.Property<double>("Score");

                    b.Property<int?>("SentenceToneID");

                    b.Property<string>("ToneName");

                    b.HasKey("ToneID");

                    b.HasIndex("DocumentToneID");

                    b.HasIndex("SentenceToneID");

                    b.ToTable("Tone");
                });

            modelBuilder.Entity("MyJournal.Models.CustomModels.CustomTemplates", b =>
                {
                    b.Property<int>("CustomTemplateKey")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ApplicationUserId");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("Template")
                        .IsRequired();

                    b.HasKey("CustomTemplateKey");

                    b.HasIndex("ApplicationUserId");

                    b.ToTable("CustomTemplates");
                });

            modelBuilder.Entity("MyJournal.Models.CustomModels.DailyInformation", b =>
                {
                    b.Property<int>("DailyInformationID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ApplicationUserId");

                    b.Property<DateTime>("DailyInformationDateTime");

                    b.Property<DateTime>("DownTime");

                    b.Property<int>("ExcitedForTomorrow");

                    b.Property<int>("GeneratedMood");

                    b.Property<int>("HoursSlept");

                    b.Property<string>("JournalText")
                        .IsRequired();

                    b.Property<int>("MinExercising");

                    b.Property<int>("MinHobby");

                    b.Property<int>("MinPhone");

                    b.Property<int>("NumGoodThings");

                    b.Property<int>("NumPoorThings");

                    b.Property<int>("OverallDay");

                    b.Property<string>("Title")
                        .IsRequired();

                    b.Property<DateTime>("UpTime");

                    b.Property<string>("User");

                    b.Property<int>("UserMood");

                    b.HasKey("DailyInformationID");

                    b.HasIndex("ApplicationUserId");

                    b.ToTable("DailyInformations");
                });

            modelBuilder.Entity("MyJournal.Models.CustomModels.Sharing", b =>
                {
                    b.Property<int>("SharingID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("GetterId");

                    b.Property<string>("GiverId");

                    b.Property<int>("PermissionLevel");

                    b.Property<string>("Receiver")
                        .IsRequired();

                    b.HasKey("SharingID");

                    b.HasIndex("GetterId");

                    b.HasIndex("GiverId");

                    b.ToTable("Sharings");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("MyJournal.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("MyJournal.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MyJournal.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("MyJournal.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MyJournal.Models.CustomModels.ApiData", b =>
                {
                    b.HasOne("MyJournal.Models.CustomModels.DailyInformation", "DailyInformation")
                        .WithOne("ApiData")
                        .HasForeignKey("MyJournal.Models.CustomModels.ApiData", "ApiDataID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MyJournal.Models.CustomModels.ApiData+DocumentTone", "DocumentTones")
                        .WithMany()
                        .HasForeignKey("DocumentTonesDocumentToneID");
                });

            modelBuilder.Entity("MyJournal.Models.CustomModels.ApiData+SentenceTone", b =>
                {
                    b.HasOne("MyJournal.Models.CustomModels.ApiData")
                        .WithMany("SentenceTones")
                        .HasForeignKey("ApiDataID");
                });

            modelBuilder.Entity("MyJournal.Models.CustomModels.ApiData+Tone", b =>
                {
                    b.HasOne("MyJournal.Models.CustomModels.ApiData+DocumentTone", "DocumentTone")
                        .WithMany("Tones")
                        .HasForeignKey("DocumentToneID");

                    b.HasOne("MyJournal.Models.CustomModels.ApiData+SentenceTone")
                        .WithMany("Tones")
                        .HasForeignKey("SentenceToneID");
                });

            modelBuilder.Entity("MyJournal.Models.CustomModels.CustomTemplates", b =>
                {
                    b.HasOne("MyJournal.Models.ApplicationUser", "ApplicationUser")
                        .WithMany()
                        .HasForeignKey("ApplicationUserId");
                });

            modelBuilder.Entity("MyJournal.Models.CustomModels.DailyInformation", b =>
                {
                    b.HasOne("MyJournal.Models.ApplicationUser", "ApplicationUser")
                        .WithMany()
                        .HasForeignKey("ApplicationUserId");
                });

            modelBuilder.Entity("MyJournal.Models.CustomModels.Sharing", b =>
                {
                    b.HasOne("MyJournal.Models.ApplicationUser", "Getter")
                        .WithMany("Getter")
                        .HasForeignKey("GetterId");

                    b.HasOne("MyJournal.Models.ApplicationUser", "Giver")
                        .WithMany("Giver")
                        .HasForeignKey("GiverId");
                });
#pragma warning restore 612, 618
        }
    }
}
