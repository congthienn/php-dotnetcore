using BookStoreDesktop.Models;
using AutoMapper;
using BookStoreDesktop.Interfaces;
using BookStoreDesktop.Automapper;
using BookStoreDesktop.BookStoreDatabase;
using Microsoft.EntityFrameworkCore;
using BookStoreDesktop.Autofac;
using BookStoreDesktop.Interfaces.Repository;

namespace BookStoreDesktop.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryService()
        {
            _categoryRepository = AutofacInstance.GetInstance<ICategoryRepository>();
        }

        public bool CreateCategory(CategoryDTO categoryDTO)
        {
            Category newCategory = new Category();
            ConfigMapper.configMapper().Map(categoryDTO, newCategory);
            Category validateName = this._categoryRepository.validateName(newCategory.Name, newCategory.Id);
            if(validateName != null)
            {
                return false;
            }
             this._categoryRepository.CreateCategory(newCategory);
            return true;
        }
        public bool DeleteCategory(int id)
        {
            Category category = this._categoryRepository.GetCategoroyById(id);
            if(category is null)
            {
                return false;
            }
            this._categoryRepository.DeleteCategory(category);
            return true;
        }

        public List<Category> GetAllCategory()
        {
            return this._categoryRepository.GetAllCategory();
        }

        public List<Category> GetCategoryByName(string name)
        {
            return this._categoryRepository.GetCategoryByName(name);
        }

        public bool UpdateCategory(CategoryDTO categoryDTO, int id)
        {
            Category category = this._categoryRepository.GetCategoroyById(id);
            ConfigMapper.configMapper().Map(categoryDTO, category);
            Category validateName = this._categoryRepository.validateName(category.Name, category.Id);
            if (validateName != null)
            {
                return false;
            }
            else
            {
                this._categoryRepository.UpdateCategory(category);
                return true;
            }
        }
    }
}