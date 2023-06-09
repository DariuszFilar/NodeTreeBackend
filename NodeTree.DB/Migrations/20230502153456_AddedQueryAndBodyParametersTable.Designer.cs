﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NodeTree.DB;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace NodeTree.DB.Migrations
{
    [DbContext(typeof(NodeTreeDbContext))]
    [Migration("20230502153456_AddedQueryAndBodyParametersTable")]
    partial class AddedQueryAndBodyParametersTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("NodeTree.DB.Entities.BodyParameter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<long>("ExceptionLogId")
                        .HasColumnType("bigint");

                    b.Property<string>("Key")
                        .HasColumnType("text");

                    b.Property<string>("Value")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ExceptionLogId");

                    b.ToTable("BodyParameters");
                });

            modelBuilder.Entity("NodeTree.DB.Entities.ExceptionLog", b =>
                {
                    b.Property<long>("ExceptionLogId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("ExceptionLogId"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Message")
                        .HasColumnType("text");

                    b.Property<string>("StackTrace")
                        .HasColumnType("text");

                    b.Property<string>("Type")
                        .HasColumnType("text");

                    b.HasKey("ExceptionLogId");

                    b.ToTable("ExceptionsLog");
                });

            modelBuilder.Entity("NodeTree.DB.Entities.Node", b =>
                {
                    b.Property<long>("NodeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("NodeId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long?>("ParentId")
                        .HasColumnType("bigint");

                    b.Property<string>("TreeName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("NodeId");

                    b.HasIndex("ParentId");

                    b.ToTable("Nodes");
                });

            modelBuilder.Entity("NodeTree.DB.Entities.QueryParameter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<long>("ExceptionLogId")
                        .HasColumnType("bigint");

                    b.Property<string>("Key")
                        .HasColumnType("text");

                    b.Property<string>("Value")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ExceptionLogId");

                    b.ToTable("QueryParameters");
                });

            modelBuilder.Entity("NodeTree.DB.Entities.BodyParameter", b =>
                {
                    b.HasOne("NodeTree.DB.Entities.ExceptionLog", "ExceptionLog")
                        .WithMany("BodyParameters")
                        .HasForeignKey("ExceptionLogId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ExceptionLog");
                });

            modelBuilder.Entity("NodeTree.DB.Entities.Node", b =>
                {
                    b.HasOne("NodeTree.DB.Entities.Node", "Parent")
                        .WithMany("Children")
                        .HasForeignKey("ParentId");

                    b.Navigation("Parent");
                });

            modelBuilder.Entity("NodeTree.DB.Entities.QueryParameter", b =>
                {
                    b.HasOne("NodeTree.DB.Entities.ExceptionLog", "ExceptionLog")
                        .WithMany("QueryParameters")
                        .HasForeignKey("ExceptionLogId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ExceptionLog");
                });

            modelBuilder.Entity("NodeTree.DB.Entities.ExceptionLog", b =>
                {
                    b.Navigation("BodyParameters");

                    b.Navigation("QueryParameters");
                });

            modelBuilder.Entity("NodeTree.DB.Entities.Node", b =>
                {
                    b.Navigation("Children");
                });
#pragma warning restore 612, 618
        }
    }
}
