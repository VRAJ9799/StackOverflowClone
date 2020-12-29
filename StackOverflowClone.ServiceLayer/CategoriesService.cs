using AutoMapper;
using StackOverflowClone.DomainModels;
using StackOverflowClone.Repositories;
using StackOverflowClone.Repositories.Interfaces;
using StackOverflowClone.ServiceLayer.Interfaces;
using StackOverflowClone.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace StackOverflowClone.ServiceLayer
{
    public class CategoriesService : ICategoriesService
    {
        ICategoriesRepository CategoriesRepository;
        public CategoriesService()
        {
            CategoriesRepository = new CategoriesRepository();
        }
        public void InsertCategory(CategoryViewModel categoryViewModel)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CategoryViewModel, Category>();
                cfg.IgnoreUnmapped();
            });
            IMapper mapper = config.CreateMapper();
            Category category = mapper.Map<CategoryViewModel, Category>(categoryViewModel);
            CategoriesRepository.InsertCategory(category);
        }
        public void UpdateCategory(CategoryViewModel categoryViewModel)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CategoryViewModel, Category>();
                cfg.IgnoreUnmapped();
            });
            IMapper mapper = config.CreateMapper();
            Category category = mapper.Map<CategoryViewModel, Category>(categoryViewModel);
            CategoriesRepository.UpdateCategory(category);
        }
        public void DeleteCategory(int categoryID)
        {
            CategoriesRepository.DeleteCategory(categoryID);
        }
        public List<CategoryViewModel> GetCategories()
        {
            List<Category> categories = CategoriesRepository.GetCategories();
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Category, CategoryViewModel>();
                cfg.IgnoreUnmapped();
            });
            IMapper mapper = config.CreateMapper();
            List<CategoryViewModel> categoryViewModels = mapper.Map<List<Category>, List<CategoryViewModel>>(categories);
            return categoryViewModels;
        }
        public CategoryViewModel GetCategoryByCategoryID(int categoryID)
        {
            Category category = CategoriesRepository.GetCategoriesByCategoryID(categoryID).FirstOrDefault();
            CategoryViewModel categoryViewModel = null;
            if (category != null)
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<Category, CategoryViewModel>();
                    cfg.IgnoreUnmapped();
                });
                IMapper mapper = config.CreateMapper();
                categoryViewModel = mapper.Map<Category, CategoryViewModel>(category);
            }
            return categoryViewModel;
        }
    }
}
