﻿// <auto-generated />
using kangoeroes.leidingBeheer.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace kangoeroes.leidingBeheer.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452");

            modelBuilder.Entity("kangoeroes.core.Models.Leiding", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<string>("Auth0Id")
                        .HasColumnName("auth0Id");

                    b.Property<DateTime>("DatumGestopt")
                        .HasColumnName("datumGestopt");

                    b.Property<string>("Email")
                        .HasColumnName("email");

                    b.Property<DateTime>("LeidingSinds")
                        .HasColumnName("leidingSinds");

                    b.Property<string>("Naam")
                        .IsRequired()
                        .HasColumnName("naam");

                    b.Property<int?>("TakId")
                        .HasColumnName("takId");

                    b.Property<string>("Voornaam")
                        .IsRequired()
                        .HasColumnName("voornaam");

                    b.HasKey("Id");

                    b.HasIndex("TakId");

                    b.ToTable("leiding");
                });

            modelBuilder.Entity("kangoeroes.core.Models.Poef.Drank", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<string>("ImageUrl")
                        .HasColumnName("imageUrl");

                    b.Property<bool>("InStock")
                        .HasColumnName("inStock");

                    b.Property<string>("Naam")
                        .IsRequired()
                        .HasColumnName("naam");

                    b.Property<int?>("TypeId")
                        .HasColumnName("typeId");

                    b.HasKey("Id");

                    b.HasIndex("TypeId");

                    b.ToTable("poef.drank");
                });

            modelBuilder.Entity("kangoeroes.core.Models.Poef.DrankType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<string>("Naam")
                        .IsRequired()
                        .HasColumnName("naam");

                    b.HasKey("Id");

                    b.HasAlternateKey("Naam");

                    b.ToTable("poef.drankType");
                });

            modelBuilder.Entity("kangoeroes.core.Models.Poef.Prijs", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnName("createdOn");

                    b.Property<int?>("DrankId")
                        .IsRequired()
                        .HasColumnName("drankId");

                    b.Property<decimal>("Waarde")
                        .HasColumnName("waarde");

                    b.HasKey("Id");

                    b.HasIndex("DrankId");

                    b.ToTable("poef.prijs");
                });

            modelBuilder.Entity("kangoeroes.core.Models.Tak", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<string>("Naam")
                        .IsRequired()
                        .HasColumnName("naam");

                    b.Property<int>("Volgorde")
                        .HasColumnName("volgorde");

                    b.HasKey("Id");

                    b.ToTable("tak");
                });

            modelBuilder.Entity("kangoeroes.core.Models.Totems.Adjectief", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnName("createdOn");

                    b.Property<string>("Naam")
                        .IsRequired()
                        .HasColumnName("naam");

                    b.HasKey("Id");

                    b.ToTable("totems.adjectief");
                });

            modelBuilder.Entity("kangoeroes.core.Models.Totems.Totem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnName("createdOn");

                    b.Property<string>("Naam")
                        .IsRequired()
                        .HasColumnName("naam");

                    b.HasKey("Id");

                    b.ToTable("totems.totem");
                });

            modelBuilder.Entity("kangoeroes.core.Models.Totems.TotemEntry", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<int?>("AdjectiefId")
                        .HasColumnName("adjectiefId");

                    b.Property<DateTime>("DatumGegeven")
                        .HasColumnName("datumGegeven");

                    b.Property<int?>("LeidingId")
                        .HasColumnName("leidingId");

                    b.Property<int?>("TotemId")
                        .HasColumnName("totemId");

                    b.Property<int?>("VoorouderId")
                        .HasColumnName("voorouderId");

                    b.HasKey("Id");

                    b.HasIndex("AdjectiefId");

                    b.HasIndex("LeidingId");

                    b.HasIndex("TotemId");

                    b.HasIndex("VoorouderId");

                    b.ToTable("totems.entry");
                });

            modelBuilder.Entity("kangoeroes.core.Models.Leiding", b =>
                {
                    b.HasOne("kangoeroes.core.Models.Tak", "Tak")
                        .WithMany("Leiding")
                        .HasForeignKey("TakId");
                });

            modelBuilder.Entity("kangoeroes.core.Models.Poef.Drank", b =>
                {
                    b.HasOne("kangoeroes.core.Models.Poef.DrankType", "Type")
                        .WithMany()
                        .HasForeignKey("TypeId");
                });

            modelBuilder.Entity("kangoeroes.core.Models.Poef.Prijs", b =>
                {
                    b.HasOne("kangoeroes.core.Models.Poef.Drank", "Drank")
                        .WithMany("Prijzen")
                        .HasForeignKey("DrankId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("kangoeroes.core.Models.Totems.TotemEntry", b =>
                {
                    b.HasOne("kangoeroes.core.Models.Totems.Adjectief", "Adjectief")
                        .WithMany()
                        .HasForeignKey("AdjectiefId");

                    b.HasOne("kangoeroes.core.Models.Leiding", "Leiding")
                        .WithMany()
                        .HasForeignKey("LeidingId");

                    b.HasOne("kangoeroes.core.Models.Totems.Totem", "Totem")
                        .WithMany()
                        .HasForeignKey("TotemId");

                    b.HasOne("kangoeroes.core.Models.Totems.TotemEntry", "Voorouder")
                        .WithMany("Afstammelingen")
                        .HasForeignKey("VoorouderId");
                });
#pragma warning restore 612, 618
        }
    }
}
