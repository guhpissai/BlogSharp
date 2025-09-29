namespace Blog.Services
{
  public interface IUserRoleService
  {
    void UserToRole(int userId, int roleId);
  }
}