using Quiz.Models;

namespace Quiz;

public partial class App : Application
{
<<<<<<< Updated upstream
    public static DbService DbService { get; private set; }

    //public static Store Store { get; private set; }
=======
    public static Db Db { get; private set; }
>>>>>>> Stashed changes

    public static Store Store { get; private set; }

    public App(Db db, Store store)
    {
        InitializeComponent();

        MainPage = new AppShell();

        Db = db;
        Store = store;
    }
}
