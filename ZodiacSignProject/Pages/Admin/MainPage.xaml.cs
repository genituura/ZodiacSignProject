using System.Windows;
using System.Windows.Controls;

namespace ZodiacSignProject.Pages.Admin;

public partial class MainPage : Page
{
    private readonly Window _closedWindow;
    public MainPage(Window window)
    {
        InitializeComponent();
        
        DataContext = Classes.Manager.AuthAdmin;
        _closedWindow = window;
    }

    private void LookOrder_OnClick(object sender, RoutedEventArgs e)
    {
        Classes.Manager.MainFrame.Navigate(new SendMessageOnOrder.SendMessageOnOrderPage());
    }

    private void EditInfoAboutSignBtn_OnClick(object sender, RoutedEventArgs e)
    {
        Classes.Manager.MainFrame.Navigate(new SeeAndEditInfoAboutSign.SeeInfoAboutSignPage());
    }

    private void EditProfileBtn_OnClick(object sender, RoutedEventArgs e)
    {
        Classes.Manager.MainFrame.Navigate(new EditProfile.EditProfilePage());
    }
}