using Blog.Models;
using Blog.Repositories;

namespace Blog.Services
{
  public class CategoryService(IRepository<Category> _repository)
  {
    public IEnumerable<Category> GetAll()
     => _repository.Get();

    public Category GetById(int id)
     => _repository.Get(id) ?? throw new InvalidOperationException("Categoria não encontrada");

    public void Create(Category category)
    {
      var existingCategory = _repository.Get().Any(c => c.Name == category.Name);

      if (existingCategory)
        throw new InvalidOperationException("Nome da categoria ja cadastrada");

      _repository.Create(category);
    }

    public void Delete(int id)
    {
      var category = _repository.Get(id);

      if (category == null)
      {
        throw new InvalidOperationException("Categoria não encontrada.");
      }

      _repository.Delete(category);
    }

    public void Update(Category category)
    {
      var categories = _repository.Get();

      if (categories.Any(c => c.Name == category.Name && category.Id != c.Id))
        throw new InvalidOperationException("Nome da categoria já cadastrada");

      var updated = _repository.Update(category);

      if (!updated)
        throw new InvalidOperationException("Categoria não encontrada.");
    }
  }
}