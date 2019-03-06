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
    [DbContext(typeof(MyJournalContext))]
    partial class JournalContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.3-rtm-10026")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MyJournal.Models.CustomModels.CustomTemplates", b =>
                {
                    b.Property<int>("CustomTemplateKey")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("Template")
                        .IsRequired();

                    b.Property<string>("User");

                    b.HasKey("CustomTemplateKey");

                    b.ToTable("CustomTemplates");
                });

            modelBuilder.Entity("MyJournal.Models.CustomModels.DailyInformation", b =>
                {
                    b.Property<int>("DailyInformationID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DailyInformationDateTime");

                    b.Property<int>("DownTime");

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

                    b.Property<int>("UpTime");

                    b.Property<string>("User");

                    b.Property<int>("UserMood");

                    b.HasKey("DailyInformationID");

                    b.ToTable("DailyInformations");
                });
#pragma warning restore 612, 618
        }
    }
}
