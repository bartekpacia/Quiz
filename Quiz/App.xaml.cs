using Quiz.Models;

namespace Quiz;

public partial class App : Application
{
    public static DbService DbService { get; private set; }

    //public static Store Store { get; private set; }

    public App(DbService dbService)
    {
        InitializeComponent();

        MainPage = new AppShell();

        DbService = dbService;
        //Store = Store;
    }
}
