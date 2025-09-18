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

      Console.Clear();
      Console.WriteLine("============ LISTA DE TAGS ==============");
      Console.WriteLine();

      try
      {
        var tags = repository.Get();

        if (tags.Count() == 0 || tags == null)
        {
          Console.WriteLine("Nenhuma tag encontrada");
          Console.WriteLine("Precione ENTER para voltar...");
          Console.ReadKey();
          MenuTagScreen.Load();
          return;
        }

        foreach (var tag in tags)
        {
          Console.WriteLine($"{tag.Name.ToString().PadRight(15)} | {tag.Slug}");
        }

        Console.WriteLine("");
        Console.WriteLine("Pressione ENTER para voltar...");
        Console.ReadKey();
        Program.Menu();
      }
      catch (Exception ex)
      {
        Console.WriteLine("");
        Console.WriteLine("Erro ao listar Tags");
        Console.WriteLine(ex.Message);
        Console.WriteLine("Pressione ENTER para voltar...");
        Console.ReadKey();
        Program.Menu();
      }
    }
  }
}