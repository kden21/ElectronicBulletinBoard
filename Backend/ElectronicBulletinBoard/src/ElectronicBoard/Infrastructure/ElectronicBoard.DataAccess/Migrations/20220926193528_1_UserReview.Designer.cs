// <auto-generated />
using System;
using ElectronicBoard.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ElectronicBoard.DataAccess.Migrations
{
    [DbContext(typeof(ElectronicBoardContext))]
    [Migration("20220926193528_1_UserReview")]
    partial class _1_UserReview
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ElectronicBoard.Domain.AdvtEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryEntityId")
                        .HasColumnType("integer");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<DateTime>("ModifyDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Photo")
                        .HasColumnType("text");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<int>("UserEntityId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("CategoryEntityId");

                    b.HasIndex("UserEntityId");

                    b.ToTable("AdvtEntity");
                });

            modelBuilder.Entity("ElectronicBoard.Domain.CategoryEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<DateTime>("ModifyDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("ParentCategoryEntityId1")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ParentCategoryEntityId1");

                    b.ToTable("CategoryEntity");
                });

            modelBuilder.Entity("ElectronicBoard.Domain.Review.AdvtReviewEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("AdvtEntityId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("ModifyDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<double?>("Rating")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.HasIndex("AdvtEntityId");

                    b.ToTable("AdvtReviewEntity");
                });

            modelBuilder.Entity("ElectronicBoard.Domain.Review.UserReviewEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("ModifyDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<double?>("Rating")
                        .HasColumnType("double precision");

                    b.Property<int?>("UserEntityId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("UserEntityId");

                    b.ToTable("UserReviews", (string)null);
                });

            modelBuilder.Entity("ElectronicBoard.Domain.UserEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Birthday")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("MiddleName")
                        .HasColumnType("text");

                    b.Property<DateTime>("ModifyDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<string>("Photo")
                        .HasColumnType("text");

                    b.Property<int>("Role")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("UserEntity");
                });

            modelBuilder.Entity("ElectronicBoard.Domain.AdvtEntity", b =>
                {
                    b.HasOne("ElectronicBoard.Domain.CategoryEntity", "CategoryEntity")
                        .WithMany("AdvtEntities")
                        .HasForeignKey("CategoryEntityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ElectronicBoard.Domain.UserEntity", "UserEntity")
                        .WithMany("AdvtEntities")
                        .HasForeignKey("UserEntityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CategoryEntity");

                    b.Navigation("UserEntity");
                });

            modelBuilder.Entity("ElectronicBoard.Domain.CategoryEntity", b =>
                {
                    b.HasOne("ElectronicBoard.Domain.CategoryEntity", "ParentCategoryEntity")
                        .WithMany("ChildCategoryEntities")
                        .HasForeignKey("ParentCategoryEntityId1");

                    b.Navigation("ParentCategoryEntity");
                });

            modelBuilder.Entity("ElectronicBoard.Domain.Review.AdvtReviewEntity", b =>
                {
                    b.HasOne("ElectronicBoard.Domain.AdvtEntity", "AdvtEntity")
                        .WithMany("AdvtReviewEntities")
                        .HasForeignKey("AdvtEntityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AdvtEntity");
                });

            modelBuilder.Entity("ElectronicBoard.Domain.Review.UserReviewEntity", b =>
                {
                    b.HasOne("ElectronicBoard.Domain.UserEntity", null)
                        .WithMany("UserReviewEntities")
                        .HasForeignKey("UserEntityId");
                });

            modelBuilder.Entity("ElectronicBoard.Domain.AdvtEntity", b =>
                {
                    b.Navigation("AdvtReviewEntities");
                });

            modelBuilder.Entity("ElectronicBoard.Domain.CategoryEntity", b =>
                {
                    b.Navigation("AdvtEntities");

                    b.Navigation("ChildCategoryEntities");
                });

            modelBuilder.Entity("ElectronicBoard.Domain.UserEntity", b =>
                {
                    b.Navigation("AdvtEntities");

                    b.Navigation("UserReviewEntities");
                });
#pragma warning restore 612, 618
        }
    }
}
