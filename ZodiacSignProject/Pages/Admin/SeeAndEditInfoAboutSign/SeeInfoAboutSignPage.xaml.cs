using System.Linq;
using System.Windows;
using System.Windows.Controls;
using ZodiacSignLibrary.Models;
using ZodiacSignLibrary.Models.Entities;

namespace ZodiacSignProject.Pages.Admin.SeeAndEditInfoAboutSign;

public partial class SeeInfoAboutSignPage : Page
{
    public SeeInfoAboutSignPage()
    {
        InitializeComponent();
        DbGridModel.ItemsSource = ZodiacSignDbContext.GetContext()
                                                     .ZodiacSignInfo
                                                     .OrderBy(x => x.Id)
                                                     .ToList();
    }

    private void EditDataBtn_OnClick(object sender, RoutedEventArgs e)
    {
        Classes.Manager.MainFrame.Navigate(new EditInfoAboutSignPage((sender as Button)?.DataContext as ZodiacSignInfo));
    }

    private void SeeInfoAboutSignPage_OnIsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
    {
        if (Visibility != Visibility.Visible) return;
        
        ZodiacSignDbContext.GetContext()
                           .ChangeTracker
                           .Entries()
                           .ToList()
                           .ForEach(r => r.Reload());
        DbGridModel.ItemsSource = ZodiacSignDbContext.GetContext()
                                                     .ZodiacSignInfo
                                                     .OrderBy(x => x.Id)
                                                     .ToList();
    }

    private void BtnBack_OnClick(object sender, RoutedEventArgs e)
    {
        Classes.Manager.MainFrame.GoBack();
    }
}