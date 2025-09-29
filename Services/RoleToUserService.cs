using Blog.Models;
using Blog.Repositories;

namespace Blog.Services
{
  public class RoleToUserService : IUserRoleService
  {
    private readonly IRoleToUserRepository _repository;

    public RoleToUserService(IRoleToUserRepository repository)
    {
      _repository = repository;
    }
    public void UserToRole(int userId, int roleId)
    {
      _repository.RoleToUser(userId, roleId);
    }
  }
}