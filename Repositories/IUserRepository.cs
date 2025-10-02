using Blog.Models;

namespace Blog.Repositories
{
  public interface IUserRepository : IRepository<User>
  {
    List<User> GetUsersWithRoles();
  }
}