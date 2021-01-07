﻿// <auto-generated />
using System;
using DataLayer.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DataLayer.Migrations
{
    [DbContext(typeof(UserDbContext))]
    [Migration("20210107134016_mig")]
    partial class mig
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("DataLayer.Models.FriendRequest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("ReceiverId")
                        .HasColumnType("int");

                    b.Property<int?>("SenderId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ReceiverId");

                    b.HasIndex("SenderId");

                    b.ToTable("FriendRequests");
                });

            modelBuilder.Entity("DataLayer.Models.Friends", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("Friend_1Id")
                        .HasColumnType("int");

                    b.Property<int?>("Friend_2Id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Friend_1Id");

                    b.HasIndex("Friend_2Id");

                    b.ToTable("Friends");
                });

            modelBuilder.Entity("DataLayer.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsInactivated")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProfilePicture")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("DataLayer.Models.UserWall", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Message")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ReceiverId")
                        .HasColumnType("int");

                    b.Property<int?>("SenderId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ReceiverId");

                    b.HasIndex("SenderId");

                    b.ToTable("UserWall");
                });

            modelBuilder.Entity("DataLayer.Models.FriendRequest", b =>
                {
                    b.HasOne("DataLayer.Models.User", "Receiver")
                        .WithMany()
                        .HasForeignKey("ReceiverId");

                    b.HasOne("DataLayer.Models.User", "Sender")
                        .WithMany()
                        .HasForeignKey("SenderId");

                    b.Navigation("Receiver");

                    b.Navigation("Sender");
                });

            modelBuilder.Entity("DataLayer.Models.Friends", b =>
                {
                    b.HasOne("DataLayer.Models.User", "Friend_1")
                        .WithMany()
                        .HasForeignKey("Friend_1Id");

                    b.HasOne("DataLayer.Models.User", "Friend_2")
                        .WithMany()
                        .HasForeignKey("Friend_2Id");

                    b.Navigation("Friend_1");

                    b.Navigation("Friend_2");
                });

            modelBuilder.Entity("DataLayer.Models.UserWall", b =>
                {
                    b.HasOne("DataLayer.Models.User", "Receiver")
                        .WithMany()
                        .HasForeignKey("ReceiverId");

                    b.HasOne("DataLayer.Models.User", "Sender")
                        .WithMany()
                        .HasForeignKey("SenderId");

                    b.Navigation("Receiver");

                    b.Navigation("Sender");
                });
#pragma warning restore 612, 618
        }
    }
}
