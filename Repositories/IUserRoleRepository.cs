namespace Blog.Repositories
{
  public interface IRoleToUserRepository
  {
    void RoleToUser(long userId, int roleId);
  }
}