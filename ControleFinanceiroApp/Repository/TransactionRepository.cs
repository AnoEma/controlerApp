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

    public void Add(Transaction transaction)
    {
        throw new NotImplementedException();
    }

    public void Delete(Transaction transaction)
    {
        throw new NotImplementedException();
    }

    public List<Transaction> GetAll()
    {
        return _database
            .GetCollection<Transaction>(collectionName)
            .Query()
            .OrderByDescending(x => x.Date)
            .ToList();
    }

    public void Update(Transaction transaction)
    {
        throw new NotImplementedException();
    }
}