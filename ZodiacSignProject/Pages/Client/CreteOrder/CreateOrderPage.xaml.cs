using System;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using ZodiacSignLibrary.Models;
using ZodiacSignLibrary.Models.Entities;

namespace ZodiacSignProject.Pages.Client.CreteOrder;

public partial class CreateOrderPage : Page
{
    public CreateOrderPage()
    {
        InitializeComponent();
    }

    private void CreateOrderBtn_OnClick(object sender, RoutedEventArgs e)
    {
        var error = new StringBuilder();

        if (string.IsNullOrEmpty(DateOfBirth.Text))
            error.AppendLine("Пожалуйста, введите Вашу дату рождения!");
        if (string.IsNullOrEmpty(TimeOfBirth.Text))
            error.AppendLine("Пожалуйста, введите Вашe время рождения!");
        if (string.IsNullOrEmpty(CityOfBirth.Text))
            error.AppendLine("Пожалуйста, введите Ваш город рождения!");
        if (string.IsNullOrEmpty(EmailBox.Text))
            error.AppendLine("Пожалуйста, введите Вашe почту!");

        if (!Classes.Validation.ValidateEmail(EmailBox.Text))
            error.AppendLine("Пожалуйста, введите корректную почту!");

        if (!Classes.Validation.ValidateDate(DateOfBirth.Text))
            error.AppendLine("Пожалуйста, введите следующий формат даты: yyyy-MM-dd");

        if (!Classes.Validation.ValidateTime(TimeOfBirth.Text))
            error.AppendLine("Пожалуйста, введите следующий формат времени: hh:mm:ss");
        
        /*if (DateTime.Now.Year - DateTime.Parse(DateOfBirth.Text).Year < 18)
            error.AppendLine("Приносим свои извинения, но мы проводим расклады лишь совершеннолетним!");*/

        if (error.Length > 0)
        {
            MessageBox.Show(error.ToString(),
                "Внимание!",
                MessageBoxButton.OK,
                MessageBoxImage.Error);
            return;
        }

        var services = new Services
        {
            DateOfBirth = DateTime.Parse(DateOfBirth.Text),
            TimeOfBirth = TimeOnly.Parse(TimeOfBirth.Text),
            CityOfBirth = CityOfBirth.Text,
            DeliveryEmail = EmailBox.Text,
            ClientId = Classes.Manager.AuthClient.Id
        };
        
        try
        {
            ZodiacSignDbContext.GetContext().Services.Add(services);
            ZodiacSignDbContext.GetContext().SaveChanges();
            MessageBox.Show("Заказ успешно оформлен!",
                "Успех!",
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