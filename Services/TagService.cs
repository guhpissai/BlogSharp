using Blog.Models;
using Blog.Repositories;

namespace Blog.Services
{
  public class TagService
  {
    private readonly IRepository<Tag> _repository;
    public TagService(IRepository<Tag> repository)
    {
      _repository = repository;
    }

    public IEnumerable<Tag> GetAll()
      => _repository.Get();


    public Tag GetById(int id)
      => _repository.Get(id) ?? throw new Exception("Tag não encontrada");

    public void Create(Tag tag)
    {
      var existingTag = _repository.Get().Any(t => t.Name == tag.Name);

      if (existingTag)
        throw new Exception("Nome da tag já existe");

      _repository.Create(tag);
    }

    public void Delete(int id)
    {
      var existingTag = _repository.Get(id);

      if (existingTag == null)
        throw new Exception("Tag não encontrada");

      _repository.Delete(existingTag);
    }

    public void Update(int id, string name)
    {
      var tag = _repository.Get(id);

      if (tag == null)
        throw new Exception("Tag não encontrada");

      var existingTag = _repository.Get().Any(t => t.Name == tag.Name && tag.Id != t.Id);

      if (existingTag)
        throw new Exception("Nome da tag já existe");

      tag.Name = name;
      tag.Slug = name.ToLower();

      _repository.Update(tag);
    }
  }
}