using Microsoft.Data.SqlClient;
internal class Program
{
  private const string STRINGCONNECTION_STRING =
    "Data Source=localhost,1433;Initial Catalog=Blog;User ID=sa;Password=A@123456;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
  private static void Main(string[] args)
  {
    var connection = new SqlConnection(STRINGCONNECTION_STRING);
    connection.Open();

    connection.Close();
  }

}