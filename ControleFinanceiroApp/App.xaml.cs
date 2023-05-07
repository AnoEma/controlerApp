using ControleFinanceiroApp.Views;

namespace ControleFinanceiroApp;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new TransactionList();
	}
}
