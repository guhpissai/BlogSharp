using Blog.Models;
using Blog.Services;
using Blog.Utils;

namespace Blog.Screens.UserScreens
{
  public static class CreateUserScreen
  {
    public static void Load(UserService _service, RoleService _roleService, UserRoleService _userRoleService)
    {
      Console.Clear();
      Console.WriteLine("══════════════════════════════════════════════");
      Console.WriteLine("                CRIAR USUÁRIO                 ");
      Console.WriteLine("══════════════════════════════════════════════");

      Console.Write("Nome: ");
      var name = Console.ReadLine();
      var slug = name?.ToLower();

      Console.Write("E-mail: ");
      var email = Console.ReadLine();

      Console.Write("Senha: ");
      var password = Console.ReadLine();

      Console.Write("Bio: ");
      var bio = Console.ReadLine();

      Console.Write("Imagem (URL): ");
      var image = Console.ReadLine();

      var availableRoles = _roleService.GetAll();

      int option;
      while (true)
      {
        Console.Clear();
        Console.WriteLine("\nEscolha o perfil:");
        for (int i = 0; i < availableRoles.Count(); i++)
          Console.WriteLine($"[{i + 1}] - {availableRoles.ElementAt(i).Name}");

        if (int.TryParse(Console.ReadLine(), out option) &&
            option >= 1 && option <= availableRoles.Count())
        {
          break;
        }

        Console.WriteLine("\nOpção inválida! Pressione ENTER para tentar novamente...");
        Console.ReadKey();
      }

      var role = availableRoles.ElementAt(option - 1);
      role.Slug = role.Name!.ToLower();


      var user = new User
      {
        Name = name,
        Email = email,
        PasswordHash = password,
        Bio = bio,
        Image = image,
        Slug = slug,
      };

      try
      {
        var userId = _service.Create(user);
        _userRoleService.UserToRole(userId, role.Id);

        Console.WriteLine($"\n✅ Usuário {name} criado com sucesso!");
        Console.WriteLine("Pressione ENTER para voltar...");
        Console.ReadKey();
        MenuUserScreen.Load();
      }
      catch (Exception ex)
      {
        ConsoleHelper.ShowException(ex.Message);
        MenuUserScreen.Load();
      }
    }
  }
}
