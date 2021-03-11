﻿// <auto-generated />
using System;
using Kutuphane.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Kutuphane.Data.Migrations
{
    [DbContext(typeof(KutuphaneContext))]
    partial class KutuphaneContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.3")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("Kutuphane.Data.Entities.Book", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Author")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int>("NumberOfBooks")
                        .HasColumnType("integer");

                    b.Property<DateTime>("RegisterationTime")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("Kutuphane.Data.Entities.Member", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Adress")
                        .HasColumnType("text");

                    b.Property<short>("Age")
                        .HasColumnType("smallint");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<DateTime>("RegisterationTime")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.ToTable("Members");
                });

            modelBuilder.Entity("Kutuphane.Data.Entities.Transaction", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<long>("BookId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("DueTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<long>("MemberId")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("ReceiveTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("RegisterationTime")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.HasIndex("MemberId");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("Kutuphane.Data.Entities.Transaction", b =>
                {
                    b.HasOne("Kutuphane.Data.Entities.Book", "Book")
                        .WithMany("Transactions")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Kutuphane.Data.Entities.Member", "Member")
                        .WithMany("Transactions")
                        .HasForeignKey("MemberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("Member");
                });

            modelBuilder.Entity("Kutuphane.Data.Entities.Book", b =>
                {
                    b.Navigation("Transactions");
                });

            modelBuilder.Entity("Kutuphane.Data.Entities.Member", b =>
                {
                    b.Navigation("Transactions");
                });
#pragma warning restore 612, 618
        }
    }
}