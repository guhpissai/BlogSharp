using Blog.Repositories;

namespace Blog.Services
{
  public class UserRoleService : IUserRoleService
  {
    private readonly IUserRoleRepository _userRoleRepository;

    public UserRoleService(IUserRoleRepository userRepository)
      => _userRoleRepository = userRepository;

    public void UserToRole(int userId, int roleId)
      => _userRoleRepository.Create(userId, roleId);
  }
}