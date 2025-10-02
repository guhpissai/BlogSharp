using Blog.Models;

namespace Blog.Services
{
  public interface IUserService
  {
    IEnumerable<User> GetAll();
    User GetById(int id);
    int Create(User tag);
    void Delete(int id);
    void Update(User tag);
  }
}