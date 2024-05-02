﻿// <auto-generated />
using System;
using ChessMaster.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ChessMaster.Infrastructure.Migrations.PostgreSql
{
    [DbContext(typeof(ChessMasterDbContext))]
    [Migration("20240502145554_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0-preview.3.24172.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ChessMaster.Domain.Entities.Account", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid")
                        .HasColumnName("User_Id");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("Email");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("Password_Hash");

                    b.Property<string>("Salt")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("Salt");

                    b.HasKey("UserId")
                        .HasName("PK_Accounts_UserId");

                    b.ToTable("Accounts", (string)null);
                });

            modelBuilder.Entity("ChessMaster.Domain.Entities.Game", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid")
                        .HasColumnName("Id");

                    b.Property<Guid?>("BlackPlayerId")
                        .HasColumnType("uuid")
                        .HasColumnName("Black_Player_Id");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("CreatorUserId")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("EndTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Fen")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("FEN");

                    b.Property<int>("GameState")
                        .HasColumnType("integer")
                        .HasColumnName("State");

                    b.Property<DateTime?>("StartTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid?>("WhitePlayerId")
                        .HasColumnType("uuid")
                        .HasColumnName("White_Player_Id");

                    b.Property<Guid?>("WinnerId")
                        .HasColumnType("uuid")
                        .HasColumnName("Winner_Id");

                    b.HasKey("Id")
                        .HasName("PK_Games_Id");

                    b.ToTable("Games", (string)null);
                });

            modelBuilder.Entity("ChessMaster.Domain.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("Id");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)");

                    b.HasKey("Id")
                        .HasName("PK_Users_Id");

                    b.ToTable("Users", (string)null);
                });

            modelBuilder.Entity("ChessMaster.Domain.Entities.Account", b =>
                {
                    b.HasOne("ChessMaster.Domain.Entities.User", null)
                        .WithOne()
                        .HasForeignKey("ChessMaster.Domain.Entities.Account", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_Accounts_Users_UserId");
                });

            modelBuilder.Entity("ChessMaster.Domain.Entities.Game", b =>
                {
                    b.HasOne("ChessMaster.Domain.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_Games_Users_UserId");
                });
#pragma warning restore 612, 618
        }
    }
}