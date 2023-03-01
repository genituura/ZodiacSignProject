using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using ZodiacSignLibrary.Models;
using ZodiacSignLibrary.Models.Entities;

namespace ZodiacSignProject.Pages.Admin.SendMessageOnOrder;

public partial class SendMessageOnOrderPage : Page
{
    [SuppressMessage("ReSharper.DPA", "DPA0009: High execution time of DB command", MessageId = "time: 627ms")]
    public SendMessageOnOrderPage()
    {
        InitializeComponent();
        DbGridModel.ItemsSource = ZodiacSignDbContext.GetContext()
                                                     .Services
                                                     .OrderBy(x => x.Id)
                                                     .ToList();
    }

    private void BtnBack_OnClick(object sender, RoutedEventArgs e)
    {
        Classes.Manager.MainFrame.GoBack();
    }

    private void ConfirmOrder_OnClick(object sender, RoutedEventArgs e)
    {
        Classes.Manager.MainFrame.Navigate(new ConfirmMessage((sender as Button)?.DataContext as Services));

    }

    private void SendMessageOnOrderPage_OnIsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
    {
        if (Visibility != Visibility.Visible) return;
        
        ZodiacSignDbContext.GetContext()
            .ChangeTracker
            .Entries()
            .ToList()
            .ForEach(r => r.Reload());
        DbGridModel.ItemsSource = ZodiacSignDbContext.GetContext()
                                                     .Services
                                                     .OrderBy(x => x.Id)
                                                     .ToList();
    }
}