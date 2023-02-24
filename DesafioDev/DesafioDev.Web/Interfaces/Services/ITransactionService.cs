using DesafioDev.Web.Models.Dtos;

namespace DesafioDev.Web.Interfaces.Services
{
    public interface ITransactionService
    {
        Task<TransactionDto> GetTransactionsAsync();
        Task<bool> SaveTransactionsAsync(IFormFile file);
    }
}
