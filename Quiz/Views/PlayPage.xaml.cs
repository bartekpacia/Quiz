using Quiz.ViewModels;

namespace Quiz;

public partial class PlayPage : ContentPage
{
    public PlayPage(PlayViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}
