using Kolpi.ApplicationCore.Entities;

namespace Kolpi.UnitTests
{
    public class TagBuilder
    {
        private Tag tag = new Tag();

        public TagBuilder Id(int id)
        {
            tag.Id = id;
            return this;
        }

        public TagBuilder Name(string name)
        {
            tag.Name = name;
            return this;
        }

        public TagBuilder Details(string details)
        {
            tag.Details = details;
            return this;
        }

        public TagBuilder TagType(TagType tagType)
        {
            tag.TagType = tagType;
            return this;
        }

        public TagBuilder WithDefaultValues()
        {
            tag = new Tag { Id = 1, Name = "Level-1", Details = "Simplest objective questions.", TagType = new TagTypeBuilder().WithDefaultValues().Build() };
            return this;
        }

        public Tag Build() => tag;
    }
}
