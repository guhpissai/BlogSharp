using Blog.Services;
using Blog.Utils;

namespace Blog.Screens.CategoryScreens
{
  public static class UpdateCategoryScreen
  {
    public static void Load(CategoryService _service)
    {

      Console.Clear();
      Console.WriteLine("══════════════════════════════════════════════");
      Console.WriteLine("                ATUALIZAR TAG                 ");
      Console.WriteLine("══════════════════════════════════════════════");

      Console.Write("Id: ");

      try
      {
        if (!int.TryParse(Console.ReadLine(), out var categoryId))
          throw new Exception("Id inválido!");

        var category = _service.GetById(categoryId);

        Console.WriteLine("");
        Console.Write($"Nome [{category.Name}]: ");
        var categoryName = Console.ReadLine();

        _service.Update(categoryId, categoryName!);

        Console.WriteLine("");
        Console.WriteLine($"Categoria atualizada com sucesso!");
        Console.WriteLine("\nPressione ENTER para voltar...");
        Console.ReadKey();
        MenuCategoryScreen.Load();
      }
      catch (Exception ex)
      {
        ConsoleHelper.ShowException(ex.Message);
        Load(_service);
      }
    }
  }
}