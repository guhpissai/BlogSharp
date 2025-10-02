using Blog.Screens.RoleScreens;
using Blog.Services;
using Blog.Utils;

namespace Blog.Screens.PostScreens
{
  public static class DeletePostScreen
  {
    public static void Load(PostService service)
    {
      Console.Clear();
      Console.WriteLine("============ DELETAR POST ==============");
      Console.WriteLine();

      try
      {
        Console.Write("Id do Post: ");
        var id = int.Parse(Console.ReadLine()!);

        service.Delete(id);

        Console.WriteLine("");
        Console.WriteLine($"Post {id} deletado com sucesso!");
        Console.WriteLine("Pressione ENTER para voltar...");
        Console.ReadKey();
        MenuPostScreen.Load();
      }
      catch (Exception ex)
      {
        ConsoleHelper.ShowException(ex.Message);
        MenuPostScreen.Load();
      }
    }
  }
}