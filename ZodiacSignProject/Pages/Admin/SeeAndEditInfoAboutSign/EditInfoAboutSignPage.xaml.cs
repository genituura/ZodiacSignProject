using System;
using System.Windows;
using System.Windows.Controls;
using ZodiacSignLibrary.Models;
using ZodiacSignLibrary.Models.Entities;

namespace ZodiacSignProject.Pages.Admin.SeeAndEditInfoAboutSign;

public partial class EditInfoAboutSignPage : Page
{
    private ZodiacSignInfo? _info = new();

    public EditInfoAboutSignPage(ZodiacSignInfo? zodiacSignInfo)
    {
        InitializeComponent();

        _info = zodiacSignInfo;
        DataContext = _info;
    }

    private void EditDataBtn_OnClick(object sender, RoutedEventArgs e)
    {
        try
        {
            ZodiacSignDbContext.GetContext().SaveChanges();
            MessageBox.Show("Данные успешно обновлены!",
                "Внимание!",
                MessageBoxButton.OK,
                MessageBoxImage.Information);
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