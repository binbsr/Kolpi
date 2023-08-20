using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Kolpi.ApplicationCore.Entities;

namespace Kolpi.Infrastructure.Data
{
    public class KolpiDbContext : DbContext
    {
        public KolpiDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=KolpiStudyDb;Trusted_Connection=True;MultipleActiveResultSets=true");
            }
        }

        // Kolpi Db tables
        public DbSet<Question> Questions { get; set; } = default!;
        public DbSet<AnswerOption> AnswerOptions { get; set; } = default!;
        public DbSet<Tag> Tags { get; set; } = default!;
        public DbSet<TagType> TagTypes { get; set; } = default!;
        public DbSet<QuestionStatus> QuestionStatuses { get; set; } = default!;
        public DbSet<PrivilegeLookup> PrivilegeLookups { get; set; } = default!;
        public DbSet<ExamPaper> ExamPapers { get; set; } = default!;
        public DbSet<Exam> Exams { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Renaming identity tables to more generic names
            modelBuilder.Entity<KolpiUser>().ToTable("Users");
            modelBuilder.Entity<IdentityRole>().ToTable("Roles");
            modelBuilder.Entity<IdentityRoleClaim<string>>().ToTable("RoleClaims");
            modelBuilder.Entity<IdentityUserClaim<string>>().ToTable("UserClaims");
            modelBuilder.Entity<IdentityUserLogin<string>>().ToTable("UserLogins")
                .HasNoKey();
            modelBuilder.Entity<IdentityUserRole<string>>().ToTable("UserRoles")
                .HasKey(x => new { x.UserId, x.RoleId });
            modelBuilder.Entity<IdentityUserToken<string>>().ToTable("UserTokens")
                .HasNoKey();

            // Tag to tagtypes
            modelBuilder.Entity<Tag>()
                .HasOne(t => t.TagType)
                .WithMany(tt => tt.Tags);

            // Questionstatus to Question (one to many)
            modelBuilder.Entity<Question>()
                .HasOne(q => q.QuestionStatus)
                .WithMany(qs => qs.Questions)
                .HasForeignKey(q => q.QuestionStatusId);

            //Seeding

            modelBuilder.Entity<TagType>()
                .HasData(
                    new TagType
                    {
                        Id = 1,
                        Name = "Complexity",
                        Details = "Tags that defines complexities of the question e.g. level-1, level-2 etc.",
                        ColorCode = "green"
                    },
                    new TagType
                    {
                        Id = 2,
                        Name = "Subject",
                        Details = "Tags that defines subject categories of the question e.g. GK, GK-History, Physics etc.",
                        ColorCode = "orange"
                    }
                );

            modelBuilder.Entity<Tag>()
                .HasData(
                    new Tag
                    {
                        Id = 1,
                        Name = "Level-1",
                        Details = "Defines simplest objective questions.",
                        TagTypeId = 1,
                        CreatedAt = DateTime.Now
                    },
                    new Tag
                    {
                        Id = 2,
                        Name = "Level-2",
                        Details = "Defines questions harder than level-1",
                        TagTypeId = 1,
                        CreatedAt = DateTime.Now
                    },
                    new Tag
                    {
                        Id = 3,
                        Name = "GK",
                        Details = "Defines general knowledge questions.",
                        TagTypeId = 2,
                        CreatedAt = DateTime.Now
                    }
                );

            modelBuilder.Entity<QuestionStatus>()
                .HasData(
                new QuestionStatus 
                {
                    Id = 1,
                    Name = "New",
                    Details = "QUestion just added"
                },
                new QuestionStatus 
                {
                    Id= 2,
                    Name = "Review",
                    Details = "Question is being reviewed"
                },
                new QuestionStatus
                {
                    Id = 3,
                    Name = "Publish",
                    Details = "Question finalized and can be published"
                });
        }
    }
}
