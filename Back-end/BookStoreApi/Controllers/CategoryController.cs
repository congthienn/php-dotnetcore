using BookStoreApi.Services;
using BookStoreApi.Models;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using BookStoreApi.Interfaces;
namespace BookStoreApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly IBookService _booksService;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        public CategoryController(ICategoryService categoryService,IBookService booksService,IMapper mapper,ILogger<CategoryController> logger)
        {
            _categoryService = categoryService;
            _booksService = booksService;
            _mapper = mapper;
            _logger = logger;
        }
        [HttpGet]
        public async Task<IEnumerable<Category>> GetCategory() {
            this._logger.LogInformation(MyLogEvents.ListItems,"{e} - Run api: https://localhost:44313/api/category",MyLogEventTitle.ListItems);
            IEnumerable<Category> listCategory = await this._categoryService.GetCategory();
            
            return listCategory;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetCategoryById(string id)
        {
            this._logger.LogInformation(MyLogEvents.GetItem,"{e} - Run api: https://localhost:44313/api/category/{id}",MyLogEventTitle.GetItem, id);
            Category findCategory = await this._categoryService.GetCategoryById(id);
            if(findCategory is null)
            {
                ModelState.AddModelError("Error", "Category not found");
                this._logger.LogWarning(MyLogEvents.Error,"{e} - Category not found",MyLogEventTitle.Error);
                return BadRequest(ModelState);
            }
            this._logger.LogInformation(MyLogEvents.GetItem,"{e} - Output: {output}", MyLogEventTitle.GetItem, MyLogEvents.ShowObject(findCategory));
            return Ok(findCategory);
        }
        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromBody] CategoryDTO createCategory)
        {
            this._logger.LogInformation(MyLogEvents.InsertItem, "{e} - Run api: https://localhost:44313/api/category", MyLogEventTitle.InsertItem);
            this._logger.LogInformation(MyLogEvents.InsertItem, "{e} - Input: {input}", MyLogEventTitle.InsertItem, MyLogEvents.ShowObject(createCategory));
            Category newCategory = new Category();
            this._mapper.Map(createCategory,newCategory);
            IEnumerable<Category> validateCategory = await this._categoryService.ValidateCategory(newCategory.Id,newCategory.Name);
            if(validateCategory.Count() > 0)
            {
                ModelState.AddModelError("Error", "Category is exist");
                this._logger.LogWarning(MyLogEvents.Error, "{e} - Category is exist", MyLogEventTitle.Error);
                return BadRequest(ModelState);
            }
            await this._categoryService.CreateCategory(newCategory);
            this._logger.LogInformation(MyLogEvents.InsertItem, "{e} - Output: {output}", MyLogEventTitle.InsertItem, MyLogEvents.ShowObject(newCategory));
            return CreatedAtAction(nameof(GetCategoryById), new { id = newCategory.Id }, newCategory);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(string id)
        {
            this._logger.LogInformation(MyLogEvents.DeleteItem, "{e} - Run api: https://localhost:44313/api/category/{id}", MyLogEventTitle.DeleteItem, id);
            Category findCategory = await this._categoryService.GetCategoryById(id);
            if(findCategory is null)
            {
                ModelState.AddModelError("Error", "Category not found");
                this._logger.LogWarning(MyLogEvents.Error, "{e} - Category not found", MyLogEventTitle.Error);
               
                return BadRequest(ModelState);
            }
            var listCategory = await this._booksService.ListBookByCategoryId(findCategory.Id);
            if(listCategory.Count() > 0)
            {
                foreach (Book book in listCategory)
                {
                    book.CategoryId = null;
                    //book.Category = null;
                    await this._booksService.UpdateAsync(book.Id, book);
                }
            }
           
            await this._categoryService.DeleteCategory(findCategory.Id);
            return NoContent();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory(string id,[FromBody] CategoryDTO updateCategory)
        {
            this._logger.LogInformation(MyLogEvents.UpdateItem, "{e} - Run api: https://localhost:44313/api/category/{id}", MyLogEventTitle.UpdateItem, id);
            this._logger.LogInformation(MyLogEvents.UpdateItem, "{e} - Input:{input}", MyLogEventTitle.UpdateItem, MyLogEvents.ShowObject(updateCategory));
            Category findCategory = await this._categoryService.GetCategoryById(id);
            if(findCategory is null)
            {
                ModelState.AddModelError("Error", "Category not found");
                this._logger.LogWarning(MyLogEvents.Error, "{e} - Category not found", MyLogEventTitle.Error);
               
                return BadRequest(ModelState);
            }
            IEnumerable<Category> validateCategory = await this._categoryService.ValidateCategory(findCategory.Id,updateCategory.Name);
            if(validateCategory.Count() > 0)
            {
                ModelState.AddModelError("Error", "Category is exist");
                this._logger.LogWarning(MyLogEvents.Error, "{e} - Category is exist", MyLogEventTitle.Error);

                return BadRequest(ModelState);
            }
            this._mapper.Map(updateCategory,findCategory);
            CategoryShow category = this._mapper.Map<CategoryShow>(findCategory);
            var listBook = await this._booksService.ListBookByCategoryId(findCategory.Id);
            if(listBook.Count() > 0)
            {
                foreach (Book book in listBook)
                {
                    //book.Category = category;
                    await this._booksService.UpdateAsync(book.Id, book);
                }
            }
            await this._categoryService.UpdateCategory(findCategory.Id, findCategory);
            this._logger.LogInformation(MyLogEvents.UpdateItem, "{e} - Output: {output}", MyLogEventTitle.UpdateItem, MyLogEvents.ShowObject(findCategory));
            return CreatedAtAction(nameof(GetCategoryById), new { id = findCategory.Id }, findCategory);
        }
    }
}