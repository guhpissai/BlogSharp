using Blog.Models;
using Blog.Screens.RoleScreens;
using Blog.Services;
using Blog.Utils;

namespace Blog.Screens.PostScreens
{
  public static class CreatePostScreen
  {
    public static void Load(PostService _service, CategoryService _categoryService, UserService _userService)
    {
      Console.Clear();
      Console.WriteLine("============ CRIAR POST ==============");
      Console.WriteLine();

      try
      {
        Console.Write("Digite seu nome: ");
        var name = Console.ReadLine();

        var user = _userService.GetAll();

        if (!user.Any(u => u.Name == name))
        {
          Console.WriteLine("Usuário não encontrado. Crie um usuário antes de criar um post.");
          MenuPostScreen.Load();
          return;
        }

        Console.Write("Título: ");
        var title = Console.ReadLine();

        Console.Write("Resumo: ");
        var summary = Console.ReadLine();

        Console.Write("Texto: ");
        var body = Console.ReadLine();

        Post post = new();
        post.Title = title!;
        post.Summary = summary!;
        post.Body = body!;
        post.Slug = title!.ToLower().Replace(" ", "-");
        post.AuthorId = user.First(u => u.Name == name).Id;

        var categories = _categoryService.GetAll();
        Console.WriteLine("Escolha uma categoria para o post:");

        for (int i = 0; i < categories.Count(); i++)
        {
          var category = categories.ElementAt(i);
          Console.WriteLine($"{i + 1} - {category.Name}");
        }

        if (!int.TryParse(Console.ReadLine(), out var categoryId) || categoryId < 1 || categoryId > categories.Count())
        {
          ConsoleHelper.ShowInvalidOption();
          MenuPostScreen.Load();
          return;
        }

        post.CategoryId = categories.ElementAt(categoryId - 1).Id;

        _service.Create(post);

        Console.WriteLine("");
        Console.WriteLine($"Post {title} criado com sucesso!");
        Console.WriteLine("Pressione ENTER para voltar...");
        Console.ReadKey();
        MenuPostScreen.Load();
      }
      catch (Exception ex)
      {
        ConsoleHelper.ShowException(ex.Message);
        MenuPostScreen.Load();
      }
    }
  }
}