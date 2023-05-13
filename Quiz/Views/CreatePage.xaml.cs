using Quiz.Models;
using Quiz.ViewModels;

namespace Quiz;

public partial class CreatePage : ContentPage
{
    public CreatePage(CreateViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}
