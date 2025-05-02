using Avalonia.Controls;
using Avalonia.Interactivity;

namespace DiariodeSaude;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void OnRegistroDiarioClick(object? sender, RoutedEventArgs e)
    {
        var registroDiarioView = new Views.RegistroDiarioView();
        var contentControl = this.FindControl<ContentControl>("registroDiarioContentControl");
        if (contentControl != null) contentControl.Content = registroDiarioView;
    }

}