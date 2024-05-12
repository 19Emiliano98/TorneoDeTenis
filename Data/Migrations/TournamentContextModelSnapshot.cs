﻿// <auto-generated />
using System;
using Data.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Data.Migrations
{
    [DbContext(typeof(TournamentContext))]
    partial class TournamentContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Data.Entities.HistoryTournament", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2")
                        .HasColumnName("Date");

                    b.Property<int?>("IdPlayer")
                        .HasColumnType("int")
                        .HasColumnName("IdPlayer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Name");

                    b.HasKey("Id");

                    b.HasIndex("IdPlayer");

                    b.ToTable("HistoryTournament", (string)null);
                });

            modelBuilder.Entity("Data.Entities.Match", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("IdLoser")
                        .IsRequired()
                        .HasColumnType("int")
                        .HasColumnName("IdLoser");

                    b.Property<int>("IdTournament")
                        .HasColumnType("int")
                        .HasColumnName("IdTournament");

                    b.Property<int?>("IdWinner")
                        .IsRequired()
                        .HasColumnType("int")
                        .HasColumnName("IdWinner");

                    b.HasKey("Id");

                    b.HasIndex("IdLoser");

                    b.HasIndex("IdTournament");

                    b.HasIndex("IdWinner");

                    b.ToTable("Match", (string)null);
                });

            modelBuilder.Entity("Data.Entities.Player", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Gender");

                    b.Property<int>("Hability")
                        .HasColumnType("int")
                        .HasColumnName("Hability");

                    b.Property<int?>("Luck")
                        .HasColumnType("int")
                        .HasColumnName("Luck");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(26)
                        .HasColumnType("nvarchar(26)")
                        .HasColumnName("Name");

                    b.Property<int>("Speed")
                        .HasColumnType("int")
                        .HasColumnName("Speed");

                    b.Property<int>("Strenght")
                        .HasColumnType("int")
                        .HasColumnName("Strenght");

                    b.Property<int>("TimeReaction")
                        .HasColumnType("int")
                        .HasColumnName("TimeReaction");

                    b.HasKey("Id");

                    b.ToTable("Player", (string)null);
                });

            modelBuilder.Entity("Data.Entities.Users", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Name");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Password");

                    b.Property<DateTime?>("RefreshTokenExpiration")
                        .HasColumnType("datetime2")
                        .HasColumnName("RefeshTokenExpiration");

                    b.Property<string>("refreshToken")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("RefeshToken");

                    b.HasKey("Id");

                    b.ToTable("Users", (string)null);
                });

            modelBuilder.Entity("Data.Entities.HistoryTournament", b =>
                {
                    b.HasOne("Data.Entities.Player", "IdPlayerForeignKey")
                        .WithMany("HistoryTournamentOfPlayer")
                        .HasForeignKey("IdPlayer")
                        .HasConstraintName("FK_HistoryTournament_Player");

                    b.Navigation("IdPlayerForeignKey");
                });

            modelBuilder.Entity("Data.Entities.Match", b =>
                {
                    b.HasOne("Data.Entities.Player", "MatchLoser")
                        .WithMany("PlayerLoser")
                        .HasForeignKey("IdLoser")
                        .IsRequired()
                        .HasConstraintName("FK_Match_Loser");

                    b.HasOne("Data.Entities.HistoryTournament", "TournamentPlayed")
                        .WithMany("Matches")
                        .HasForeignKey("IdTournament")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_Match_Tournament");

                    b.HasOne("Data.Entities.Player", "MatchWinner")
                        .WithMany("PlayerWinner")
                        .HasForeignKey("IdWinner")
                        .IsRequired()
                        .HasConstraintName("FK_Match_Winner");

                    b.Navigation("MatchLoser");

                    b.Navigation("MatchWinner");

                    b.Navigation("TournamentPlayed");
                });

            modelBuilder.Entity("Data.Entities.HistoryTournament", b =>
                {
                    b.Navigation("Matches");
                });

            modelBuilder.Entity("Data.Entities.Player", b =>
                {
                    b.Navigation("HistoryTournamentOfPlayer");

                    b.Navigation("PlayerLoser");

                    b.Navigation("PlayerWinner");
                });
#pragma warning restore 612, 618
        }
    }
}
