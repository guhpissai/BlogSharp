using Blog.Models;
using Blog.Repositories;
using Blog.Screens;
using Blog.Services;

namespace Blog.Screens.UserScreens
{
  public static class DeleteUserScreen
  {
    public static void Load(UserService _service)
    {

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
          Load(_service);
          return;
        }

        var user = _service.GetById(userId);
        if (user == null)
        {
          Console.WriteLine("");
          Console.WriteLine("Usuário não encontrado!");
          Console.WriteLine("Pressione ENTER para tentar novamente");
          Console.ReadKey();
          Load(_service);
          return;
        }

        _service.Delete(userId);

        Console.WriteLine($"Usuário {user.Name} deletado com sucesso!");
      }
      catch (Exception ex)
      {
        Console.WriteLine("Erro ao deletar a Usuário");
        Console.WriteLine(ex.Message);
        Console.WriteLine("Pressione ENTER para tentar novamente");
        Console.ReadKey();
        Load(_service);
        return;
      }

      Console.WriteLine("\nPressione ENTER para voltar...");
      Console.ReadKey();
      MenuUserScreen.Load();
    }
  }
}