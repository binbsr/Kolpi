using Kolpi.ApplicationCore.Entities;

namespace Kolpi.UnitTests
{
    public class TagTypeBuilder
    {
        private TagType tagType = new TagType();

        public TagTypeBuilder Id(int id)
        {
            tagType.Id = id;
            return this;
        }

        public TagTypeBuilder Name(string name)
        {
            tagType.Name = name;
            return this;
        }

        public TagTypeBuilder Details(string details)
        {
            tagType.Details = details;
            return this;
        }

        public TagTypeBuilder ColorCode(string color)
        {
            tagType.ColorCode = color;
            return this;
        }

        public TagTypeBuilder WithDefaultValues()
        {
            tagType = new TagType { Id = 1, Name = "Complexity", Details = "Defines complexity levels of questions.", ColorCode = "orange" };
            return this;
        }

        public TagType Build() => tagType;
    }
}
