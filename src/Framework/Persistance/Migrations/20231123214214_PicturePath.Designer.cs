﻿// <auto-generated />
using System;
using DataClash.Framework.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Framework.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20231123214214_PicturePath")]
    partial class PicturePath
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.13");

            modelBuilder.Entity("DataClash.Domain.Entities.Card", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<double>("ElixirCost")
                        .HasColumnType("REAL");

                    b.Property<long>("InitialLevel")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Picture")
                        .HasColumnType("TEXT");

                    b.Property<int>("Quality")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Cards");

                    b.UseTptMappingStrategy();
                });

            modelBuilder.Entity("DataClash.Domain.Entities.CardGift", b =>
                {
                    b.Property<long>("ClanId")
                        .HasColumnType("INTEGER");

                    b.Property<long>("CardId")
                        .HasColumnType("INTEGER");

                    b.Property<long>("PlayerId")
                        .HasColumnType("INTEGER");

                    b.HasKey("ClanId", "CardId", "PlayerId");

                    b.HasIndex("CardId", "PlayerId");

                    b.ToTable("CardGifts");
                });

            modelBuilder.Entity("DataClash.Domain.Entities.Challenge", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("BeginDay")
                        .HasColumnType("TEXT");

                    b.Property<long>("Bounty")
                        .HasColumnType("INTEGER");

                    b.Property<long>("Cost")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<TimeSpan>("Duration")
                        .HasColumnType("TEXT");

                    b.Property<long>("MaxLooses")
                        .HasColumnType("INTEGER");

                    b.Property<long>("MinLevel")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Challenges");
                });

            modelBuilder.Entity("DataClash.Domain.Entities.Clan", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<long>("TotalTrophiesToEnter")
                        .HasColumnType("INTEGER");

                    b.Property<long>("TotalTrophiesWonOnWar")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Type")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Clans");
                });

            modelBuilder.Entity("DataClash.Domain.Entities.Match", b =>
                {
                    b.Property<long>("LooserPlayerId")
                        .HasColumnType("INTEGER");

                    b.Property<long>("WinnerPlayerId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("BeginDate")
                        .HasColumnType("TEXT");

                    b.Property<TimeSpan>("Duration")
                        .HasColumnType("TEXT");

                    b.HasKey("LooserPlayerId", "WinnerPlayerId", "BeginDate");

                    b.HasIndex("WinnerPlayerId");

                    b.ToTable("Matches");
                });

            modelBuilder.Entity("DataClash.Domain.Entities.Player", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<long?>("FavoriteCardId")
                        .HasColumnType("INTEGER");

                    b.Property<long>("Level")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nickname")
                        .HasColumnType("TEXT");

                    b.Property<long>("TotalCardsFound")
                        .HasColumnType("INTEGER");

                    b.Property<long>("TotalThrophies")
                        .HasColumnType("INTEGER");

                    b.Property<long>("TotalWins")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("FavoriteCardId");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("DataClash.Domain.Entities.PlayerCard", b =>
                {
                    b.Property<long>("CardId")
                        .HasColumnType("INTEGER");

                    b.Property<long>("PlayerId")
                        .HasColumnType("INTEGER");

                    b.Property<long>("Level")
                        .HasColumnType("INTEGER");

                    b.HasKey("CardId", "PlayerId");

                    b.HasIndex("PlayerId");

                    b.ToTable("PlayerCards");
                });

            modelBuilder.Entity("DataClash.Domain.Entities.PlayerChallenge", b =>
                {
                    b.Property<long>("ChallengeId")
                        .HasColumnType("INTEGER");

                    b.Property<long>("PlayerId")
                        .HasColumnType("INTEGER");

                    b.Property<long>("WonThrophies")
                        .HasColumnType("INTEGER");

                    b.HasKey("ChallengeId", "PlayerId");

                    b.HasIndex("PlayerId");

                    b.ToTable("PlayerChallenges");
                });

            modelBuilder.Entity("DataClash.Domain.Entities.PlayerClan", b =>
                {
                    b.Property<long>("ClanId")
                        .HasColumnType("INTEGER");

                    b.Property<long>("PlayerId")
                        .HasColumnType("INTEGER");

                    b.Property<long>("Role")
                        .HasColumnType("INTEGER");

                    b.HasKey("ClanId", "PlayerId");

                    b.HasIndex("PlayerId");

                    b.ToTable("PlayerClans");
                });

            modelBuilder.Entity("DataClash.Domain.Entities.War", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("BeginDay")
                        .HasColumnType("TEXT");

                    b.Property<TimeSpan>("Duration")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Wars");
                });

            modelBuilder.Entity("DataClash.Domain.Entities.WarClan", b =>
                {
                    b.Property<long>("ClanId")
                        .HasColumnType("INTEGER");

                    b.Property<long>("WarId")
                        .HasColumnType("INTEGER");

                    b.Property<long>("WonThrophies")
                        .HasColumnType("INTEGER");

                    b.HasKey("ClanId", "WarId");

                    b.HasIndex("WarId");

                    b.ToTable("WarClans");
                });

            modelBuilder.Entity("DataClash.Framework.Identity.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("TEXT");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<long?>("PlayerId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("TEXT");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.HasIndex("PlayerId");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Duende.IdentityServer.EntityFramework.Entities.DeviceFlowCodes", b =>
                {
                    b.Property<string>("UserCode")
                        .HasMaxLength(200)
                        .HasColumnType("TEXT");

                    b.Property<string>("ClientId")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("TEXT");

                    b.Property<string>("Data")
                        .IsRequired()
                        .HasMaxLength(50000)
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasMaxLength(200)
                        .HasColumnType("TEXT");

                    b.Property<string>("DeviceCode")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("Expiration")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("SessionId")
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<string>("SubjectId")
                        .HasMaxLength(200)
                        .HasColumnType("TEXT");

                    b.HasKey("UserCode");

                    b.HasIndex("DeviceCode")
                        .IsUnique();

                    b.HasIndex("Expiration");

                    b.ToTable("DeviceCodes", (string)null);
                });

            modelBuilder.Entity("Duende.IdentityServer.EntityFramework.Entities.Key", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("Algorithm")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Created")
                        .HasColumnType("TEXT");

                    b.Property<string>("Data")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("DataProtected")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsX509Certificate")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Use")
                        .HasColumnType("TEXT");

                    b.Property<int>("Version")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("Use");

                    b.ToTable("Keys", (string)null);
                });

            modelBuilder.Entity("Duende.IdentityServer.EntityFramework.Entities.PersistedGrant", b =>
                {
                    b.Property<string>("Key")
                        .HasMaxLength(200)
                        .HasColumnType("TEXT");

                    b.Property<string>("ClientId")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("ConsumedTime")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("TEXT");

                    b.Property<string>("Data")
                        .IsRequired()
                        .HasMaxLength(50000)
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasMaxLength(200)
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("Expiration")
                        .HasColumnType("TEXT");

                    b.Property<string>("SessionId")
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<string>("SubjectId")
                        .HasMaxLength(200)
                        .HasColumnType("TEXT");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.HasKey("Key");

                    b.HasIndex("ConsumedTime");

                    b.HasIndex("Expiration");

                    b.HasIndex("SubjectId", "ClientId", "Type");

                    b.HasIndex("SubjectId", "SessionId", "Type");

                    b.ToTable("PersistedGrants", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClaimType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("TEXT");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClaimType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("TEXT");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("TEXT");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("RoleId")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("TEXT");

                    b.Property<string>("Value")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("DataClash.Domain.Entities.MagicCard", b =>
                {
                    b.HasBaseType("DataClash.Domain.Entities.Card");

                    b.Property<double>("AreaDamage")
                        .HasColumnType("REAL");

                    b.Property<double>("DamageRadius")
                        .HasColumnType("REAL");

                    b.Property<TimeSpan>("Duration")
                        .HasColumnType("TEXT");

                    b.Property<double>("TowerDamage")
                        .HasColumnType("REAL");

                    b.ToTable("MagicCards");
                });

            modelBuilder.Entity("DataClash.Domain.Entities.StructCard", b =>
                {
                    b.HasBaseType("DataClash.Domain.Entities.Card");

                    b.Property<double>("AttackPaseRate")
                        .HasColumnType("REAL");

                    b.Property<double>("HitPoints")
                        .HasColumnType("REAL");

                    b.Property<double>("RangeDamage")
                        .HasColumnType("REAL");

                    b.ToTable("StructCards");
                });

            modelBuilder.Entity("DataClash.Domain.Entities.TroopCard", b =>
                {
                    b.HasBaseType("DataClash.Domain.Entities.Card");

                    b.Property<double>("AreaDamage")
                        .HasColumnType("REAL");

                    b.Property<double>("HitPoints")
                        .HasColumnType("REAL");

                    b.Property<long>("UnitCount")
                        .HasColumnType("INTEGER");

                    b.ToTable("TroopCards");
                });

            modelBuilder.Entity("DataClash.Domain.Entities.CardGift", b =>
                {
                    b.HasOne("DataClash.Domain.Entities.Clan", "Clan")
                        .WithMany()
                        .HasForeignKey("ClanId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataClash.Domain.Entities.PlayerCard", "PlayerCard")
                        .WithMany()
                        .HasForeignKey("CardId", "PlayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Clan");

                    b.Navigation("PlayerCard");
                });

            modelBuilder.Entity("DataClash.Domain.Entities.Clan", b =>
                {
                    b.OwnsOne("DataClash.Domain.ValueObjects.Region", "Region", b1 =>
                        {
                            b1.Property<long>("ClanId")
                                .HasColumnType("INTEGER");

                            b1.Property<string>("Code")
                                .IsRequired()
                                .HasColumnType("TEXT");

                            b1.HasKey("ClanId");

                            b1.ToTable("Clans");

                            b1.WithOwner()
                                .HasForeignKey("ClanId");
                        });

                    b.Navigation("Region");
                });

            modelBuilder.Entity("DataClash.Domain.Entities.Match", b =>
                {
                    b.HasOne("DataClash.Domain.Entities.Player", "LooserPlayer")
                        .WithMany()
                        .HasForeignKey("LooserPlayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataClash.Domain.Entities.Player", "WinnerPlayer")
                        .WithMany()
                        .HasForeignKey("WinnerPlayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("LooserPlayer");

                    b.Navigation("WinnerPlayer");
                });

            modelBuilder.Entity("DataClash.Domain.Entities.Player", b =>
                {
                    b.HasOne("DataClash.Domain.Entities.Card", "FavoriteCard")
                        .WithMany()
                        .HasForeignKey("FavoriteCardId");

                    b.Navigation("FavoriteCard");
                });

            modelBuilder.Entity("DataClash.Domain.Entities.PlayerCard", b =>
                {
                    b.HasOne("DataClash.Domain.Entities.Card", "Card")
                        .WithMany()
                        .HasForeignKey("CardId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataClash.Domain.Entities.Player", "Player")
                        .WithMany()
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Card");

                    b.Navigation("Player");
                });

            modelBuilder.Entity("DataClash.Domain.Entities.PlayerChallenge", b =>
                {
                    b.HasOne("DataClash.Domain.Entities.Challenge", "Challenge")
                        .WithMany()
                        .HasForeignKey("ChallengeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataClash.Domain.Entities.Player", "Player")
                        .WithMany()
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Challenge");

                    b.Navigation("Player");
                });

            modelBuilder.Entity("DataClash.Domain.Entities.PlayerClan", b =>
                {
                    b.HasOne("DataClash.Domain.Entities.Clan", "Clan")
                        .WithMany()
                        .HasForeignKey("ClanId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataClash.Domain.Entities.Player", "Player")
                        .WithMany()
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Clan");

                    b.Navigation("Player");
                });

            modelBuilder.Entity("DataClash.Domain.Entities.WarClan", b =>
                {
                    b.HasOne("DataClash.Domain.Entities.Clan", "Clan")
                        .WithMany()
                        .HasForeignKey("ClanId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataClash.Domain.Entities.War", "War")
                        .WithMany()
                        .HasForeignKey("WarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Clan");

                    b.Navigation("War");
                });

            modelBuilder.Entity("DataClash.Framework.Identity.ApplicationUser", b =>
                {
                    b.HasOne("DataClash.Domain.Entities.Player", "Player")
                        .WithMany()
                        .HasForeignKey("PlayerId");

                    b.Navigation("Player");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("DataClash.Framework.Identity.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("DataClash.Framework.Identity.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataClash.Framework.Identity.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("DataClash.Framework.Identity.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DataClash.Domain.Entities.MagicCard", b =>
                {
                    b.HasOne("DataClash.Domain.Entities.Card", null)
                        .WithOne()
                        .HasForeignKey("DataClash.Domain.Entities.MagicCard", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DataClash.Domain.Entities.StructCard", b =>
                {
                    b.HasOne("DataClash.Domain.Entities.Card", null)
                        .WithOne()
                        .HasForeignKey("DataClash.Domain.Entities.StructCard", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DataClash.Domain.Entities.TroopCard", b =>
                {
                    b.HasOne("DataClash.Domain.Entities.Card", null)
                        .WithOne()
                        .HasForeignKey("DataClash.Domain.Entities.TroopCard", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
