using System.Linq;
using System.Windows;
using System.Windows.Controls;
using ZodiacSignLibrary.Models;

namespace ZodiacSignProject.Pages.Client.Signs.Fire;

public partial class SagittariusPage : Page
{
    public SagittariusPage()
    {
        InitializeComponent();
        
        var sign = ZodiacSignDbContext.GetContext().ZodiacSignInfo.FirstOrDefault(x => x.Id == 9);
        DataContext = sign;
    }

    private void LeoPage_OnClick(object sender, RoutedEventArgs e)
    {
        Classes.Manager.MainFrame.Navigate(new LeoPage());
    }
}