using System.Windows;
using System.Windows.Controls;
using ZodiacSignProject.Pages.Client.CreteOrder;

namespace ZodiacSignProject.Pages.Client;

public partial class MainPage : Page
{
    private readonly Window _closedWindow;
    public MainPage(Window window)
    {
        InitializeComponent();
        DataContext = Classes.Manager.AuthClient;
        
        _closedWindow = window;
    }

    private void LookSignBtn_OnClick(object sender, RoutedEventArgs e)
    {
        Classes.Manager.MainFrame.Navigate(new Signs.AboutSigns(_closedWindow));
    }

    private void CreateOrderBtn_OnClick(object sender, RoutedEventArgs e)
    {
        Classes.Manager.MainFrame.Navigate(new CreateOrderPage());
    }

    private void EditProfileBtn_OnClick(object sender, RoutedEventArgs e)
    {
        Classes.Manager.MainFrame.Navigate(new EditProfile.EditProfilePage());
    }
}