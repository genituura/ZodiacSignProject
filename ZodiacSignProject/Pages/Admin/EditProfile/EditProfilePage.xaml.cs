using System;
using System.Windows;
using System.Windows.Controls;
using ZodiacSignLibrary.Models;

namespace ZodiacSignProject.Pages.Admin.EditProfile;

public partial class EditProfilePage : Page
{
    private ZodiacSignLibrary.Models.Entities.Admin _admin = new();
    
    public EditProfilePage()
    {
        InitializeComponent();
        _admin = Classes.Manager.AuthAdmin;
        DataContext = _admin;
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
            Classes.Manager.AuthAdmin = _admin;
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