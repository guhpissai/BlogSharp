using Blog.Models;
using Blog.Services;
using Blog.Utils;

namespace Blog.Screens.CategoryScreens
{
  public static class CreateCategoryScreen
  {
    public static void Load(CategoryService _service)
    {
      Console.Clear();
      Console.WriteLine("══════════════════════════════════════════════");
      Console.WriteLine("               CRIAR CATEGORIA                ");
      Console.WriteLine("══════════════════════════════════════════════");

      try
      {
        Console.Write("Qual vai ser o nome da categoria? ");
        var name = Console.ReadLine();
        var slug = name?.ToLower();

        var categoria = new Category();

        categoria.Name = name;
        categoria.Slug = slug;

        _service.Create(categoria);

        Console.WriteLine($"Categoria {name} criada com sucesso!");

        Console.WriteLine();
        Console.WriteLine("Pressione ENTER para voltar...");
        Console.ReadKey();
        MenuCategoryScreen.Load();
      }
      catch (Exception ex)
      {
        ConsoleHelper.ShowException(ex.Message);
        MenuCategoryScreen.Load();
      }
    }
  }
}