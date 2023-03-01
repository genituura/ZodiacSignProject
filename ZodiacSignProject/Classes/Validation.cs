using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace ZodiacSignProject.Classes;

public static class Validation
{
    public static bool ValidateEmail(string value)
    {
        return Regex.IsMatch(value, 
            @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
    }

    public static bool ValidatePassword(string value)
    {
        return Regex.IsMatch(value, 
            @"(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[!@#$%^]).*[A-Za-z\d!@#$%^]{6,}");
    }
    
    public static bool ValidateDate(string value)
    {
        const string dateFormat = "yyyy-MM-dd";
        DateTime scheduleDate;
        return DateTime.TryParseExact(value, dateFormat, DateTimeFormatInfo.InvariantInfo, DateTimeStyles.None, out scheduleDate);
    }
    
    public static bool ValidateTime(string value)
    {
        const string dateFormat = "hh:mm:ss";
        DateTime scheduleDate;
        return DateTime.TryParseExact(value, dateFormat, DateTimeFormatInfo.InvariantInfo, DateTimeStyles.None, out scheduleDate);
    }
}