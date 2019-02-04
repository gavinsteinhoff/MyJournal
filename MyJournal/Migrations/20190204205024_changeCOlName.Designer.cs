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
    [Migration("20190204205024_changeCOlName")]
    partial class changeCOlName
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.3-rtm-10026")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MyJournal.Models.CustomModels.DailyInformtion", b =>
                {
                    b.Property<int>("DailyInformtionID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DailyInformtionDateTime");

                    b.Property<string>("DailyInformtionUser");

                    b.Property<string>("JournalText")
                        .IsRequired();

                    b.Property<int>("mood");

                    b.HasKey("DailyInformtionID");

                    b.ToTable("DailyInformtions");
                });
#pragma warning restore 612, 618
        }
    }
}
