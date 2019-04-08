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
    [Migration("20190408045420_changedToBetter")]
    partial class changedToBetter
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.3-rtm-10026")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MyJournal.Models.CustomModels.ApiData", b =>
                {
                    b.Property<int>("ApiDataID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("DailyInformationModel");

                    b.HasKey("ApiDataID");

                    b.ToTable("ApiDatas");
                });

            modelBuilder.Entity("MyJournal.Models.CustomModels.ApiData+DocumentTone", b =>
                {
                    b.Property<int>("DocumentToneID")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("ApiDataID");

                    b.HasKey("DocumentToneID");

                    b.HasIndex("ApiDataID");

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

                    b.ToTable("DailyInformations");
                });

            modelBuilder.Entity("MyJournal.Models.CustomModels.Sharing", b =>
                {
                    b.Property<int>("SharingKey")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Giver");

                    b.Property<int>("PermissionLevel");

                    b.Property<string>("Receiver")
                        .IsRequired();

                    b.HasKey("SharingKey");

                    b.ToTable("Sharings");
                });

            modelBuilder.Entity("MyJournal.Models.CustomModels.ApiData+DocumentTone", b =>
                {
                    b.HasOne("MyJournal.Models.CustomModels.ApiData")
                        .WithMany("DocumentTones")
                        .HasForeignKey("ApiDataID");
                });

            modelBuilder.Entity("MyJournal.Models.CustomModels.ApiData+SentenceTone", b =>
                {
                    b.HasOne("MyJournal.Models.CustomModels.ApiData")
                        .WithMany("SentenceTones")
                        .HasForeignKey("ApiDataID");
                });

            modelBuilder.Entity("MyJournal.Models.CustomModels.ApiData+Tone", b =>
                {
                    b.HasOne("MyJournal.Models.CustomModels.ApiData+DocumentTone")
                        .WithMany("Tones")
                        .HasForeignKey("DocumentToneID");

                    b.HasOne("MyJournal.Models.CustomModels.ApiData+SentenceTone")
                        .WithMany("Tones")
                        .HasForeignKey("SentenceToneID");
                });
#pragma warning restore 612, 618
        }
    }
}
