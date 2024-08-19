using static WebAPIMVC8CRUD.Services.CategoryService;
using WebAPIMVC8CRUD.Model;
using WebAPIMVC8CRUD.Services;

namespace WebAPIMVC8CRUD.Services
{


    public class CategoryService : ICategoryService
    {
        private readonly List<Category> _Categorys;

        public CategoryService()
        {
            _Categorys = new List<Category>() {
                new Category() {
                    CategoryId = 101,
                    CategoryName = "hello",

                },
                new Category() {
                    CategoryId = 102,
                    CategoryName = "test",

                },
                new Category() {
                    CategoryId = 103,
                    CategoryName = "rk",

                }
            };
        }

        public Category Add(Category Category)
        {
            int newCategoryId = _Categorys.Max(x => x.CategoryId) + 1;
            Category.CategoryId = newCategoryId;
            _Categorys.Add(Category);
            return Category;
        }

        public bool Delete(int CategoryId)
        {
            var existing = _Categorys.Find(x => x.CategoryId == CategoryId);
            if (existing != null)
            {
                _Categorys.Remove(existing);
                return true;
            }
            else
                return false;
        }

        public List<Category> GetAll()
        {
            return _Categorys;
        }

        public Category GetByCategoryId(int CategoryId)
        {
            return _Categorys.Where(x => x.CategoryId == CategoryId).FirstOrDefault();
        }
    }
}

