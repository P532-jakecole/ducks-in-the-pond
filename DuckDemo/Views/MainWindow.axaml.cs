using Avalonia.Controls;
using DuckDemo.Models;

namespace DuckDemo.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();

        // Hook up button click events
        MallardButton.Click += (_, _) => ShowDuck(new MallardDuck());
        RedheadButton.Click += (_, _) => ShowDuck(new RedheadDuck());
    }

    // Helper method to show duck behavior in the TextBlock
    private void ShowDuck(Duck duck)
    {
        OutputTextBlock.Text = duck.Describe();
    }
}
