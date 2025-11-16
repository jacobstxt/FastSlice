using AutoMapper;
using Core.Models.Category;
using Core.Models.Seeder;
using Domain.Entities;

namespace Core.Mapper
{
    public class CategoryMapper: Profile
    {
        public CategoryMapper() {

            CreateMap<SeederCategoryModel, CategoryEntity>();
            CreateMap<CategoryEntity, CategoryItemModel>();

        }
    }
}
