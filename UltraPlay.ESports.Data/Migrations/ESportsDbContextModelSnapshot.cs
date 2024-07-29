﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using UltraPlay.ESports.Data;

#nullable disable

namespace UltraPlay.ESports.Data.Migrations
{
    [DbContext(typeof(ESportsDbContext))]
    partial class ESportsDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("UltraPlay.ESports.Data.Models.Bet", b =>
                {
                    b.Property<long>("Id")
                        .HasColumnType("bigint");

                    b.Property<bool>("IsLive")
                        .HasColumnType("bit");

                    b.Property<long>("MatchId")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("MatchId");

                    b.ToTable("Bets");
                });

            modelBuilder.Entity("UltraPlay.ESports.Data.Models.Event", b =>
                {
                    b.Property<long>("Id")
                        .HasColumnType("bigint");

                    b.Property<long>("CategoryId")
                        .HasColumnType("bigint");

                    b.Property<bool>("IsLive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("SportId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("SportId");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("UltraPlay.ESports.Data.Models.Match", b =>
                {
                    b.Property<long>("Id")
                        .HasColumnType("bigint");

                    b.Property<long>("EventId")
                        .HasColumnType("bigint");

                    b.Property<int>("MatchType")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.ToTable("Matches");
                });

            modelBuilder.Entity("UltraPlay.ESports.Data.Models.Odd", b =>
                {
                    b.Property<long>("Id")
                        .HasColumnType("bigint");

                    b.Property<long>("BetId")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("SpecialBetValue")
                        .HasColumnType("float");

                    b.Property<double>("Value")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("BetId");

                    b.ToTable("Odds");
                });

            modelBuilder.Entity("UltraPlay.ESports.Data.Models.Sport", b =>
                {
                    b.Property<long>("Id")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Sports");
                });

            modelBuilder.Entity("UltraPlay.ESports.Data.Models.Bet", b =>
                {
                    b.HasOne("UltraPlay.ESports.Data.Models.Match", "Match")
                        .WithMany("Bets")
                        .HasForeignKey("MatchId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Match");
                });

            modelBuilder.Entity("UltraPlay.ESports.Data.Models.Event", b =>
                {
                    b.HasOne("UltraPlay.ESports.Data.Models.Sport", "Sport")
                        .WithMany("Events")
                        .HasForeignKey("SportId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Sport");
                });

            modelBuilder.Entity("UltraPlay.ESports.Data.Models.Match", b =>
                {
                    b.HasOne("UltraPlay.ESports.Data.Models.Event", "Event")
                        .WithMany("Matches")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Event");
                });

            modelBuilder.Entity("UltraPlay.ESports.Data.Models.Odd", b =>
                {
                    b.HasOne("UltraPlay.ESports.Data.Models.Bet", "Bet")
                        .WithMany("Odds")
                        .HasForeignKey("BetId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Bet");
                });

            modelBuilder.Entity("UltraPlay.ESports.Data.Models.Bet", b =>
                {
                    b.Navigation("Odds");
                });

            modelBuilder.Entity("UltraPlay.ESports.Data.Models.Event", b =>
                {
                    b.Navigation("Matches");
                });

            modelBuilder.Entity("UltraPlay.ESports.Data.Models.Match", b =>
                {
                    b.Navigation("Bets");
                });

            modelBuilder.Entity("UltraPlay.ESports.Data.Models.Sport", b =>
                {
                    b.Navigation("Events");
                });
#pragma warning restore 612, 618
        }
    }
}
