using System;
using System.Globalization;
using Avalonia.Data.Converters;

namespace ToolPocket.Converters;

public class BoolToYesNoConverter : IValueConverter
{
    object IValueConverter.Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        return (bool)(value ?? false) ? "Yes" : "No";
    }

    public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        return (string)value! == "Yes";
    }
}