using Quiz.ViewModels;

namespace Quiz;

public partial class ResultPage : ContentPage
{
    public ResultPage(ResultViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}
