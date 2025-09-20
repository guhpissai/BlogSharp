using Blog.Models;
using Blog.Repositories;
using Blog.Screens.MenuPostScreen;
using Blog.Services;

namespace Blog.Screens.UserScreen
{
  public static class ListUserScreen
  {
    public static void Load(UserService _service)
    {
      Console.Clear();
      Console.WriteLine("============ LISTA DE USUÁRIOS ==============");
      Console.WriteLine();

      try
      {
        var users = _service.GetAll();

        if (users == null || users.Count() == 0)
        {
          Console.WriteLine("Nenhum usuário encontrado");
          Console.WriteLine("Precione ENTER para voltar...");
          Console.ReadKey();
          MenuUserScreen.Load();
          return;
        }

        foreach (var user in users)
        {
          Console.WriteLine($"{user.Name,-20} | {user.Email,+5}");
        }

        Console.WriteLine();
        Console.WriteLine("Precione ENTER para voltar...");
        Console.ReadKey();
        MenuUserScreen.Load();

      }
      catch (Exception ex)
      {
        Console.WriteLine("");
        Console.WriteLine("Erro ao listar usuários");
        Console.WriteLine(ex.Message);
        Console.WriteLine("Precione ENTER para tentar novamente...");
        Console.ReadKey();
        Load(_service);
        return;
      }
    }
  }
}