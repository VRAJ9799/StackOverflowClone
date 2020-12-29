using StackOverflowClone.DomainModels;
using StackOverflowClone.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace StackOverflowClone.Repositories
{

    public class CategoriesRepository : ICategoriesRepository
    {
        StackOverflowDatabaseDbContext db;
        public CategoriesRepository()
        {
            db = new StackOverflowDatabaseDbContext();
        }
        public void InsertCategory(Category category)
        {
            db.Categories.Add(category);
            db.SaveChanges();
        }
        public void UpdateCategory(Category category)
        {
            Category category1 = db.Categories.Where(temp => temp.CategoryID == category.CategoryID).FirstOrDefault();
            if (category1 != null)
            {
                category1.CategoryName = category.CategoryName;
                db.SaveChanges();
            }
        }
        public void DeleteCategory(int CategoryID)
        {
            Category category1 = db.Categories.Where(temp => temp.CategoryID == CategoryID).FirstOrDefault();
            if (category1 != null)
            {
                db.Categories.Remove(category1);
                db.SaveChanges();
            }
        }
        public List<Category> GetCategories()
        {
            List<Category> categories = db.Categories.ToList();
            return categories;
        }
        public List<Category> GetCategoriesByCategoryID(int CategoryID)
        {
            List<Category> categories = db.Categories.Where(temp => temp.CategoryID == CategoryID).ToList();
            return categories;
        }
    }
}
