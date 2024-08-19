
using WebAPIMVC8CRUD.Model;

namespace WebAPIMVC8CRUD.Services
{
    public interface ICategoryService
    {
        List<Category> GetAll();
        Category GetByCategoryId(int CategoryId);
        Category Add(Category category);
        bool Delete(int CategoryId);
    }
}