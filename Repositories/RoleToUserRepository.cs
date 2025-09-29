using Dapper;
using Microsoft.Data.SqlClient;

namespace Blog.Repositories
{
  public class RoleToUserRepository : IRoleToUserRepository
  {
    private readonly SqlConnection _connection;
    public RoleToUserRepository(SqlConnection connection)
    {
      _connection = connection;
    }

    public void RoleToUser(long userId, int roleId)
    {
      const string sql = @"
            INSERT INTO [UserRole] (UserId, RoleId)
            VALUES (@UserId, @RoleId);";

      _connection.Execute(sql, new { UserId = userId, RoleId = roleId });
    }
  }
}