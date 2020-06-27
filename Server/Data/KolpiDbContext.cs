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

            // Question and Tag

            
            // ExamPaperQuestion (Join table)
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


            // Question to questionType (one to zero)
            modelBuilder.Entity<Question>()
                .HasOne(c => c.QuestionType)
                .WithMany()
                .HasForeignKey(q => q.QuestionTypeId);


        }

        // Kolpi Db tables
        public DbSet<Question> Questions { get; set; }
        public DbSet<AnswerOption> AnswerOptions { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<TagType> TagTypes { get; set; }
        public DbSet<QuestionType> QuestionTypes { get; set; }
        public DbSet<QuestionStatus> QuestionStatuses { get; set; }
        public DbSet<Reputation> Reputations { get; set; }
        public DbSet<ExamPaper> ExamPapers { get; set; }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<ExamPaperQuestion> ExamPaperQuestions { get; set; }

    }
}
