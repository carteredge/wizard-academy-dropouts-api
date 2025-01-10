﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WizardAcademyDropouts.Domain;

#nullable disable

namespace WizardAcademyDropouts.Migrations
{
    [DbContext(typeof(DropoutsDBContext))]
    partial class DropoutsDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WizardAcademyDropouts.Domain.Entities.Character", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Conjuration")
                        .HasColumnType("int");

                    b.Property<int>("Elementalism")
                        .HasColumnType("int");

                    b.Property<int>("Enchantment")
                        .HasColumnType("int");

                    b.Property<int>("FailureId")
                        .HasColumnType("int");

                    b.Property<int>("Hp")
                        .HasColumnType("int");

                    b.Property<int>("HpMax")
                        .HasColumnType("int");

                    b.Property<int>("Illusion")
                        .HasColumnType("int");

                    b.Property<int>("KnackId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Naturalism")
                        .HasColumnType("int");

                    b.Property<int>("Necromancy")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FailureId");

                    b.HasIndex("KnackId");

                    b.ToTable("Characters");
                });

            modelBuilder.Entity("WizardAcademyDropouts.Domain.Entities.Failure", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Summary")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Failures", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "I couldn't focus, and I changed my specialty constantly until my professors couldn't take it anymore. When you make a roll, you can drop the grade for the discipline of that roll by one letterand raise the grade of another discipline by one letter.",
                            Name = "DroppedOut",
                            Summary = "I dropped out."
                        },
                        new
                        {
                            Id = 2,
                            Description = "My spells are extra dangerous. I was kicked out for being a danger to the academy, myself, and everyone around me. My spells do +1 damage.",
                            Name = "KickedOut",
                            Summary = "I was kicked out."
                        },
                        new
                        {
                            Id = 3,
                            Description = "I'm so bad at magic, I'm resistant to it. Prevent 1 magical damage each round.",
                            Name = "FailedOut",
                            Summary = "I failed out."
                        });
                });

            modelBuilder.Entity("WizardAcademyDropouts.Domain.Entities.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CharacterId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CharacterId");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("WizardAcademyDropouts.Domain.Entities.Knack", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Knacks", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Outside of combat, you can use double the number of words for a spell if the words are phrased as a rhyming couplet.",
                            Name = "Bardic"
                        },
                        new
                        {
                            Id = 2,
                            Description = "You can sense the magic around you. You see auras of magic and can feel magic radiating off of items and spells. You get +1 to knowledge rolls for anything you can see or touch.",
                            Name = "Clairvoyant"
                        },
                        new
                        {
                            Id = 3,
                            Description = "One or both of your parents is a Wizard Academy graduate and a generous donor. You start with one extra item from the common loot table.",
                            Name = "Legacy"
                        },
                        new
                        {
                            Id = 4,
                            Description = "When all else fails, you aren't afraid to resort to good, old fashioned fisticuffs. You're stronger than the average wizard, and you can make a physical attack against an enemy as an action, dealing 1 damage to them. The enemy must be within striking damage or you must have something potentially dangerous to throw.",
                            Name = "Scrappy"
                        },
                        new
                        {
                            Id = 5,
                            Description = "You are remarkably resilient. You have +2 max HP.",
                            Name = "Sturdy"
                        },
                        new
                        {
                            Id = 6,
                            Description = "Whether with wings or an innate affinity for wind, you can fly.",
                            Name = "Windborne"
                        });
                });

            modelBuilder.Entity("WizardAcademyDropouts.Domain.Entities.Character", b =>
                {
                    b.HasOne("WizardAcademyDropouts.Domain.Entities.Failure", "Failure")
                        .WithMany()
                        .HasForeignKey("FailureId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WizardAcademyDropouts.Domain.Entities.Knack", "Knack")
                        .WithMany()
                        .HasForeignKey("KnackId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Failure");

                    b.Navigation("Knack");
                });

            modelBuilder.Entity("WizardAcademyDropouts.Domain.Entities.Item", b =>
                {
                    b.HasOne("WizardAcademyDropouts.Domain.Entities.Character", "Character")
                        .WithMany("Inventory")
                        .HasForeignKey("CharacterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Character");
                });

            modelBuilder.Entity("WizardAcademyDropouts.Domain.Entities.Character", b =>
                {
                    b.Navigation("Inventory");
                });
#pragma warning restore 612, 618
        }
    }
}
