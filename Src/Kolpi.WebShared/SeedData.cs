using Kolpi.ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace Kolpi.WebShared
{
    public static class SeedData
    {
        public static readonly TagType TagType1 = new TagType
        {
            Name = "Complexity",
            Details = "Tags that defines complexities of the question e.g. level-1, level-2 etc.",
            ColorCode = "green"
        };

        public static readonly TagType TagType2 = new TagType
        {
            Name = "Subject",
            Details = "Tags that defines subject categories of the question e.g. GK, GK-History, Physics etc.",
            ColorCode = "orange"
        };

        public static readonly Tag Tag1 = new Tag
        {
            Name = "Level-1",
            Details = "Defines simplest objective questions.",
            TagType = TagType1,
            CreatedAt = DateTime.UtcNow,
            CreatedBy = "Test User",
        };

        public static readonly Tag Tag2 = new Tag
        {
            Name = "GK",
            Details = "Defines general knowledge questions.",
            TagType = TagType2,
            CreatedAt = DateTime.UtcNow,
            CreatedBy = "Test User",
        };

        //public static void Initialize(IServiceProvider serviceProvider)
        //{
        //    using (var dbContext = new KolpiDbContext(
        //        serviceProvider.GetRequiredService<DbContextOptions<KolpiDbContext>>(), null))
        //    {
        //        // Check tables one by one, if empty fill that up, if data is there, assume its been already seeded
        //        if (!dbContext.TagTypes.Any())
        //        {
        //            PopulateTagTypes(dbContext);
        //        }

        //        if (!dbContext.Tags.Any())
        //        {
        //            PopulateTags(dbContext);
        //        }
        //    }
        //}
        //public static void PopulateTestData(KolpiDbContext dbContext)
        //{
        //    PopulateTagTypes(dbContext);
        //    PopulateTags(dbContext);
        //}

        //public static void PopulateTagTypes(KolpiDbContext dbContext)
        //{
        //    // Remove all rows before inserting
        //    var tagTypesInTable = dbContext.TagTypes.ToList();
        //    if (tagTypesInTable.Any())
        //        dbContext.TagTypes.RemoveRange(tagTypesInTable);

        //    dbContext.TagTypes.Add(TagType1);
        //    dbContext.TagTypes.Add(TagType2);
        //    dbContext.SaveChanges();
        //}

        //public static void PopulateTags(KolpiDbContext dbContext)
        //{
        //    // Remove all rows before inserting
        //    var tagsInTable = dbContext.Tags.ToList();
        //    if (tagsInTable.Any())
        //        dbContext.Tags.RemoveRange(tagsInTable);

        //    dbContext.Tags.Add(Tag1);
        //    dbContext.Tags.Add(Tag2);
        //    dbContext.SaveChanges();
        //}
    }
}
