using Blog.Models;
using Dapper;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace Blog.Repositories
{
  public class UserRepository : Repository<User>
  {
    private readonly SqlConnection _connection;
    public UserRepository(SqlConnection connection) : base(connection)
      => _connection = connection;

    public List<User> GetUsersWithRoles()
    {

      var query = @"
        SELECT [User].*, [Role].* FROM [User]
        LEFT JOIN [UserRole] ON [User].Id = [UserRole].UserId
        LEFT JOIN [Role] ON	[Role].Id = [UserRole].RoleId
      ";

      var users = new List<User>();
      var items = _connection.Query<User, Role, User>(
        query,
        (user, role) =>
          {
            var usr = users.FirstOrDefault(x => x.Id == user.Id);
            if (usr == null)
            {
              usr = user;
              usr.Roles.Add(role);
              users.Add(user);
            }
            else
              if (role != null)
              user.Roles.Add(role);

            return user;
          }, splitOn: "Id"
      );
      return users;
    }
  }
}