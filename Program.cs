using Blog;
using Blog.Screens;
using Microsoft.Data.SqlClient;
internal class Program
{
  private const string CONNECTION_STRING =
    "Data Source=localhost,1433;Initial Catalog=Blog;User ID=sa;Password=A@123456;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
  private static void Main(string[] args)
  {
    Database.Connection = new SqlConnection(CONNECTION_STRING);
    Database.Connection.Open();
    MenuScreen.Load();
    Database.Connection.Close();
  }
}