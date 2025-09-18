using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.TagScreens
{
  public static class UpdateTagScreen
  {
    public static void Load()
    {
      var repository = new Repository<Tag>(Database.Connection);

      Console.Clear();
      Console.WriteLine("══════════════════════════════════════════════");
      Console.WriteLine("                ATUALIZAR TAG                 ");
      Console.WriteLine("══════════════════════════════════════════════");

      try
      {
        Console.Write("Id: ");

        if (!int.TryParse(Console.ReadLine(), out var tagId))
        {
          Console.WriteLine("");
          Console.WriteLine("Id inválido! Use apenas números");
          Console.WriteLine("Pressione ENTER para tentar novamente");
          Console.ReadKey();
          Load();
          return;
        }

        var tag = repository.Get(tagId);
        if (tag == null)
        {
          Console.WriteLine("");
          Console.WriteLine("Tag não encontrada!");
          Console.WriteLine("Pressione ENTER para tentar novamente");
          Console.ReadKey();
          Load();
          return;
        }

        Console.WriteLine("");
        Console.WriteLine($"Tag {tag.Name} encontrada");
        Console.Write("Digite o novo nome: ");
        var tagName = Console.ReadLine();

        tag.Name = tagName;
        tag.Slug = tagName?.ToLower();

        repository.Update(tag);

        Console.WriteLine("");
        Console.WriteLine($"Tag atualizada com sucesso!");
      }
      catch (Exception ex)
      {
        Console.WriteLine("\n❌ Ocorreu um erro ao atualizar a Tag.");
        System.Diagnostics.Debug.WriteLine(ex); // log interno
      }

      Console.WriteLine("\nPressione ENTER para voltar...");
      Console.ReadKey();
      MenuTagScreen.Load();
    }
  }
}