using CommunityToolkit.Mvvm.Messaging;
using ControleFinanceiroApp.Model;
using ControleFinanceiroApp.Repository;
using System.Text;

namespace ControleFinanceiroApp.Views;

public partial class TransactionAdd : ContentPage
{
    private readonly ITransactionRepository _repository;
    public TransactionAdd(ITransactionRepository repository)
    {
        InitializeComponent();
        _repository = repository;
    }

    private void TapGestureRecognizerTappedToClose(object sender, TappedEventArgs e)
    {
        Navigation.PopModalAsync();
    }

    private async void OnSave(object sender, EventArgs e)
    {
        if (!IsValidData())
            return;

        await SaveTransaction();
        await Navigation.PopModalAsync();

        string evento = "Created";
        //Publicar evento
        WeakReferenceMessenger.Default.Send<string>(evento);

        var count = await _repository.GetAll();

        await App.Current.MainPage.DisplayAlert("Message", $"Quantidade de registro {count.Count}", "OK");
    }

    private async Task SaveTransaction()
    {
        Transaction model = new Transaction
        {
            Name = Entry_Name.Text,
            Value = Convert.ToDouble(Entry_Valor.Text),
            Date = DatePickerValue.Date,
            Type = Entry_RadioIncome.IsChecked ? TransactionType.Income : TransactionType.Expenses
        };

        await _repository.Add(model);
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

        if (string.IsNullOrEmpty(Entry_Valor.Text))
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