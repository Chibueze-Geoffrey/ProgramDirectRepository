﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProgramDirect.Infrastruture.Data;

#nullable disable

namespace ProgramDirect.Infrastruture.Migrations
{
    [DbContext(typeof(ProgramDirectDbContext))]
    [Migration("20240512203132_MakeOptionsNullable")]
    partial class MakeOptionsNullable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ProgramDirect.Domain.Entities.ApplicationQuestion", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("MaximumChoices")
                        .HasColumnType("int");

                    b.Property<int>("MinimumChoices")
                        .HasColumnType("int");

                    b.Property<string>("Options")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("OrganisationProgramId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Question")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("OrganisationProgramId");

                    b.ToTable("ApplicationQuestions");
                });

            modelBuilder.Entity("ProgramDirect.Domain.Entities.ApplicationQuestionAnswer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Answer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("ApplicationId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ApplicationQuestionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationQuestionId");

                    b.ToTable("ApplicationQuestionAnswers");
                });

            modelBuilder.Entity("ProgramDirect.Domain.Entities.OrganisationProgram", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("OrganisationPrograms");
                });

            modelBuilder.Entity("ProgramDirect.Domain.Entities.ProgramApplication", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("DateOfBirth")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("IdentificationNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nationality")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("OrganisationProgramId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("OrganisationProgramId");

                    b.ToTable("ProgramApplications");
                });

            modelBuilder.Entity("ProgramDirect.Domain.Entities.ApplicationQuestion", b =>
                {
                    b.HasOne("ProgramDirect.Domain.Entities.OrganisationProgram", "OrganisationProgram")
                        .WithMany()
                        .HasForeignKey("OrganisationProgramId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("OrganisationProgram");
                });

            modelBuilder.Entity("ProgramDirect.Domain.Entities.ApplicationQuestionAnswer", b =>
                {
                    b.HasOne("ProgramDirect.Domain.Entities.ApplicationQuestion", "ApplicationQuestion")
                        .WithMany()
                        .HasForeignKey("ApplicationQuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ApplicationQuestion");
                });

            modelBuilder.Entity("ProgramDirect.Domain.Entities.ProgramApplication", b =>
                {
                    b.HasOne("ProgramDirect.Domain.Entities.OrganisationProgram", "OrganisationProgram")
                        .WithMany()
                        .HasForeignKey("OrganisationProgramId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("OrganisationProgram");
                });
#pragma warning restore 612, 618
        }
    }
}
