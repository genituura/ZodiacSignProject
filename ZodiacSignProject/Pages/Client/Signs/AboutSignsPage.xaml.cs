using System.Windows;
using System.Windows.Controls;

namespace ZodiacSignProject.Pages.Client.Signs;

public partial class AboutSigns : Page
{
    private readonly Window _closedWindow;
    public AboutSigns(Window window)
    {
        InitializeComponent();
        MainFrame.Navigate(new Air.AquariusPage());
        Classes.Manager.MainFrame = MainFrame;

        _closedWindow = window;
    }

    private void SeeAirSign_OnClick(object sender, RoutedEventArgs e)
    {
        MainFrame.Navigate(new Air.AquariusPage());
    }

    private void SeeEarthSign_OnClick(object sender, RoutedEventArgs e)
    {
        MainFrame.Navigate(new Earth.CapricornPage());
    }

    private void SeeFireSign_OnClick(object sender, RoutedEventArgs e)
    {
        MainFrame.Navigate(new Fire.AriesPage());
    }

    private void SeeWaterSign_OnClick(object sender, RoutedEventArgs e)
    {
        MainFrame.Navigate(new Water.CancerPage());
    }

    private void ExitBtn_OnClick(object sender, RoutedEventArgs e)
    {
        new Windows.ClientWindow().Show();
        _closedWindow.Hide();
    }
}