using StackOverflowClone.ViewModels;
using System.Collections.Generic;
namespace StackOverflowClone.ServiceLayer.Interfaces
{
    public interface ICategoriesService
    {
        void InsertCategory(CategoryViewModel categoryViewModel);
        void UpdateCategory(CategoryViewModel categoryViewModel);
        void DeleteCategory(int categoryID);
        List<CategoryViewModel> GetCategories();
        CategoryViewModel GetCategoryByCategoryID(int categoryID);
    }
}
