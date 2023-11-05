﻿// <auto-generated />
using System;
using EventRegistrationApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace EventRegistrationApp.Migrations
{
    [DbContext(typeof(EventContext))]
    [Migration("20231105002625_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("EventRegistrationApp.Models.Event", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Location")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("event", "docuV2");
                });

            modelBuilder.Entity("EventRegistrationApp.Models.EventRegistration", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<long>("EventId")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.ToTable("event_registration", "docuV2");
                });

            modelBuilder.Entity("EventRegistrationApp.Models.EventRegistration", b =>
                {
                    b.HasOne("EventRegistrationApp.Models.Event", null)
                        .WithMany("EventRegistrations")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EventRegistrationApp.Models.Event", b =>
                {
                    b.Navigation("EventRegistrations");
                });
#pragma warning restore 612, 618
        }
    }
}
