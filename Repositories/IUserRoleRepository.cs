namespace Blog.Repositories
{
  public interface IUserRoleRepository
  {
    void Create(long userId, int roleId);
  }
}