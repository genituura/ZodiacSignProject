using System;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using ZodiacSignLibrary.Models;
using ZodiacSignLibrary.Models.Entities;
using ZodiacSignProject.Windows;

namespace ZodiacSignProject.Pages.Authentication;

public partial class RegistrationPage : Page
{
    private readonly Window _closeWindow;
    public RegistrationPage(Window window)
    {
        InitializeComponent();
        _closeWindow = window;
    }

    private void RegBtn_OnClick(object sender, RoutedEventArgs e)
    {
        var error = new StringBuilder();

        if (string.IsNullOrEmpty(NameBox.Text))
            error.AppendLine("Пожалуйста, введите Ваше имя!");
        if (string.IsNullOrEmpty(SurnameBox.Text))
            error.AppendLine("Пожалуйста, введите Вашу фамилию!");
        if (string.IsNullOrEmpty(EmailBox.Text))
            error.AppendLine("Пожалуйста, введите Вашу почту!");
        if (string.IsNullOrEmpty(LoginBox.Text))
            error.AppendLine("Пожалуйста, введите Ваш логин!");
        if (string.IsNullOrEmpty(PasswordBox.Text))
            error.AppendLine("Пожалуйста, введите Ваш пароль!");

        if (!Classes.Validation.ValidateEmail(EmailBox.Text))
            error.AppendLine("Пожалуйста, введите корректную почту!");
        if (!Classes.Validation.ValidatePassword(PasswordBox.Text))
            error.AppendLine("Ошибка заполнения данных. Пароль  должен  отвечать  следующим требованиям:\n" +
                             "1) Минимум 6 символов;\n" +
                             "2) Минимум 1 прописная буква;\n" +
                             "3) Минимум 1 цифра;\n" +
                             "4) Минимум один символ из набора: ! @ # $ % ^.");

        using (var db = new ZodiacSignDbContext())
        {
            foreach (var item in db.Client)
            {
                if (item.LoginClient == LoginBox.Text)
                    error.AppendLine("Пользователь с таким логином уже существует!");
                if (item.EmailClient == EmailBox.Text)
                    error.AppendLine("Пользователь с такой почтой уже существует!");
            }
            
            foreach (var item in db.Admin)
            {
                if (item.LoginAdmin == LoginBox.Text)
                    error.AppendLine("Пользователь с таким логином уже существует!");
                if (item.EmailAdmin == EmailBox.Text)
                    error.AppendLine("Пользователь с такой почтой уже существует!");
            }
        }

        if (error.Length > 0)
        {
            MessageBox.Show(error.ToString(),
                            "Внимание!",
                            MessageBoxButton.OK,
                            MessageBoxImage.Error);
            return;
        }
        
        var client = new ZodiacSignLibrary.Models.Entities.Client
        {
            NameClient = NameBox.Text,
            SurnameClient = SurnameBox.Text,
            EmailClient = EmailBox.Text,
            LoginClient = LoginBox.Text,
            PasswordClient = PasswordBox.Text
        };

        try
        {
            ZodiacSignDbContext.GetContext().Client.Add(client);
            ZodiacSignDbContext.GetContext().SaveChanges();
            MessageBox.Show("Успешная регистрация!",
                            "Успех!",
                            MessageBoxButton.OK,
                            MessageBoxImage.Information);
            Classes.Manager.AuthClient = client;
            new ClientWindow().Show();
            _closeWindow.Hide();

            
        }
        catch (Exception exception)
        {
            MessageBox.Show(exception.Message.ToString(),
                            "Внимание!",
                            MessageBoxButton.OK,
                            MessageBoxImage.Error);
        }

    }
}