namespace Blog.Screens.TagScreens
{
  public static class MenuTagScreen
  {
    public static void Load()
    {
      Menu.MenuLoad("Tag");

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