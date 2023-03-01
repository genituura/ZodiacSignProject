using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using ZodiacSignLibrary.Models;

namespace ZodiacSignProject.Pages.Authentication;

public partial class AuthenticationPage : Page
{
    private readonly Window _hideWindow = new();

    public AuthenticationPage(Window window)
    {
        InitializeComponent();
        _hideWindow = window;
    }

    private void AuthBtn_OnClick(object sender, RoutedEventArgs e)
    {
        var error = new StringBuilder();

        if (string.IsNullOrEmpty(LoginBox.Text))
            error.AppendLine("Пожалуйста, введите Ваш логин!");
        if (string.IsNullOrEmpty(PasswordBox.Text))
            error.AppendLine("Пожалуйста, введите Ваш пароль!");

        if (!Classes.Validation.ValidatePassword(PasswordBox.Text))
            error.AppendLine("Ошибка заполнения данных. Пароль  должен  отвечать  следующим требованиям:\n" +
                             "1) Минимум 6 символов;\n" +
                             "2) Минимум 1 прописная буква;\n" +
                             "3) Минимум 1 цифра;\n" +
                             "4) Минимум один символ из набора: ! @ # $ % ^.");

        if (error.Length > 0)
        {
            MessageBox.Show(error.ToString(),
                            "Внимание!",
                            MessageBoxButton.OK,
                            MessageBoxImage.Error);
            return;
        }

        var client = ZodiacSignDbContext.GetContext()
                                        .Client
                                        .FirstOrDefault(x => x.LoginClient == LoginBox.Text &&
                                                        x.PasswordClient == PasswordBox.Text);

        var admin = ZodiacSignDbContext.GetContext()
                                       .Admin
                                       .FirstOrDefault(x => x.LoginAdmin == LoginBox.Text &&
                                                       x.PasswordAdmin == PasswordBox.Text);

        if (admin == null && client == null)
        {
            MessageBox.Show("Не правильно введен логин или пароль. Проверьте свои данные!", 
                            "Внимание!", 
                            MessageBoxButton.OK, 
                            MessageBoxImage.Error);
        }

        MessageBox.Show($"Добро пожаловать, {(client == null ? admin?.NameAdmin : client?.NameClient)}",
                        "Внимание!",
                        MessageBoxButton.OK,
                        MessageBoxImage.Information);

        if (admin != null)
        {
            Classes.Manager.AuthAdmin = admin;
            new Windows.AdminWindow().Show();
            _hideWindow.Hide();
        }
        
        if (client != null)
        {
            Classes.Manager.AuthClient = client;
            new Windows.ClientWindow().Show();
            _hideWindow.Hide();
        }

    }
}