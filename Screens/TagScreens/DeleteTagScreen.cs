using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.TagScreens
{
  public static class DeleteTagScreen
  {
    public static void Load()
    {
      var repository = new Repository<Tag>(Database.Connection);

      Console.Clear();
      Console.WriteLine("══════════════════════════════════════════════");
      Console.WriteLine("                 DELETAR TAG                  ");
      Console.WriteLine("══════════════════════════════════════════════");

      try
      {
        Console.Write("Digite o Id da Tag que deseja deletar: ");
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

        repository.Delete(tagId);

        Console.WriteLine($"Tag {tag.Name} deletada com sucesso!");
      }
      catch (Exception ex)
      {
        Console.WriteLine("Erro ao deletar a Tag");
        Console.WriteLine(ex.Message);
        Console.WriteLine("Pressione ENTER para tentar novamente");
        Console.ReadKey();
        Load();
        return;
      }

      Console.WriteLine("\nPressione ENTER para voltar...");
      Console.ReadKey();
      MenuTagScreen.Load();
    }
  }
}