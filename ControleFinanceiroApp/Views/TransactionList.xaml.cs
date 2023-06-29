using CommunityToolkit.Mvvm.Messaging;
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
        CollectionViewTransactions.ItemsSource = _repository.GetAll().Result;
    }

    private void OnButtonClicked_To_TransactionAdd(object sender, EventArgs e)
    {
        var _transactionAddPage = Handler.MauiContext.Services.GetService<TransactionAdd>();
        Navigation.PushModalAsync(_transactionAddPage);
    }

    private void OnButtonClicked_To_TransactionEdit(object sender, EventArgs e)
    {
        var _transactionEditPage = Handler.MauiContext.Services.GetService<TransactionEdit>();
        Navigation.PushModalAsync(_transactionEditPage);
    }
}