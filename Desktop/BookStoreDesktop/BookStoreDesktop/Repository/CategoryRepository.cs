using BookStoreDesktop.Interfaces.Repository;
using BookStoreDesktop.Models;
using BookStoreDesktop.BookStoreDatabase;
using Microsoft.EntityFrameworkCore;

namespace BookStoreDesktop.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        public void CreateCategory(Category category)
        {
            using(var _context = new BookStoreContext())
            {
                _context.Categories.Add(category);
                _context.SaveChanges();
            }
        }
        public void DeleteCategory(Category category)
        {
            using(var _context = new BookStoreContext())
            {
                _context.Categories.Remove(category);
                _context.SaveChanges();
            }
        }
        public List<Category> GetAllCategory()
        {
            using(var _context = new BookStoreContext())
            {
                return _context.Categories.AsNoTracking().ToList();
            }
        }
        public Category GetCategoroyById(int id)
        {
            using(var _context = new BookStoreContext())
            {
                return _context.Categories.Find(id);
            }
        }
        public List<Category> GetCategoryByName(string name)
        {
            using(var _context = new BookStoreContext())
            {
                return _context.Categories.Where(x => x.Name.Contains(name)).ToList();
            }
        }
        public void UpdateCategory(Category category)
        {
            using(var _context = new BookStoreContext())
            {
                _context.Categories.Update(category);
                _context.SaveChanges();
            }
        }
        public Category validateName(string name,int id)
        {
            using(var _context = new BookStoreContext())
            {
                return _context.Categories.Where(x=>x.Name == name && x.Id != id).FirstOrDefault();
            }
        }
    }
}
