using ControleFinanceiroApp.Model;
using System.Globalization;

namespace ControleFinanceiroApp.Libraries.Converters;

public class TransactionValueColorConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        Transaction transaction = value as Transaction;
        if (transaction == null)
        {
            return Colors.Black;
        }
        return
            transaction.Type == TransactionType.Income ? Color.FromRgba("#FF939E5A") : Colors.Red;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}