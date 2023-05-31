using ControleFinanceiroApp.Model;

namespace ControleFinanceiroApp.Repository;

public interface ITransactionRepository
{
    Task Add(Transaction transaction);
    Task Delete(Transaction transaction);
    List<Transaction> GetAll();
    Task Update(Transaction transaction);
}