using ControleFinanceiroApp.Model;
using LiteDB;

namespace ControleFinanceiroApp.Repository;

public class TransactionRepository : ITransactionRepository
{
    private readonly LiteDatabase _database;
    private readonly string collectionName = "transactions";

    public TransactionRepository(LiteDatabase database)
    {
        _database = database;
    }

    public async Task Add(Transaction transaction)
    {
        var col = _database.GetCollection<Transaction>(collectionName);
        col.Insert(transaction);
        col.EnsureIndex(x => x.Date);
    }

    public async Task Delete(Transaction transaction)
    {
        _database
            .GetCollection<Transaction>(collectionName)
            .Delete(transaction.Id);
    }

    public List<Transaction> GetAll()
    {
        return _database
            .GetCollection<Transaction>(collectionName)
            .Query()
            .OrderByDescending(x => x.Date)
            .ToList();
    }

    public async Task Update(Transaction transaction)
    {
       _database
            .GetCollection<Transaction>(collectionName)
            .Update(transaction);
    }
}