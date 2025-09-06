using Microsoft.Data.SqlClient;
using Blog.Repositories;
using Blog.Models;

internal class Program
{
  private const string STRINGCONNECTION_STRING =
    "Data Source=localhost,1433;Initial Catalog=Blog;User ID=sa;Password=A@123456;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
  private static void Main(string[] args)
  {
    var connection = new SqlConnection(STRINGCONNECTION_STRING);
    connection.Open();
    GetUsersWithRoles(connection);
    // ReadRoles(connection);
    connection.Close();
  }

  static void ReadUsers(SqlConnection connection)
  {
    var repository = new Repository<User>(connection);

    var items = repository.Get();

    foreach (var item in items)
      Console.WriteLine($"{item.Name}");
  }

  static void ReadRoles(SqlConnection connection)
  {
    var repository = new Repository<Role>(connection);

    var items = repository.Get();

    foreach (var item in items)
      Console.WriteLine($"{item.Name}");
  }

  static void GetUsersWithRoles(SqlConnection connection)
  {
    var userRepository = new UserRepository(connection);

    var users = userRepository.GetUsersWithRoles();

    foreach (var user in users)
    {
      var roles = new List<string>();
      foreach (var role in user.Roles)
      {
        if (role != null && role.Name != null)
          roles.Add(role.Name);
      }

      Console.WriteLine($"Nome: {user.Name} - Roles: {string.Join(", ", roles)}");
    }
  }
}