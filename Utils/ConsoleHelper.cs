namespace Blog.Utils
{
  public static class ConsoleHelper
  {
    public static void ShowInvalidOption()
    {
      Console.ForegroundColor = ConsoleColor.Red;
      Console.WriteLine("\n❌ Opção inválida! Pressione ENTER para voltar");
      Console.ReadKey();
    }

    public static void ShowException(string message)
    {
      Console.WriteLine("");
      Console.WriteLine($"Erro: {message}");
      Console.WriteLine("Pressione ENTER para tentar novamente...");
      Console.ReadKey();
      Console.Clear();
    }
  }
}