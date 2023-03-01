using System.Linq;
using System.Windows;
using System.Windows.Controls;
using ZodiacSignLibrary.Models;

namespace ZodiacSignProject.Pages.Client.Signs.Fire;

public partial class AriesPage : Page
{
    public AriesPage()
    {
        InitializeComponent();
        
        var sign = ZodiacSignDbContext.GetContext().ZodiacSignInfo.FirstOrDefault(x => x.Id == 1);
        DataContext = sign;
    }

    private void LeoPage_OnClick(object sender, RoutedEventArgs e)
    {
        Classes.Manager.MainFrame.Navigate(new LeoPage());
    }
}