using Microsoft.Data.SqlClient;
using Blog.Repositories;

internal class Program
{
  private const string STRINGCONNECTION_STRING =
    "Data Source=localhost,1433;Initial Catalog=Blog;User ID=sa;Password=A@123456;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
  private static void Main(string[] args)
  {
    var connection = new SqlConnection(STRINGCONNECTION_STRING);
    connection.Open();
    ReadUsers(connection);
    ReadRoles(connection);
    connection.Close();
  }

  static void ReadUsers(SqlConnection connection)
  {
    var repository = new UserRepository(connection);

    var users = repository.Get();

    foreach (var user in users)
      Console.WriteLine($"{user.Name}");
  }

  static void ReadRoles(SqlConnection connection)
  {
    var repository = new RoleRepository(connection);

    var roles = repository.Get();

    foreach (var role in roles)
      Console.WriteLine($"{role.Name}");
  }
}