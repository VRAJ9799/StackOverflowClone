using StackOverflowClone.DomainModels;
using System.Collections.Generic;

namespace StackOverflowClone.Repositories.Interfaces
{
    public interface ICategoriesRepository
    {
        void InsertCategory(Category category);
        void UpdateCategory(Category category);
        void DeleteCategory(int CategoryID);
        List<Category> GetCategories();
        List<Category> GetCategoriesByCategoryID(int CategoryID);
    }
}
