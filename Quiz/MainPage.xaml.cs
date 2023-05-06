using System;

namespace Quiz;

public partial class MainPage : ContentPage
{
    int count = 0;

    public MainPage()
    {
        InitializeComponent();
    }

    private void OnCounterIncrement(object sender, EventArgs e)
    {
        count++;

        UpdateButton();
    }

    private void OnCounterDecrement(object sender, EventArgs e)
    {
        count--;

        UpdateButton();
    }

    private void UpdateButton()
    {
        if (count == 1)
        {
            CounterLabel.Text = $"Clicked {count} time";
        }
        else
        {
            CounterLabel.Text = $"Clicked {count} times";
        }
    }
}
