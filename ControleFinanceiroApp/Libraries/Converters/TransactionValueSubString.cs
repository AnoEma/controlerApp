using ControleFinanceiroApp.Model;
using System.Globalization;

namespace ControleFinanceiroApp.Libraries.Converters;

public class TransactionValueSubString : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        var name = value as string;
        if (string.IsNullOrEmpty(name))
        {
            return string.Empty;
        }
        return name.Substring(0).ToUpper();
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}