using ControleFinanceiroApp.Model;

namespace ControleFinanceiroApp.Repository;

public interface ITransactionRepository
{
    void Add(Transaction transaction);
    void Delete(Transaction transaction);
    List<Transaction> GetAll();
    void Update(Transaction transaction);
}