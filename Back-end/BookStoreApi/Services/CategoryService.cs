using MongoDB.Driver;
using BookStoreApi.Models;
using Microsoft.Extensions.Options;
using BookStoreApi.RepositoryPattern;
using BookStoreApi.Interfaces;
namespace BookStoreApi.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        public CategoryService()
        {
            this._unitOfWork = GetUnitOfWork.UnitOfWork();
        }
        public async Task<IEnumerable<Category>> GetCategory() => await this._unitOfWork.CategoryRepository.Get();
        public async Task<Category?> GetCategoryById(string id) => await this._unitOfWork.CategoryRepository.GetByID(id);
        public async Task CreateCategory(Category newCategory) => await this._unitOfWork.CategoryRepository.Insert(newCategory);
        public async Task UpdateCategory(string id,Category updateCategory) => await this._unitOfWork.CategoryRepository.Update(updateCategory);
        public async Task DeleteCategory(string id) => await this._unitOfWork.CategoryRepository.Delete(id);
        public async Task<IEnumerable<Category>> ValidateCategory(string id, string name) => await this._unitOfWork.CategoryRepository.Get(x=>x.Id != id && x.Name == name);
    }
}