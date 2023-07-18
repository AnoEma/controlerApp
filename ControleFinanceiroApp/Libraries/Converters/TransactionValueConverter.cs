using ControleFinanceiroApp.Model;
using System.Globalization;

namespace ControleFinanceiroApp.Libraries.Converters;

public class TransactionValueConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        Transaction transaction = value as Transaction;
        if (transaction == null)
        {
            return string.Empty;
        }
        return
            transaction.Type == TransactionType.Income ? transaction.Value.ToString("C") :
            $"-{transaction.Value.ToString("C")}";
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
