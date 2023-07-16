using CommunityToolkit.Mvvm.Messaging;
using ControleFinanceiroApp.Model;
using ControleFinanceiroApp.Repository;
using System.Text;

namespace ControleFinanceiroApp.Views;

public partial class TransactionEdit : ContentPage
{
    private Transaction _transaction;
    private readonly ITransactionRepository _repository;
    public TransactionEdit(ITransactionRepository repository)
    {
        InitializeComponent();
        _repository = repository;
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

    private void TapGestureRecognizerTappedToClose(object sender, TappedEventArgs e)
    {
        Navigation.PopModalAsync();
    }

    private async void OnSaveAsync(object sender, EventArgs e)
    {
        if (!IsValidData())
            return;

        await SaveTransaction();
        await Navigation.PopModalAsync();

        string evento = "Edit";
        //Publicar evento
        WeakReferenceMessenger.Default.Send<string>(evento);
    }

    private async Task SaveTransaction()
    {
        Transaction model = new Transaction
        {
            Id = _transaction.Id,
            Name = Entry_Name.Text,
            Value = Convert.ToDouble(Entry_Value.Text),
            Date = DatePickerValue.Date,
            Type = Entry_RadioIncome.IsChecked ? TransactionType.Income : TransactionType.Expenses
        };

        await _repository.Update(model);
    }

    private bool IsValidData()
    {
        bool isValid = true;
        StringBuilder stringBuilder = new StringBuilder();

        if (string.IsNullOrEmpty(Entry_Name.Text))
        {
            stringBuilder.Append("O campo Nome deve ser preenchido!");
            isValid = false;
        }

        if (DatePickerValue.Date > DateTime.Now.Date)
        {
            isValid = false;
        }

        if (string.IsNullOrEmpty(Entry_Value.Text))
        {
            stringBuilder.Append("O campo Valor deve ser preenchido!");
            isValid = false;
        }

        if (!isValid)
        {
            Label_Error.IsVisible = true;
            Label_Error.Text = stringBuilder.ToString();
        }

        return isValid;
    }

}