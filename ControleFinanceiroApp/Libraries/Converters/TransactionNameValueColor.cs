using System.Globalization;

namespace ControleFinanceiroApp.Libraries.Converters;

public class TransactionNameValueColor : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        var name = value as string;
        if (string.IsNullOrEmpty(name))
        {
            return Colors.Black;
        }

        var random = new Random();
        var color = String.Format("#FF{0:X6}", random.Next(0x1000000));
        return Color.FromArgb(color);
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
