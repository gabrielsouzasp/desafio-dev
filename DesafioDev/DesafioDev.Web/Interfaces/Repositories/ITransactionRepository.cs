using DesafioDev.Web.Models;

namespace DesafioDev.Web.Interfaces.Repositories
{
    public interface ITransactionRepository
    {
        Task<List<TransactionModel>> GetAllAsync();
        Task<bool> SaveAsync(List<TransactionModel> transactionList);
    }
}
