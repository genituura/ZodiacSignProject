using System.Linq;
using System.Windows;
using System.Windows.Controls;
using ZodiacSignLibrary.Models;

namespace ZodiacSignProject.Pages.Client.Signs.Earth;

public partial class TaurusPage : Page
{
    public TaurusPage()
    {
        InitializeComponent();
        
        var sign = ZodiacSignDbContext.GetContext().ZodiacSignInfo.FirstOrDefault(x => x.Id == 2);
        DataContext = sign;
    }

    private void VirgoPage_OnClick(object sender, RoutedEventArgs e)
    {
        Classes.Manager.MainFrame.Navigate(new VirgoPage());
    }

    private void CapricornPage_OnClick(object sender, RoutedEventArgs e)
    {
        Classes.Manager.MainFrame.Navigate(new CapricornPage());
    }
}