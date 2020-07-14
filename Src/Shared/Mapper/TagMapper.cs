using System.Collections.Generic;
using Kolpi.Shared.Extentions;
using Kolpi.Shared.Models;
using Kolpi.Shared.ViewModels;

namespace Kolpi.Shared.Mapper
{
    public static class TagMapper
    {
        public static TagViewModel ToViewModel(this Tag model)
        {
            if (model == null)
                return null;

            var tagViewModel = new TagViewModel
            {
                Id = model.Id,
                Name = model.Name,
                Details = model.Details,
                IsFinalized = model.IsFinalized,
                CreatedBy = model.CreatedBy,
                CreatedAt = model.CreatedAt.Relativize(),
                ModifiedBy = model.ModifiedBy,
                ModifiedAt = model.ModifiedAt.Relativize(),
                TagTypeId = model.TagTypeId,
                TagTypeName = model.TagType?.Name,
                TagColorCode = model.TagType?.ColorCode
            };

            return tagViewModel;
        }

        public static Tag ToModel(this TagViewModel viewModel)
        {
            if (viewModel == null)
                return null;

            var tagModel = new Tag
            {
                Id = viewModel.Id,
                Name = viewModel.Name,
                Details = viewModel.Details,
                IsFinalized = viewModel.IsFinalized,
                TagTypeId = viewModel.TagTypeId
            };

            return tagModel;
        }

        public static List<TagViewModel> ToViewModel(this IEnumerable<Tag> tagModels)
        {
            List<TagViewModel> tagViewModels = new List<TagViewModel>();
            foreach (var model in tagModels)
            {
                tagViewModels.Add(model.ToViewModel());
            }

            return tagViewModels;
        }

        public static List<Tag> ToModel(this IEnumerable<TagViewModel> tagViewModels)
        {
            List<Tag> tagModels = new List<Tag>();
            foreach (var model in tagViewModels)
            {
                tagModels.Add(model.ToModel());
            }

            return tagModels;
        }
    }
}
