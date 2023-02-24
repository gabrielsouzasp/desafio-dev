using DesafioDev.Web.Interfaces.Repositories;
using DesafioDev.Web.Models;
using DesafioDev.Web.Models.Enums;
using DesafioDev.Web.Repositories;
using Moq;

namespace DesafioDev.UnitTest.Repositories
{
    public interface IMysqlConnection
    {
        Task OpenAsync();
        Task CloseAsync();
        Task<int> ExecuteAsync();
    }

    public class TransactionRepositoryTest
    {

        private readonly Mock<IMysqlConnection> _mockConnection;
        private readonly ITransactionRepository _transactionRepository;

        public TransactionRepositoryTest()
        {
            _mockConnection = new Mock<IMysqlConnection>();
            _transactionRepository = new TransactionRepository();
        }

        [Fact]
        public async Task SaveAsync_ShouldReturnTrue_WhenTransactionsAreSaved()
        {
            // Arrange
            var transactionList = new List<TransactionModel>
            {
                new TransactionModel
                {
                    Type = TransactionTypeEnum.Debit,
                    Date = "20190301",
                    Amount = 100.00m,
                    Document = "09620676017",
                    Card = "123456",
                    Hour = "154315",
                    StoreOwner = "JOÃO MACEDO",
                    StoreName = "BAR DO JOÃO"
                },
                new TransactionModel
                {
                    Type = TransactionTypeEnum.Debit,
                    Date = "20190301",
                    Amount = 120.00m,
                    Document = "55641815063",
                    Card = "123456",
                    Hour = "164315",
                    StoreOwner = "MARIA JOSEFINA",
                    StoreName = "LOJA DO Ó - FILIAL"
                },
            };

            _mockConnection.Setup(c => c.OpenAsync());
            _mockConnection.Setup(c => c.ExecuteAsync()).ReturnsAsync(2);
            _mockConnection.Setup(c => c.CloseAsync());

            // Act
            var result = await _transactionRepository.SaveAsync(transactionList);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public async Task SaveAsync_Should_Return_False_When_Database_Operation_Fails()
        {
            // Arrange
            var transactionList = new List<TransactionModel>();

            _mockConnection.Setup(c => c.OpenAsync());
            _mockConnection.Setup(c => c.ExecuteAsync()).ReturnsAsync(0);
            _mockConnection.Setup(c => c.CloseAsync());

            // Act
            var result = await _transactionRepository.SaveAsync(transactionList);

            // Assert
            Assert.False(result);
        }
    }
}
