using System.Collections.Generic;
using Kolpi.ApplicationCore.Entities;
using Kolpi.WebShared.ViewModels;

namespace Kolpi.Shared.Mapper
{
    public static class TagTypeMapper
    {
        public static TagTypeViewModel ToViewModel(this TagType model)
        {
            if (model == null)
                return default!;

            var tagTypeViewModel = new TagTypeViewModel { 
                    Id = model.Id,
                    Name = model.Name,
                    Details = model.Details,
                    ColorCode = model.ColorCode
                };

            return tagTypeViewModel;
        }

        public static TagType ToModel(this TagTypeViewModel viewModel)
        {
            if (viewModel == null)
                return default!;
                
            var tagTypeModel = new TagType
            {
                Id = viewModel.Id,
                Name = viewModel.Name,
                Details = viewModel.Details,
                ColorCode = viewModel.ColorCode
            };

            return tagTypeModel;
        }

        public static IEnumerable<TagTypeViewModel> ToViewModel(this IEnumerable<TagType> tagTypeModels)
        {
            List<TagTypeViewModel> tagTypeViewModels = new List<TagTypeViewModel>();
            foreach (var model in tagTypeModels)
            {
                tagTypeViewModels.Add(model.ToViewModel());
            }

            return tagTypeViewModels;
        }

        public static IEnumerable<TagType> ToModel(this IEnumerable<TagTypeViewModel> tagTypeViewModels)
        {
            List<TagType> tagTypeModels = new List<TagType>();
            foreach (var model in tagTypeViewModels)
            {
                tagTypeModels.Add(model.ToModel());
            }

            return tagTypeModels;
        }
    }
}
