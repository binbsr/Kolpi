using Kolpi.Server.Models;
using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Kolpi.Shared.Models;

namespace Kolpi.Server.Data
{
    public class KolpiDbContext : ApiAuthorizationDbContext<KolpiUser>
    {
        public KolpiDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Renaming identity tables to more generic names
            modelBuilder.Entity<KolpiUser>().ToTable("Users");
            modelBuilder.Entity<IdentityRole>().ToTable("Roles");
            modelBuilder.Entity<IdentityRoleClaim<string>>().ToTable("RoleClaims");
            modelBuilder.Entity<IdentityUserClaim<string>>().ToTable("UserClaims");
            modelBuilder.Entity<IdentityUserLogin<string>>().ToTable("UserLogins");
            modelBuilder.Entity<IdentityUserRole<string>>().ToTable("UserRoles");
            modelBuilder.Entity<IdentityUserToken<string>>().ToTable("UserTokens");

            // Tag to tagtypes
            modelBuilder.Entity<Tag>()
                .HasOne(t => t.TagType)
                .WithMany(tt => tt.Tags);

            // Question and Tag, Join Table - many to many
            modelBuilder.Entity<QuestionTag>()
                .HasKey(t => new { t.QuestionId, t.TagId });

            modelBuilder.Entity<QuestionTag>()
                .HasOne(qt => qt.Question)
                .WithMany(q => q.QuestionTags)
                .HasForeignKey(qt => qt.QuestionId);

            modelBuilder.Entity<QuestionTag>()
                .HasOne(qt => qt.Tag)
                .WithMany(t => t.QuestionTags)
                .HasForeignKey(qt => qt.TagId);

            // ExamPaper and Question, Join table - many to many
            modelBuilder.Entity<ExamPaperQuestion>()
            .HasKey(t => new { t.ExamPaperId, t.QuestionId });

            modelBuilder.Entity<ExamPaperQuestion>()
                .HasOne(epq => epq.ExamPaper)
                .WithMany(e => e.ExamPaperQuestions)
                .HasForeignKey(epq => epq.ExamPaperId);

            modelBuilder.Entity<ExamPaperQuestion>()
                .HasOne(epq => epq.Question)
                .WithMany(q => q.ExamPaperQuestions)
                .HasForeignKey(epq => epq.QuestionId);

            // Questionstatus to Question (one to many)
            modelBuilder.Entity<Question>()
                .HasOne(q => q.QuestionStatus)
                .WithMany(qs => qs.Questions)
                .HasForeignKey(q => q.QuestionStatusId);
        }

        // Kolpi Db tables
        public DbSet<Question> Questions { get; set; }
        public DbSet<AnswerOption> AnswerOptions { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<TagType> TagTypes { get; set; }
        public DbSet<QuestionStatus> QuestionStatuses { get; set; }
        public DbSet<PrivilegeLookup> PrivilegeLookups { get; set; }
        public DbSet<ExamPaper> ExamPapers { get; set; }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<ExamPaperQuestion> ExamPaperQuestions { get; set; }
        public DbSet<QuestionTag> QuestionTags { get; set; }
    }
}
