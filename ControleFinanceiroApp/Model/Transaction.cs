namespace ControleFinanceiroApp.Model;

public class Transaction
{
    public int Id { get; set; }
    public int Name { get; set; }
    public decimal Value { get; set; }
    public DateTimeOffset Date { get; set; }
    public TransactionType Type { get; set; }
}