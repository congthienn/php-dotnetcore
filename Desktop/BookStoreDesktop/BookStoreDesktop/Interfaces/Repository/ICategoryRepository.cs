using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStoreDesktop.Models;

namespace BookStoreDesktop.Interfaces.Repository
{
    public interface ICategoryRepository
    {
        List<Category> GetAllCategory();
        Category GetCategoroyById(int id);
        void CreateCategory(Category category);
        void UpdateCategory(Category category);
        void DeleteCategory(Category category);
        List<Category> GetCategoryByName(string name);
        Category validateName(string name,int id);
    }
}