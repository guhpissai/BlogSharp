using Blog.Screens.TagScreens;
using Microsoft.Data.SqlClient;
internal class Program
{
  private const string STRINGCONNECTION_STRING =
    "Data Source=localhost,1433;Initial Catalog=Blog;User ID=sa;Password=A@123456;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
  private static void Main(string[] args)
  {
    var connection = new SqlConnection(STRINGCONNECTION_STRING);
    connection.Open();
    Menu();
    connection.Close();
  }

  public static void Menu()
  {
    Console.OutputEncoding = System.Text.Encoding.UTF8;
    Console.Title = "📌 Blog Manager";

    Console.Clear();
    Console.WriteLine("══════════════════════════════════════════════");
    Console.WriteLine("              📌 MENU PRINCIPAL               ");
    Console.WriteLine("══════════════════════════════════════════════");
    Console.WriteLine(" [1] 👤 Gestão de Usuário");
    Console.WriteLine(" [2] 🛡️  Gestão de Perfil");
    Console.WriteLine(" [3] 📂 Gestão de Categoria");
    Console.WriteLine(" [4] 🏷️  Gestão de Tag");
    Console.WriteLine(" [5] 🔗 Vincular Perfil ⇆ Usuário");
    Console.WriteLine(" [6] 🔗 Vincular Post ⇆ Tag");
    Console.WriteLine(" [7] 📊 Relatórios");
    Console.WriteLine("══════════════════════════════════════════════");
    Console.Write(" 👉 Escolha uma opção: ");

    var option = short.Parse(Console.ReadLine()!);

    switch (option)
    {
      case 4:
        MenuTagScreen.Load();
        break;
    }
  }
}