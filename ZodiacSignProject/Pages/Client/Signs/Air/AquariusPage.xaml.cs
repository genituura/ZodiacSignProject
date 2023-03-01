using System.Linq;
using System.Windows;
using System.Windows.Controls;
using ZodiacSignLibrary.Models;

namespace ZodiacSignProject.Pages.Client.Signs.Air;

public partial class AquariusPage : Page
{
    public AquariusPage()
    {
        InitializeComponent();

        var sign = ZodiacSignDbContext.GetContext().ZodiacSignInfo.FirstOrDefault(x => x.Id == 11);
        DataContext = sign;
    }

    private void GeminiPage_OnClick(object sender, RoutedEventArgs e)
    {
        Classes.Manager.MainFrame.Navigate(new GeminiPage());
    }
}