using Blog.Services;
using Blog.Utils;

namespace Blog.Screens.TagScreens
{
  public static class DeleteTagScreen
  {
    public static void Load(TagService _service)
    {

      Console.Clear();
      Console.WriteLine("══════════════════════════════════════════════");
      Console.WriteLine("                 DELETAR TAG                  ");
      Console.WriteLine("══════════════════════════════════════════════");

      try
      {
        Console.Write("Digite o Id da Tag que deseja deletar: ");
        if (!int.TryParse(Console.ReadLine(), out var tagId))
          throw new Exception("Id inválido");

        var tag = _service.GetById(tagId);

        _service.Delete(tagId);

        Console.WriteLine($"Tag {tag.Name} deletada com sucesso!");
        Console.WriteLine("Pressione ENTER para tentar novamente");
        Console.ReadKey();
        MenuTagScreen.Load();
      }
      catch (Exception ex)
      {
        ConsoleHelper.ShowException(ex.Message);
        MenuTagScreen.Load();
      }
    }
  }
}