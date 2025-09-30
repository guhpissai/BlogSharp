using Blog.Models;
using Blog.Services;
using Blog.Utils;

namespace Blog.Screens.RoleScreens
{
  public static class ListRoleScreen
  {
    public static void Load(RoleService _service)
    {

      Console.Clear();
      Console.WriteLine("============ LISTA DE PERFIL ==============");
      Console.WriteLine();

      try
      {
        var roles = _service.GetAll();

        foreach (var role in roles)
        {
          Console.WriteLine($"{role.Name,-15} | {role.Slug}");
        }

        Console.WriteLine("");
        Console.WriteLine("Pressione ENTER para voltar...");
        Console.ReadKey();
        MenuRoleScreen.Load();
      }
      catch (Exception ex)
      {
        ConsoleHelper.ShowException(ex.Message);
        MenuRoleScreen.Load();
      }
    }
  }
}