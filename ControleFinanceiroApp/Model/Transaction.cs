namespace ControleFinanceiroApp.Model;

public class Transaction
{
    public int Id { get; set; }
    public string Name { get; set; }
    public double Value { get; set; }
    public DateTimeOffset Date { get; set; }
    public TransactionType Type { get; set; }
}