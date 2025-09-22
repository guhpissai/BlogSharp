using Blog.Models;

namespace Blog.Services
{
  public interface ICategoryService
  {
    IEnumerable<Category> GetAll();
    Category GetById(int id);
    void Create(Category tag);
    void Delete(int id);
    void Update(Category tag);
  }
}