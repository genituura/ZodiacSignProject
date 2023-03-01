using System.Linq;
using System.Windows;
using System.Windows.Controls;
using ZodiacSignLibrary.Models;

namespace ZodiacSignProject.Pages.Client.Signs.Water;

public partial class ScorpioPage : Page
{
    public ScorpioPage()
    {
        InitializeComponent();
        
        var sign = ZodiacSignDbContext.GetContext().ZodiacSignInfo.FirstOrDefault(x => x.Id == 8);
        DataContext = sign;
    }

    private void PiscesPage_OnClick(object sender, RoutedEventArgs e)
    {
        Classes.Manager.MainFrame.Navigate(new PiscesPage());
    }
}