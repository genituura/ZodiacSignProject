using System.Windows;
using System.Windows.Controls;
using ZodiacSignLibrary.Models.Entities;

namespace ZodiacSignProject.Classes;

public class Manager
{
    /// <summary>
    /// Постраничная навигация.
    /// </summary>
    public static Frame MainFrame { get; set; } = null!;

    /// <summary>
    /// Авторизированный клиент.
    /// </summary>
    public static Client AuthClient = null!;

    /// <summary>
    /// Авторизированный администратор.
    /// </summary>
    public static Admin AuthAdmin = null!;
}