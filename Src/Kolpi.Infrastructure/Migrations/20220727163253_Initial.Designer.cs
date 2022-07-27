﻿// <auto-generated />
using System;
using Kolpi.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Kolpi.Infrastructure.Migrations
{
    [DbContext(typeof(KolpiDbContext))]
    [Migration("20220727163253_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.4");

            modelBuilder.Entity("Kolpi.ApplicationCore.Entities.AnswerOption", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Body")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsAnswer")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("ModifiedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("TEXT");

                    b.Property<int>("QuestionId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("QuestionId");

                    b.ToTable("AnswerOptions");
                });

            modelBuilder.Entity("Kolpi.ApplicationCore.Entities.Exam", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Attendees")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("TEXT");

                    b.Property<string>("Details")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<byte>("DurationHours")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("ModifiedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("StartsAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Exams");
                });

            modelBuilder.Entity("Kolpi.ApplicationCore.Entities.ExamPaper", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("TEXT");

                    b.Property<string>("Details")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("ExamId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("ModifiedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ExamId");

                    b.ToTable("ExamPapers");
                });

            modelBuilder.Entity("Kolpi.ApplicationCore.Entities.ExamPaperQuestion", b =>
                {
                    b.Property<int>("ExamPaperId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("QuestionId")
                        .HasColumnType("INTEGER");

                    b.HasKey("ExamPaperId", "QuestionId");

                    b.HasIndex("QuestionId");

                    b.ToTable("ExamPaperQuestions");
                });

            modelBuilder.Entity("Kolpi.ApplicationCore.Entities.KolpiUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("TEXT");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("TEXT");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("TEXT");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserName")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Users", (string)null);
                });

            modelBuilder.Entity("Kolpi.ApplicationCore.Entities.PrivilegeLookup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Details")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Label")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("ObjectiveAnswersCount")
                        .HasColumnType("INTEGER");

                    b.Property<int>("QuestionsCount")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ReviewsCount")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SubjectiveAnswersCount")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("PrivilegeLookups");
                });

            modelBuilder.Entity("Kolpi.ApplicationCore.Entities.Question", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Body")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("ModifiedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("TEXT");

                    b.Property<int>("QuestionStatusId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("QuestionStatusId");

                    b.ToTable("Questions");
                });

            modelBuilder.Entity("Kolpi.ApplicationCore.Entities.QuestionStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Details")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("QuestionStatuses");
                });

            modelBuilder.Entity("Kolpi.ApplicationCore.Entities.QuestionTag", b =>
                {
                    b.Property<int>("QuestionId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TagId")
                        .HasColumnType("INTEGER");

                    b.HasKey("QuestionId", "TagId");

                    b.HasIndex("TagId");

                    b.ToTable("QuestionTags");
                });

            modelBuilder.Entity("Kolpi.ApplicationCore.Entities.Tag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("TEXT");

                    b.Property<string>("Details")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsFinalized")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("ModifiedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("QuestionId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TagTypeId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("QuestionId");

                    b.HasIndex("TagTypeId");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("Kolpi.ApplicationCore.Entities.TagType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ColorCode")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Details")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("TagTypes");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedName")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Roles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClaimType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("TEXT");

                    b.Property<string>("RoleId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("RoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClaimType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("UserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.ToTable("UserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("RoleId")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId", "RoleId");

                    b.ToTable("UserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Value")
                        .HasColumnType("TEXT");

                    b.ToTable("UserTokens", (string)null);
                });

            modelBuilder.Entity("Kolpi.ApplicationCore.Entities.AnswerOption", b =>
                {
                    b.HasOne("Kolpi.ApplicationCore.Entities.Question", "Question")
                        .WithMany("AnswerOptions")
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Question");
                });

            modelBuilder.Entity("Kolpi.ApplicationCore.Entities.ExamPaper", b =>
                {
                    b.HasOne("Kolpi.ApplicationCore.Entities.Exam", null)
                        .WithMany("ExamPapers")
                        .HasForeignKey("ExamId");
                });

            modelBuilder.Entity("Kolpi.ApplicationCore.Entities.ExamPaperQuestion", b =>
                {
                    b.HasOne("Kolpi.ApplicationCore.Entities.ExamPaper", "ExamPaper")
                        .WithMany("ExamPaperQuestions")
                        .HasForeignKey("ExamPaperId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Kolpi.ApplicationCore.Entities.Question", "Question")
                        .WithMany("ExamPaperQuestions")
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ExamPaper");

                    b.Navigation("Question");
                });

            modelBuilder.Entity("Kolpi.ApplicationCore.Entities.Question", b =>
                {
                    b.HasOne("Kolpi.ApplicationCore.Entities.QuestionStatus", "QuestionStatus")
                        .WithMany("Questions")
                        .HasForeignKey("QuestionStatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("QuestionStatus");
                });

            modelBuilder.Entity("Kolpi.ApplicationCore.Entities.QuestionTag", b =>
                {
                    b.HasOne("Kolpi.ApplicationCore.Entities.Question", "Question")
                        .WithMany("QuestionTags")
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Kolpi.ApplicationCore.Entities.Tag", "Tag")
                        .WithMany("QuestionTags")
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Question");

                    b.Navigation("Tag");
                });

            modelBuilder.Entity("Kolpi.ApplicationCore.Entities.Tag", b =>
                {
                    b.HasOne("Kolpi.ApplicationCore.Entities.Question", null)
                        .WithMany("Tags")
                        .HasForeignKey("QuestionId");

                    b.HasOne("Kolpi.ApplicationCore.Entities.TagType", "TagType")
                        .WithMany("Tags")
                        .HasForeignKey("TagTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TagType");
                });

            modelBuilder.Entity("Kolpi.ApplicationCore.Entities.Exam", b =>
                {
                    b.Navigation("ExamPapers");
                });

            modelBuilder.Entity("Kolpi.ApplicationCore.Entities.ExamPaper", b =>
                {
                    b.Navigation("ExamPaperQuestions");
                });

            modelBuilder.Entity("Kolpi.ApplicationCore.Entities.Question", b =>
                {
                    b.Navigation("AnswerOptions");

                    b.Navigation("ExamPaperQuestions");

                    b.Navigation("QuestionTags");

                    b.Navigation("Tags");
                });

            modelBuilder.Entity("Kolpi.ApplicationCore.Entities.QuestionStatus", b =>
                {
                    b.Navigation("Questions");
                });

            modelBuilder.Entity("Kolpi.ApplicationCore.Entities.Tag", b =>
                {
                    b.Navigation("QuestionTags");
                });

            modelBuilder.Entity("Kolpi.ApplicationCore.Entities.TagType", b =>
                {
                    b.Navigation("Tags");
                });
#pragma warning restore 612, 618
        }
    }
}
