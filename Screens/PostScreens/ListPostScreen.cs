using Blog.Screens.RoleScreens;
using Blog.Services;
using Blog.Utils;

namespace Blog.Screens.PostScreens
{
  public static class ListPostScreen
  {
    public static void Load(PostService service)
    {
      Console.Clear();
      Console.WriteLine("══════════════════════════════════════════════");
      Console.WriteLine("                📌 LISTA DE POSTS             ");
      Console.WriteLine("══════════════════════════════════════════════");

      try
      {
        var posts = service.GetAll();
        if (!posts.Any())
        {
          Console.WriteLine("Nenhum post cadastrado!");
          Console.ReadKey();
          MenuPostScreen.Load();
          return;
        }

        foreach (var post in posts)
        {
          Console.WriteLine($" 📌 Id: {post.Id}");
          Console.WriteLine($" 📝 Título: {post.Title}");
          Console.WriteLine($" 🖊️  Resumo: {post.Summary}");
          Console.WriteLine($" 📰 Texto: {post.Body}");
          Console.WriteLine("──────────────────────────────────────────────");
        }

        Console.WriteLine("");
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