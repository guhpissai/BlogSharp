using Blog.Models;

namespace Blog.Services
{
  public interface ITagService
  {
    IEnumerable<Tag> GetAll();
    Tag GetById(int id);
    void Create(Tag tag);
    void Delete(int id);
    void Update(Tag tag);
  }
}