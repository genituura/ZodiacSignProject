using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using ZodiacSignLibrary.Models;
using ZodiacSignLibrary.Models.Entities;

namespace ZodiacSignProject.Pages.Admin.SendMessageOnOrder;

public partial class ConfirmMessage : Page
{
    private static Services? _services = new();
    public ConfirmMessage(Services? services)
    {
        InitializeComponent();
        
        _services = services;
        DataContext = _services;

        var humanSign = GetSign();
        
        var sign = ZodiacSignDbContext.GetContext()
                                      .ZodiacSignInfo
                                      .FirstOrDefault(x => x.SignName.ToLower() == humanSign.ToLower());

        Message.Text = $"Уважаемый, {_services?.Client.NameClient}.\n" +
                       "Вашему вниманию представляется следующий разбор:\n" +
                       $"Ваш знак зодиака: {humanSign}\n" +
                       $"Описание данного знака: {sign?.SignInfo}";

    }

    private static string GetSign()
    {
        var dateTime = Convert.ToString(_services!.DateOfBirth, CultureInfo.InvariantCulture).Split(' ');
        var date = dateTime[0].Split('/');
        var sign = int.Parse(date[1]) switch
        {
            1 => int.Parse(date[0]) <= 20 ? "Козерог" : "Водолей",
            2 => int.Parse(date[0]) <= 19 ? "Водолей" : "Рыбы",
            3 => int.Parse(date[0]) <= 20 ? "Рыбы" : "Овен",
            4 => int.Parse(date[0]) <= 20 ? "Овен" : "Телец",
            5 => int.Parse(date[0]) <= 21 ? "Телец" : "Близнецы",
            6 => int.Parse(date[0]) <= 21 ? "Близнецы" : "Рак",
            7 => int.Parse(date[0]) <= 22 ? "Рак" : "Лев",
            8 => int.Parse(date[0]) <= 23 ? "Лев" : "Дева",
            9 => int.Parse(date[0]) <= 23 ? "Дева" : "Весы",
            10 => int.Parse(date[0]) <= 23 ? "Весы" : "Скорпион",
            11 => int.Parse(date[0]) <= 22 ? "Скорпион" : "Стрелец",
            12 => int.Parse(date[0]) <= 23 ? "Стрелец" : "Козерог",
            _ => ""
        };

        return sign;
    }

    [SuppressMessage("ReSharper.DPA", "DPA0009: High execution time of DB command", MessageId = "time: 4553ms")]
    private void Confirm_OnClick(object sender, RoutedEventArgs e)
    {
        try
        {
            if (_services != null) ZodiacSignDbContext.GetContext().Services.Remove(_services);
            ZodiacSignDbContext.GetContext().SaveChanges();
            MessageBox.Show("Данные успешно удалены!",
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