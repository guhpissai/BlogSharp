namespace Blog.Screens.TagScreens
{
  public static class MenuTagScreen
  {
    public static void Load()
    {
      Console.Clear();
      Console.WriteLine("══════════════════════════════════════════════");
      Console.WriteLine("          🏷️  GESTÃO DE TAGS - MENU           ");
      Console.WriteLine("══════════════════════════════════════════════");
      Console.WriteLine(" [1] 📋 Listar Tags");
      Console.WriteLine(" [2] ✍️  Criar Tag");
      Console.WriteLine(" [3] ✏️  Atualizar Tag");
      Console.WriteLine(" [4] ❌ Deletar Tag");
      Console.WriteLine(" [0] ↩️  Voltar ao Menu Principal");
      Console.WriteLine("══════════════════════════════════════════════");
      Console.Write(" 👉 Escolha uma opção: ");

      if (!short.TryParse(Console.ReadLine(), out short option))
      {
        Program.ShowInvalidOption();
        Load();
        return;
      }

      switch (option)
      {
        case 1:
          ListTagScreen.Load();
          break;
        case 2:
          CreateTagScreen.Load();
          break;
        case 3:
          UpdateTagScreen.Load();
          break;
        case 4:
          DeleteTagScreen.Load();
          break;
        case 0:
          Program.Menu();
          break;
        default:
          Program.ShowInvalidOption();
          Load();
          break;
      }
    }
  }
}