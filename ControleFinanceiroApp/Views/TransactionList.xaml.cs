using CommunityToolkit.Mvvm.Messaging;
using ControleFinanceiroApp.Model;
using ControleFinanceiroApp.Repository;

namespace ControleFinanceiroApp.Views;

public partial class TransactionList : ContentPage
{
    private readonly ITransactionRepository _repository;
    public TransactionList(ITransactionRepository repository)
    {

        _repository = repository;

        InitializeComponent();
        Reload();

        //Fazer reload apos receber evento
        WeakReferenceMessenger.Default.Register<string>(this, (e, msg) =>
        {
            Reload();
        });
    }

    private void Reload()
    {
        var items = _repository.GetAll().Result;
        CollectionViewTransactions.ItemsSource = items;
        CalculoBalance(items);
    }

    private void CalculoBalance(List<Transaction> items)
    {
        double income = items
                    .Where(x => x.Type == Model.TransactionType.Income)
                    .Sum(x => x.Value);

        double expense = items
            .Where(x => x.Type == Model.TransactionType.Expenses)
            .Sum(x => x.Value);

        double balance = income - expense;

        LabelIncome.Text = income.ToString("C");
        LabelExpense.Text = expense.ToString("C");
        LabelBalancne.Text = income.ToString("C");
    }

    private void OnButtonClicked_To_TransactionAdd(object sender, EventArgs e)
    {
        var _transactionAddPage = Handler.MauiContext.Services.GetService<TransactionAdd>();
        Navigation.PushModalAsync(_transactionAddPage);
    }

    private void TapGestureRecognizerTapped_To_TransactionEdit(object sender, TappedEventArgs e)
    {
        var grid = (Grid)sender;
        var gesture = (TapGestureRecognizer)grid.GestureRecognizers.FirstOrDefault();
        Transaction transaction = (Transaction)gesture.CommandParameter;

        var _transactionEditPage = Handler.MauiContext.Services.GetService<TransactionEdit>();

        _transactionEditPage.SetTransactionToEdit(transaction);

        Navigation.PushModalAsync(_transactionEditPage);
    }
}