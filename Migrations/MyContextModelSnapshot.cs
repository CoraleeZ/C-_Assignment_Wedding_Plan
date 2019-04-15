﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Wedding_Planner.Models;

namespace Wedding_Planner.Migrations
{
    [DbContext(typeof(MyContext))]
    partial class MyContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Wedding_Planner.Models.Resevation", b =>
                {
                    b.Property<int>("ResevationId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("UserId");

                    b.Property<int>("WeddingPlanId");

                    b.HasKey("ResevationId");

                    b.HasIndex("UserId");

                    b.HasIndex("WeddingPlanId");

                    b.ToTable("Resevationes");
                });

            modelBuilder.Entity("Wedding_Planner.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("Firstname")
                        .IsRequired();

                    b.Property<string>("Lastname")
                        .IsRequired();

                    b.Property<string>("Password")
                        .IsRequired();

                    b.Property<DateTime>("UpdatedAt");

                    b.HasKey("UserId");

                    b.ToTable("Useres");
                });

            modelBuilder.Entity("Wedding_Planner.Models.WeddingPlan", b =>
                {
                    b.Property<int>("WeddingPlanId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address")
                        .IsRequired();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("Date")
                        .IsRequired();

                    b.Property<DateTime>("UpdatedAt");

                    b.Property<int>("UserId");

                    b.Property<string>("WedderOne")
                        .IsRequired();

                    b.Property<string>("WedderTwo")
                        .IsRequired();

                    b.HasKey("WeddingPlanId");

                    b.HasIndex("UserId");

                    b.ToTable("WeddingPlanes");
                });

            modelBuilder.Entity("Wedding_Planner.Models.Resevation", b =>
                {
                    b.HasOne("Wedding_Planner.Models.User", "User")
                        .WithMany("UpcomingWeddings")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Wedding_Planner.Models.WeddingPlan", "WeddingPlan")
                        .WithMany("Guests")
                        .HasForeignKey("WeddingPlanId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Wedding_Planner.Models.WeddingPlan", b =>
                {
                    b.HasOne("Wedding_Planner.Models.User", "User")
                        .WithMany("CreatedPlans")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
