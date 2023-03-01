using System.Windows;
using System.Windows.Input;

namespace ZodiacSignProject.Windows
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Navigate(new Pages.MainInfo.FirstPartInfo());
            Classes.Manager.MainFrame = MainFrame;
            GoBack.Visibility = Visibility.Hidden;
        }

        private void EnterBtn_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            new RegAuthWindow().Show();
            this.Hide();
        }

        private void GoBack_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            MainFrame.Navigate(new Pages.MainInfo.FirstPartInfo());
            GoNext.Visibility = Visibility.Visible;
            GoBack.Visibility = Visibility.Hidden;
        }

        private void GoNext_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            MainFrame.Navigate(new Pages.MainInfo.SecondPartInfo());
            GoNext.Visibility = Visibility.Hidden;
            GoBack.Visibility = Visibility.Visible;
        }
    }
}