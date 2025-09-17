using Blog.Models;
using Blog.Repositories;
using Dapper.Contrib.Extensions;

namespace Blog.Screens.TagScreens
{
  public static class CreateTagScreen
  {
    public static void Load()
    {
      Console.Clear();
      Console.WriteLine("========= Criar Tag =========");

      Console.Write("Qual vai ser o nome da tag? ");
      var name = Console.ReadLine();
      var slug = name.ToLower();

      var tag = new Tag();
      tag.Name = name;
      tag.Slug = slug;

      try
      {
        var repository = new Repository<Tag>(Database.Connection);
        repository.Create(tag);

        Console.WriteLine($"Tag {name} criada com sucesso!");

        Console.WriteLine();
        Console.WriteLine("Pressione ENTER para voltar...");
        Console.ReadKey();
        MenuTagScreen.Load();
      }
      catch (Exception ex)
      {
        Console.WriteLine("\n❌ Não foi possível criar a Tag, pressione ENTER para tentar novamente...");
        Console.WriteLine("");
        Console.WriteLine(ex.Message);
        Console.ReadKey();
        Console.Clear();
        Load();
      }
    }
  }
}