﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RestfulApiVisualCode.DataBaseContext;

namespace RestfulApiVisualCode.Migrations
{
    [DbContext(typeof(EventsContext))]
    partial class EventsContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.14");

            modelBuilder.Entity("RestfulApiVisualCode.Models.Event", b =>
                {
                    b.Property<int>("EventId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Dateofevent")
                        .HasColumnType("TEXT");

                    b.Property<string>("Discribeevent")
                        .HasColumnType("TEXT");

                    b.Property<string>("EventCreator")
                        .HasColumnType("TEXT");

                    b.Property<string>("Fixevent")
                        .HasColumnType("TEXT");

                    b.Property<string>("Isserios")
                        .HasColumnType("TEXT");

                    b.Property<int>("Nameofasb")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nameofdevice")
                        .HasColumnType("TEXT");

                    b.HasKey("EventId");

                    b.ToTable("Events");

                    b.HasData(
                        new
                        {
                            EventId = 1,
                            Dateofevent = "5/13/2022",
                            Discribeevent = "ваще коллапс",
                            EventCreator = "Admin",
                            Fixevent = "все пофиксили",
                            Isserios = "серьезно",
                            Nameofasb = 1,
                            Nameofdevice = "SSL"
                        },
                        new
                        {
                            EventId = 2,
                            Dateofevent = "5/13/2022",
                            Discribeevent = "все сломалось",
                            EventCreator = "Admin",
                            Fixevent = "это не",
                            Isserios = "не серьезно",
                            Nameofasb = 2,
                            Nameofdevice = "Karrera"
                        },
                        new
                        {
                            EventId = 3,
                            Dateofevent = "5/13/2022",
                            Discribeevent = "ваще коллапс",
                            EventCreator = "Admin",
                            Fixevent = "все пофиксили",
                            Isserios = "не серьезно",
                            Nameofasb = 7,
                            Nameofdevice = "микрофон"
                        },
                        new
                        {
                            EventId = 4,
                            Dateofevent = "5/13/2022",
                            Discribeevent = "жесть какая",
                            EventCreator = "Admin",
                            Fixevent = "это не",
                            Isserios = "серьезно",
                            Nameofasb = 5,
                            Nameofdevice = "Karrera"
                        });
                });

            modelBuilder.Entity("RestfulApiVisualCode.Models.Image", b =>
                {
                    b.Property<int>("ImageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("EventId")
                        .HasColumnType("INTEGER");

                    b.Property<byte[]>("ImageByte")
                        .HasColumnType("BLOB");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("ImageId");

                    b.HasIndex("EventId");

                    b.ToTable("Images");
                });

            modelBuilder.Entity("RestfulApiVisualCode.Models.Page", b =>
                {
                    b.Property<int>("PageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Header")
                        .HasColumnType("TEXT");

                    b.Property<string>("Info")
                        .HasColumnType("TEXT");

                    b.Property<string>("PageCreator")
                        .HasColumnType("TEXT");

                    b.Property<string>("Subheader")
                        .HasColumnType("TEXT");

                    b.HasKey("PageId");

                    b.ToTable("Pages");

                    b.HasData(
                        new
                        {
                            PageId = 1,
                            Header = "Видеопульт",
                            Info = "Вот тут написано как делать окна и всякие эффекты",
                            PageCreator = "Admin",
                            Subheader = "Эффекты, окна"
                        },
                        new
                        {
                            PageId = 2,
                            Header = "Видеопульт",
                            Info = "Вот тут сбор всяких поломок",
                            PageCreator = "Admin",
                            Subheader = "Разного рода поломки"
                        },
                        new
                        {
                            PageId = 3,
                            Header = "Камеры, CCU и OCP",
                            Info = "Вот тут написано о великой полезности камер",
                            PageCreator = "Admin",
                            Subheader = "Камеры"
                        },
                        new
                        {
                            PageId = 4,
                            Header = "Звуковое оборудование",
                            Info = "Вот здесь написано про микрофоны и их особенности",
                            PageCreator = "Admin",
                            Subheader = "Микрофоны"
                        });
                });

            modelBuilder.Entity("RestfulApiVisualCode.Models.Role", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("RoleName")
                        .HasColumnType("TEXT");

                    b.HasKey("RoleId");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            RoleId = 1,
                            RoleName = "Admin"
                        },
                        new
                        {
                            RoleId = 2,
                            RoleName = "Engeneer"
                        });
                });

            modelBuilder.Entity("RestfulApiVisualCode.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Login")
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .HasColumnType("TEXT");

                    b.Property<int?>("RoleId")
                        .HasColumnType("INTEGER");

                    b.HasKey("UserId");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            Login = "Admin",
                            Password = "Admin",
                            RoleId = 1
                        },
                        new
                        {
                            UserId = 2,
                            Login = "asb6",
                            Password = "asb6",
                            RoleId = 2
                        },
                        new
                        {
                            UserId = 3,
                            Login = "asb4",
                            Password = "asb4",
                            RoleId = 2
                        });
                });

            modelBuilder.Entity("RestfulApiVisualCode.Models.Image", b =>
                {
                    b.HasOne("RestfulApiVisualCode.Models.Event", "EventforImage")
                        .WithMany("EventImages")
                        .HasForeignKey("EventId");

                    b.Navigation("EventforImage");
                });

            modelBuilder.Entity("RestfulApiVisualCode.Models.User", b =>
                {
                    b.HasOne("RestfulApiVisualCode.Models.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("RestfulApiVisualCode.Models.Event", b =>
                {
                    b.Navigation("EventImages");
                });

            modelBuilder.Entity("RestfulApiVisualCode.Models.Role", b =>
                {
                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
