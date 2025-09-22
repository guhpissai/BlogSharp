using Blog.Services;

namespace Blog.Screens.CategoryScreens
{
  public static class DeleteCategoryScreen
  {
    public static void Load(CategoryService _service)
    {
      try
      {
        Console.Clear();
        Console.WriteLine("══════════════════════════════════════════════");
        Console.WriteLine("                 DELETAR TAG                  ");
        Console.WriteLine("══════════════════════════════════════════════");

        Console.Write("Digite o Id da Categoria que deseja deletar: ");

        if (!short.TryParse(Console.ReadLine(), out var catId))
          Console.WriteLine("Id inválido!");

        _service.Delete(catId);

        Console.WriteLine("Categoria deletada com sucesso!");
        Console.WriteLine("Pressione ENTER para voltar...");
        Console.ReadKey();
        MenuCategoryScreen.Load();
      }
      catch (Exception ex)
      {
        Console.WriteLine("");
        Console.WriteLine(ex.Message);
        Console.WriteLine("Pressione ENTER para voltar...");
        Console.ReadKey();
        MenuCategoryScreen.Load();
      }
    }
  }
}