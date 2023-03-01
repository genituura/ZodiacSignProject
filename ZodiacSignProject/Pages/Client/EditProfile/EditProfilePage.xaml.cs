using System;
using System.Windows;
using System.Windows.Controls;
using Microsoft.VisualBasic.Devices;
using ZodiacSignLibrary.Models;

namespace ZodiacSignProject.Pages.Client.EditProfile;

public partial class EditProfilePage : Page
{
    private ZodiacSignLibrary.Models.Entities.Client _client = new();
    public EditProfilePage()
    {
        InitializeComponent();

        _client = Classes.Manager.AuthClient;
        DataContext = _client;
    }

    private void EditDataBtn_OnClick(object sender, RoutedEventArgs e)
    {
        if (!Classes.Validation.ValidateEmail(EmailBox.Text))
        {
            MessageBox.Show("Пожалуйста, введите корректную почту!",
                "Внимание!",
                MessageBoxButton.OK,
                MessageBoxImage.Error);
            return;
        }

        try
        {
            ZodiacSignDbContext.GetContext().SaveChanges();
            MessageBox.Show("Данные успешно обновлены!",
                "Внимание!",
                MessageBoxButton.OK,
                MessageBoxImage.Information);
            Classes.Manager.AuthClient = _client;
            Classes.Manager.MainFrame.GoBack();
        }
        catch (Exception exception)
        {
            MessageBox.Show(exception.InnerException?.Message.ToString(),
                "Внимание!",
                MessageBoxButton.OK,
                MessageBoxImage.Error);
        }
    }
}