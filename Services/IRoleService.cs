using Blog.Models;

namespace Blog.Services
{
  public interface IRoleService
  {
    IEnumerable<Role> GetAll();
    Role GetById(int id);
    void Create(Role tag);
    void Delete(int id);
    void Update(Role tag);
  }
}