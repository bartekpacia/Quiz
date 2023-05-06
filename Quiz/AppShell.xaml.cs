namespace Quiz;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        Routing.RegisterRoute(nameof(PlayPage), typeof(PlayPage));
        Routing.RegisterRoute(nameof(CreatePage), typeof(CreatePage));
    }
}
