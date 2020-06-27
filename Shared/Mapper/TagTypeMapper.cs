using System;
using System.Collections.Generic;
using System.Text;
using Kolpi.Shared.Models;
using Kolpi.Shared.ViewModels;

namespace Kolpi.Shared.Mapper
{
    public static class TagTypeMapper
    {
        public static TagTypeViewModel ToViewModel(this TagType model)
        {
            if (model == null)
                return null;

            var tagTypeViewModel = new TagTypeViewModel { 
                    Id = model.Id,
                    Name = model.Name,
                    Details = model.Details
                };

            return tagTypeViewModel;
        }

        public static TagType ToModel(this TagTypeViewModel viewModel)
        {
            if (viewModel == null)
                return null;
                
            var tagTypeModel = new TagType
            {
                Id = viewModel.Id,
                Name = viewModel.Name,
                Details = viewModel.Details
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
