﻿// <auto-generated />
using Contact_Application.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Contact_Application.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20210910121316_AddContactModelToNumber")]
    partial class AddContactModelToNumber
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Contact_Application.Models.Contact", b =>
                {
                    b.Property<int>("ContactID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TagID")
                        .HasColumnType("int");

                    b.HasKey("ContactID");

                    b.HasIndex("TagID");

                    b.ToTable("Contact");

                    b.HasData(
                        new
                        {
                            ContactID = 1,
                            Address = "Crikvenička 2/1",
                            LastName = "Zelić",
                            Name = "Josip",
                            TagID = 1
                        },
                        new
                        {
                            ContactID = 2,
                            Address = "Ruđera Boškovića 29",
                            LastName = "Vasiljević",
                            Name = "Ive",
                            TagID = 2
                        },
                        new
                        {
                            ContactID = 3,
                            Address = "Debeljak bb",
                            LastName = "Torbarina",
                            Name = "Ivan",
                            TagID = 2
                        },
                        new
                        {
                            ContactID = 4,
                            Address = "Miroslava Kraljevića 20",
                            LastName = "Krpan",
                            Name = "Marko",
                            TagID = 2
                        },
                        new
                        {
                            ContactID = 5,
                            Address = "Osječka 18",
                            LastName = "Jakešević",
                            Name = "Nela",
                            TagID = 3
                        },
                        new
                        {
                            ContactID = 6,
                            Address = "S.S Kranjčevića 12",
                            LastName = "Butorac",
                            Name = "Petar",
                            TagID = 3
                        });
                });

            modelBuilder.Entity("Contact_Application.Models.Mail", b =>
                {
                    b.Property<int>("MailID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ContactID")
                        .HasColumnType("int");

                    b.Property<string>("MailAddress")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MailID");

                    b.HasIndex("ContactID");

                    b.ToTable("Mail");

                    b.HasData(
                        new
                        {
                            MailID = 1,
                            ContactID = 1,
                            MailAddress = "jzelic@gmail.com"
                        },
                        new
                        {
                            MailID = 2,
                            ContactID = 1,
                            MailAddress = "zelic@fesb.hr"
                        },
                        new
                        {
                            MailID = 3,
                            ContactID = 2,
                            MailAddress = "ivasil@gmail.com"
                        },
                        new
                        {
                            MailID = 4,
                            ContactID = 3,
                            MailAddress = "itoroba@fgag.hr"
                        },
                        new
                        {
                            MailID = 5,
                            ContactID = 4,
                            MailAddress = "krpica@hotmail.com"
                        },
                        new
                        {
                            MailID = 6,
                            ContactID = 5,
                            MailAddress = "nelaj@outlook.com"
                        },
                        new
                        {
                            MailID = 7,
                            ContactID = 6,
                            MailAddress = "pbutorac@outlook.com"
                        },
                        new
                        {
                            MailID = 8,
                            ContactID = 6,
                            MailAddress = "pb1006@yahoo.com"
                        });
                });

            modelBuilder.Entity("Contact_Application.Models.Number", b =>
                {
                    b.Property<int>("NumberID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ContactID")
                        .HasColumnType("int");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("NumberID");

                    b.HasIndex("ContactID");

                    b.ToTable("Number");

                    b.HasData(
                        new
                        {
                            NumberID = 1,
                            ContactID = 1,
                            PhoneNumber = "0996993858"
                        },
                        new
                        {
                            NumberID = 2,
                            ContactID = 2,
                            PhoneNumber = "0991234562"
                        },
                        new
                        {
                            NumberID = 3,
                            ContactID = 3,
                            PhoneNumber = "0984568823"
                        },
                        new
                        {
                            NumberID = 4,
                            ContactID = 4,
                            PhoneNumber = "0912213486"
                        },
                        new
                        {
                            NumberID = 5,
                            ContactID = 5,
                            PhoneNumber = "0914459121"
                        },
                        new
                        {
                            NumberID = 6,
                            ContactID = 6,
                            PhoneNumber = "0981283221"
                        });
                });

            modelBuilder.Entity("Contact_Application.Models.Tag", b =>
                {
                    b.Property<int>("TagID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("TagName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TagID");

                    b.ToTable("Tag");

                    b.HasData(
                        new
                        {
                            TagID = 1,
                            TagName = "Obitelj"
                        },
                        new
                        {
                            TagID = 2,
                            TagName = "Prijatelj"
                        },
                        new
                        {
                            TagID = 3,
                            TagName = "Posao"
                        });
                });

            modelBuilder.Entity("Contact_Application.Models.Contact", b =>
                {
                    b.HasOne("Contact_Application.Models.Tag", "Tag")
                        .WithMany()
                        .HasForeignKey("TagID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Tag");
                });

            modelBuilder.Entity("Contact_Application.Models.Mail", b =>
                {
                    b.HasOne("Contact_Application.Models.Contact", "Contact")
                        .WithMany("Mail")
                        .HasForeignKey("ContactID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Contact");
                });

            modelBuilder.Entity("Contact_Application.Models.Number", b =>
                {
                    b.HasOne("Contact_Application.Models.Contact", "Contact")
                        .WithMany("Number")
                        .HasForeignKey("ContactID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Contact");
                });

            modelBuilder.Entity("Contact_Application.Models.Contact", b =>
                {
                    b.Navigation("Mail");

                    b.Navigation("Number");
                });
#pragma warning restore 612, 618
        }
    }
}