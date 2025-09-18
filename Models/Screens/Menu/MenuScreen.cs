namespace Blog.Screens
{
  public static class Menu
  {
    public static void MenuLoad(string name)
    {
      Console.Clear();
      Console.WriteLine("══════════════════════════════════════════════");
      Console.WriteLine("          🏷️  GESTÃO DE TAGS - MENU           ");
      Console.WriteLine("══════════════════════════════════════════════");
      Console.WriteLine($" [1] 📋 Listar {name}");
      Console.WriteLine($" [2] ✍️  Criar {name}");
      Console.WriteLine($" [3] ✏️  Atualizar {name}");
      Console.WriteLine($" [4] ❌ Deletar {name}");
      Console.WriteLine($" [0] ↩️  Voltar ao Menu Principal");
      Console.WriteLine("══════════════════════════════════════════════");
      Console.Write(" 👉 Escolha uma opção: ");
    }
  }
}