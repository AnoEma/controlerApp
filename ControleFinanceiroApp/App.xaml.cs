using ControleFinanceiroApp.Views;

namespace ControleFinanceiroApp;

public partial class App : Application
{
    public App(TransactionList listPage)
    {
        InitializeComponent();

        MainPage = new NavigationPage(listPage);
    }
}