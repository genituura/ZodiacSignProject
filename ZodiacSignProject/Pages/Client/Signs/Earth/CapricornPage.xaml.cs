using System.Linq;
using System.Windows;
using System.Windows.Controls;
using ZodiacSignLibrary.Models;

namespace ZodiacSignProject.Pages.Client.Signs.Earth;

public partial class CapricornPage : Page
{
    public CapricornPage()
    {
        InitializeComponent();
        
        var sign = ZodiacSignDbContext.GetContext().ZodiacSignInfo.FirstOrDefault(x => x.Id == 10);
        DataContext = sign;
    }

    private void TaurusPage_OnClick(object sender, RoutedEventArgs e)
    {
        Classes.Manager.MainFrame.Navigate(new TaurusPage());
    }
}