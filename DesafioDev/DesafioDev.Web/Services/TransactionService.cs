using DesafioDev.Web.Interfaces.Repositories;
using DesafioDev.Web.Interfaces.Services;
using DesafioDev.Web.Models;
using DesafioDev.Web.Models.Dtos;
using DesafioDev.Web.Models.Enums;

namespace DesafioDev.Web.Services
{
    public class TransactionService : ITransactionService
    {
        readonly ITransactionRepository _transactionRepository;

        public TransactionService(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        public async Task<TransactionDto> GetTransactionsAsync()
        {
            try
            {
                var transactions = await _transactionRepository.GetAllAsync();

                return new TransactionDto()
                {
                    Transactions = transactions,
                    TotalAmount = await GetTotalAmount(transactions)
                };
            }
            catch (Exception ex)
            {
                throw new ArgumentException($"Erro ao obter as transações", ex);
            }
        }

        public async Task<bool> SaveTransactionsAsync(IFormFile file)
        {
            try
            {
                if (file == null || file.Length == 0)
                    return false;

                if (!Path.GetExtension(file.FileName).Equals(".txt"))
                    return false;

                string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);

                using var stream = new StreamReader(file.OpenReadStream());
                var transactionList = new List<TransactionModel>();

                while (!stream.EndOfStream)
                    transactionList.Add(await MapTransactionAsync(await stream.ReadLineAsync()));

                if (transactionList.Any())
                    return await _transactionRepository.SaveAsync(transactionList);

                return false;
            }
            catch (Exception ex)
            {
                throw new ArgumentException($"Erro ao salvar as transações", ex);
            }
        }

        private async Task<TransactionModel> MapTransactionAsync(string transactionFile)
        {
            if (string.IsNullOrWhiteSpace(transactionFile))
                return null;

            return new TransactionModel
            {
                Type = (TransactionTypeEnum)int.Parse(transactionFile.Substring(0, 1)),
                Date = transactionFile.Substring(1, 8),
                Amount = decimal.Parse(transactionFile.Substring(9, 10)) / 100,
                Document = transactionFile.Substring(19, 11),
                Card = transactionFile.Substring(30, 12),
                Hour = transactionFile.Substring(42, 6),
                StoreOwner = transactionFile.Substring(48, 14).Trim(),
                StoreName = transactionFile.Substring(62, 18).Trim(),
            };
        }

        private async Task<decimal> GetTotalAmount(List<TransactionModel> transactionList)
        {
            decimal totalAmount = 0.0m;

            foreach (var transaction in transactionList)
                switch (transaction.Type)
                {
                    case TransactionTypeEnum.Debit:
                        totalAmount += transaction.Amount;
                        break;
                    case TransactionTypeEnum.Slip:
                        totalAmount -= transaction.Amount;
                        break;
                    case TransactionTypeEnum.Financing:
                        totalAmount -= transaction.Amount;
                        break;
                    case TransactionTypeEnum.Credit:
                        totalAmount += transaction.Amount;
                        break;
                    case TransactionTypeEnum.LoanIn:
                        totalAmount += transaction.Amount;
                        break;
                    case TransactionTypeEnum.Sales:
                        totalAmount += transaction.Amount;
                        break;
                    case TransactionTypeEnum.TedIn:
                        totalAmount += transaction.Amount;
                        break;
                    case TransactionTypeEnum.DocIn:
                        totalAmount += transaction.Amount;
                        break;
                    case TransactionTypeEnum.Rent:
                        totalAmount -= transaction.Amount;
                        break;
                    default:
                        break;
                }

            return totalAmount;
        }
    }
}
