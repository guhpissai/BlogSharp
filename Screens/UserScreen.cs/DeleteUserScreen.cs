using Blog.Models;
using Blog.Repositories;
using Blog.Screens.MenuPostScreen;

namespace Blog.Screens.UserScreen
{
  public static class DeleteUserScreen
  {
    public static void Load()
    {
      var repository = new Repository<User>(Database.Connection);

      Console.Clear();
      Console.WriteLine("══════════════════════════════════════════════");
      Console.WriteLine("                 DELETAR USUÁRIO                  ");
      Console.WriteLine("══════════════════════════════════════════════");

      try
      {
        Console.Write("Digite o Id da Usuário que deseja deletar: ");
        if (!int.TryParse(Console.ReadLine(), out var userId))
        {
          Console.WriteLine("");
          Console.WriteLine("Id inválido! Use apenas números");
          Console.WriteLine("Pressione ENTER para tentar novamente");
          Console.ReadKey();
          Load();
          return;
        }

        var user = repository.Get(userId);
        if (user == null)
        {
          Console.WriteLine("");
          Console.WriteLine("Usuário não encontrado!");
          Console.WriteLine("Pressione ENTER para tentar novamente");
          Console.ReadKey();
          Load();
          return;
        }

        repository.Delete(userId);

        Console.WriteLine($"Usuário {user.Name} deletado com sucesso!");
      }
      catch (Exception ex)
      {
        Console.WriteLine("Erro ao deletar a Usuário");
        Console.WriteLine(ex.Message);
        Console.WriteLine("Pressione ENTER para tentar novamente");
        Console.ReadKey();
        Load();
        return;
      }

      Console.WriteLine("\nPressione ENTER para voltar...");
      Console.ReadKey();
      MenuUserScreen.Load();
    }
  }
}