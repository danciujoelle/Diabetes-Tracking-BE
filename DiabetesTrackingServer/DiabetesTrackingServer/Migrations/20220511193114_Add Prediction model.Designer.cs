﻿// <auto-generated />
using System;
using DiabetesTrackingServer.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DiabetesTrackingServer.Migrations
{
    [DbContext(typeof(DiabetesTrackingContext))]
    [Migration("20220511193114_Add Prediction model")]
    partial class AddPredictionmodel
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.15")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DiabetesTrackingServer.ViewModels.DiabetesPrediction", b =>
                {
                    b.Property<Guid>("PredictionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<float>("BloodPressure")
                        .HasColumnType("real");

                    b.Property<float>("BodyMassIndex")
                        .HasColumnType("real");

                    b.Property<float>("Glucose")
                        .HasColumnType("real");

                    b.Property<float>("Insulin")
                        .HasColumnType("real");

                    b.Property<int>("Outcome")
                        .HasColumnType("int");

                    b.Property<int>("Pregnancies")
                        .HasColumnType("int");

                    b.Property<float>("SkinThickness")
                        .HasColumnType("real");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("UserId1")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("PredictionId");

                    b.HasIndex("UserId1");

                    b.ToTable("DiabetesPredictions");
                });

            modelBuilder.Entity("DiabetesTrackingServer.ViewModels.User", b =>
                {
                    b.Property<Guid>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("DiabetesTrackingServer.ViewModels.DiabetesPrediction", b =>
                {
                    b.HasOne("DiabetesTrackingServer.ViewModels.User", "User")
                        .WithMany("DiabetesPredictions")
                        .HasForeignKey("UserId1");

                    b.Navigation("User");
                });

            modelBuilder.Entity("DiabetesTrackingServer.ViewModels.User", b =>
                {
                    b.Navigation("DiabetesPredictions");
                });
#pragma warning restore 612, 618
        }
    }
}
