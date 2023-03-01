using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ZodiacSignProject.Windows
{
    /// <summary>
    /// Логика взаимодействия для RegAuthWindow.xaml
    /// </summary>
    public partial class RegAuthWindow : Window
    {
        public RegAuthWindow()
        {
            InitializeComponent();
            MainFrame.Navigate(new Pages.Authentication.AuthenticationPage(this));
            Classes.Manager.MainFrame = MainFrame;
        }

        private void GoToAuthReg_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if ((string)GoToAuthReg.Content == "Впервые у нас? Зарегистрируйтесь!")
                Classes.Manager.MainFrame.Navigate(new Pages.Authentication.RegistrationPage(this));
            else
                Classes.Manager.MainFrame.Navigate(new Pages.Authentication.AuthenticationPage(this));
        }

        private void MainFrame_OnContentRendered(object? sender, EventArgs e)
        {
            GoToAuthReg.Content = MainFrame.CanGoBack
                                  ? "Уже есть аккаунт? Войдите!"
                                  : "Впервые у нас? Зарегистрируйтесь!";
        }
    }
}
