using System.Windows;
using System.Windows.Input;

namespace ZodiacSignProject.Windows
{
    /// <summary>
    /// Логика взаимодействия для ClientWindow.xaml
    /// </summary>
    public partial class ClientWindow : Window
    {
        public ClientWindow()
        {
            InitializeComponent();
            MainFrame.Navigate(new Pages.Client.MainPage(this));
            Classes.Manager.MainFrame = MainFrame;
        }

        private void GoToMain_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            new MainWindow().Show();
            this.Hide();
        }
    }
}
