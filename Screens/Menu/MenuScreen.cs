using Blog.Screens.CategoryScreens;
using Blog.Screens.RoleScreens;
using Blog.Screens.TagScreens;
using Blog.Screens.UserScreens;
using Microsoft.Data.SqlClient;

namespace Blog.Screens
{
  public static class MenuScreen
  {
    public static void Load()
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

      if (!short.TryParse(Console.ReadLine(), out short option))
      {
        Load();
        return;
      }

      switch (option)
      {
        case 1:
          MenuUserScreen.Load();
          break;
        case 2:
          MenuRoleScreen.Load();
          break;
        case 3:
          MenuCategoryScreen.Load();
          break;
        case 4:
          MenuTagScreen.Load();
          break;
        case 5:
          // RoleToUserScreen.Load(service, roleService, userService);
          break;
        default:
          Load();
          break;
      }
    }
  }
}