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

    void Switch_Toggled(System.Object sender, Microsoft.Maui.Controls.ToggledEventArgs e) { }
}
