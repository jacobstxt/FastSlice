using AutoMapper;
using Core.Interfaces;
using Core.Models.Category;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Core.Services
{
    public class CategoryService(AppDbContext Context,
    IMapper mapper, IImageService imageService) : ICategoryService
    {

        public async Task<CategoryItemModel?> GetItemById(int id)
        {
            var model = await mapper
            .ProjectTo<CategoryItemModel>(Context.Categories.Where(x => !x.IsDeleted).Where(x => x.Id == id))
            .SingleOrDefaultAsync();
            return model;
        }

        public async Task<List<CategoryItemModel>> List()
        {
            var model = await mapper.ProjectTo<CategoryItemModel>(Context.Categories.Where(x => !x.IsDeleted))
           .ToListAsync();
            return model;
        }

    }


}
