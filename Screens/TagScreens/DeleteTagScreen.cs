using Blog.Services;

namespace Blog.Screens.TagScreens
{
  public static class DeleteTagScreen
  {
    private static readonly TagService _service = new();
    public static void Load()
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
        Console.WriteLine(ex.Message);
        Console.WriteLine("Pressione ENTER para tentar novamente");
        Console.ReadKey();
        Load();
      }
    }
  }
}