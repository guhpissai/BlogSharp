using Blog.Services;
using Blog.Utils;

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
          ConsoleHelper.ShowException("Usuário não encontrado!");
          Load(_service);
          return;
        }

        _service.Delete(userId);

        Console.WriteLine("");
        Console.WriteLine($"Usuário {user.Name} deletado com sucesso!");
        Console.WriteLine("Pressione ENTER para voltar ao menu...");
        Console.ReadKey();
        MenuUserScreen.Load();
      }
      catch (Exception ex)
      {
        ConsoleHelper.ShowException(ex.Message);
        MenuUserScreen.Load();
        return;
      }
    }
  }
}