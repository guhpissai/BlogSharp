using Blog.Models;
using Blog.Services;

namespace Blog.Screens.UserScreens
{
  public static class CreateUserScreen
  {
    public static void Load(UserService _service)
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

      var availableRoles = new List<Role>
            {
                new Role { Name = "Autor" },
                new Role { Name = "Editor" },
                new Role { Name = "Leitor" },
                new Role { Name = "Administrador" },
            };

      int option;
      while (true)
      {
        Console.Clear();
        Console.WriteLine("\nEscolha o perfil:");
        for (int i = 0; i < availableRoles.Count; i++)
          Console.WriteLine($"[{i + 1}] - {availableRoles[i].Name}");

        if (int.TryParse(Console.ReadLine(), out option) &&
            option >= 1 && option <= availableRoles.Count)
        {
          break;
        }

        Console.WriteLine("\nOpção inválida! Pressione ENTER para tentar novamente...");
        Console.ReadKey();
      }

      var role = availableRoles[option - 1];
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
        _service.Create(user);

        Console.WriteLine($"\n✅ Usuário {name} criado com sucesso!");
        Console.WriteLine("Pressione ENTER para voltar...");
        Console.ReadKey();
        MenuUserScreen.Load();
      }
      catch (Exception ex)
      {
        Console.WriteLine($"\n❌ Não foi possível criar o usuário: {ex.Message}");
        Console.WriteLine("Pressione ENTER para tentar novamente...");
        Console.ReadKey();
        Load(_service);
      }
    }
  }
}
