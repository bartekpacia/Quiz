using Quiz.Models;

namespace Quiz;

public partial class App : Application
{
    public static Db Db { get; private set; }

    public static Store Store { get; private set; }

    public App(Db db, Store store)
    {
        InitializeComponent();

        MainPage = new AppShell();

        Db = db;
        Store = store;
    }
}
