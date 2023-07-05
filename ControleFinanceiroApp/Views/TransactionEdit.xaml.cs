using ControleFinanceiroApp.Model;

namespace ControleFinanceiroApp.Views;

public partial class TransactionEdit : ContentPage
{
    private Transaction _transaction;
    public TransactionEdit()
    {
        InitializeComponent();
    }

    public void SetTransactionToEdit(Transaction transaction)
    {
        _transaction = transaction;

        if (transaction.Type == TransactionType.Income)
            Entry_RadioIncome.IsChecked = true;

        else
            Entry_RadioExpense.IsChecked = true;

        Entry_Name.Text = transaction.Name;
        Entry_Value.Text = transaction.Value.ToString();
        DatePickerValue.Date = transaction.Date.Date;
    }

    private void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        Navigation.PopModalAsync();
    }
}