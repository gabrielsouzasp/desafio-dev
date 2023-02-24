using Dapper;
using DesafioDev.Web.Interfaces.Repositories;
using DesafioDev.Web.Models;
using DesafioDev.Web.Models.Enums;
using MySql.Data.MySqlClient;

namespace DesafioDev.Web.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        const string connectionString = "server=db;database=desafiodev;user=root;password=root";

        public async Task<List<TransactionModel>> GetAllAsync()
        {
            using var connection = new MySqlConnection(connectionString);
            await connection.OpenAsync();

            var result = await connection.QueryAsync("SELECT * FROM transactions");
            var transactionList = new List<TransactionModel>();

            foreach (var row in result)
            {
                var transactionModel = new TransactionModel
                {
                    Type = (TransactionTypeEnum) row.Type,
                    Date = row.Date,
                    Amount = row.Amount,
                    Document = row.Document,
                    Card = row.Card,
                    Hour = row.Hour,
                    StoreOwner = row.StoreOwner,
                    StoreName = row.StoreName
                };

                transactionList.Add(transactionModel);
            }

            await connection.CloseAsync();

            return transactionList;
        }

        public async Task<bool> SaveAsync(List<TransactionModel> transactionList)
        {
            using var connection = new MySqlConnection(connectionString);
            await connection.OpenAsync();

            var query = "INSERT INTO transactions(Type, Date, Amount, Document, Card, Hour, StoreOwner, StoreName) VALUES (@Type, @Date, @Amount, @Document, @Card, @Hour, @StoreOwner, @StoreName)";

            var result = await connection.ExecuteAsync(query, transactionList);

            await connection.CloseAsync();

            return result > 0;
        }
    }
}
