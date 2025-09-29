using Dapper;
using Microsoft.Data.SqlClient;

namespace Blog.Repositories
{
  public class UserRoleRepository : IUserRoleRepository
  {
    private readonly SqlConnection _connection;
    public UserRoleRepository(SqlConnection connection)
    {
      _connection = connection;
    }

    public void Create(long userId, int roleId)
    {
      const string sql = @"
            INSERT INTO [UserRole] (UserId, RoleId)
            VALUES (@UserId, @RoleId);";

      _connection.Execute(sql, new { UserId = userId, RoleId = roleId });
    }
  }
}