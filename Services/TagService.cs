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
    {
      var tags = _repository.Get();
      return tags ?? [];
    }

    public Tag GetById(int id)
    {
      var tag = _repository.Get(id) ?? throw new Exception("Tag não encontrada");
      return tag;
    }

    public void Create(Tag tag)
    {
      if (string.IsNullOrWhiteSpace(tag.Name))
        throw new Exception("Nome da tag não pode ser vazio");

      var exists = _repository.Get().Any(t => t.Name == tag.Name);

      if (exists)
        throw new Exception("Ja existe uma tag com esse nome");

      _repository.Create(tag);
    }

    public void Delete(int id)
    {
      var tag = _repository.Get(id);
      if (tag == null)
        throw new Exception("Tag não encontrada");
      _repository.Delete(tag);
    }

    public void Update(int id, string name)
    {
      var tag = _repository.Get(id);

      if (tag == null)
        throw new Exception("Tag não encontrada");

      tag.Name = name;
      tag.Slug = name.ToLower();

      _repository.Update(tag);
    }
  }
}