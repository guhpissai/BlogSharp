using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.TagScreens
{
  public static class ListTagScreen
  {
    public static void Load()
    {
      List();
    }

    private static void List()
    {
      var repository = new Repository<Tag>(Database.Connection);

      var tags = repository.Get();

      foreach (var tag in tags)
      {
        Console.WriteLine($"{tag.Id} - {tag.Name} ({tag.Slug})");
      }

      Console.WriteLine("Pressione ENTER para voltar...");
      Console.ReadKey();
      Program.Menu();
    }
  }
}