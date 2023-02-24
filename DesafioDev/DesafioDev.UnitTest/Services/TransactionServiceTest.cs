using DesafioDev.Web.Interfaces.Repositories;
using DesafioDev.Web.Models;
using DesafioDev.Web.Models.Enums;
using DesafioDev.Web.Services;
using Microsoft.AspNetCore.Http;
using Moq;
using System.Text;

namespace DesafioDev.UnitTest.Services
{
    public class TransactionServiceTest
    {
        private Mock<ITransactionRepository> _transactionRepositoryMock;
        private TransactionService _transactionService;

        public TransactionServiceTest()
        {
            _transactionRepositoryMock = new Mock<ITransactionRepository>();
            _transactionService = new TransactionService(_transactionRepositoryMock.Object);
        }

        [Fact]
        public async Task GetTransactionsAsync_Should_Return_TransactionDto_With_Correct_TotalAmount()
        {
            // Arrange
            var transactions = new List<TransactionModel>
            {
                new TransactionModel { Type = TransactionTypeEnum.Debit, Amount = 100 },
                new TransactionModel { Type = TransactionTypeEnum.Slip, Amount = 50 }
            };
            _transactionRepositoryMock.Setup(x => x.GetAllAsync()).ReturnsAsync(transactions);

            // Act
            var result = await _transactionService.GetTransactionsAsync();

            // Assert
            Assert.Equal(50, result.TotalAmount);
        }

        [Fact]
        public async Task SaveTransactionsAsync_Should_Return_False_If_File_Is_Null()
        {
            // Act
            var result = await _transactionService.SaveTransactionsAsync(null);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public async Task SaveTransactionsAsync_Should_Return_False_If_File_Has_Wrong_Extension()
        {
            // Arrange
            var fileMock = new Mock<IFormFile>();
            fileMock.Setup(x => x.FileName).Returns("file.png");

            // Act
            var result = await _transactionService.SaveTransactionsAsync(fileMock.Object);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public async Task SaveTransactionsAsync_Should_Return_False_If_File_Has_No_Transactions()
        {
            // Arrange
            var fileMock = new Mock<IFormFile>();
            fileMock.Setup(x => x.FileName).Returns("file.txt");
            fileMock.Setup(x => x.OpenReadStream()).Returns(new MemoryStream(Encoding.UTF8.GetBytes("")));

            // Act
            var result = await _transactionService.SaveTransactionsAsync(fileMock.Object);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public async Task SaveTransactionsAsync_Should_Call_SaveAsync_With_TransactionList()
        {
            // Arrange
            var bytes = Encoding.UTF8.GetBytes("2201903010000010700845152540738723****9987123333MARCOS PEREIRAMERCADO DA AVENIDA");
            IFormFile file = new FormFile(new MemoryStream(bytes), 0, bytes.Length, "Data", "dummy.txt");
            
            // Act
            var result = await _transactionService.SaveTransactionsAsync(file);

            // Assert
            _transactionRepositoryMock.Verify(x => x.SaveAsync(It.IsAny<List<TransactionModel>>()), Times.Once);
        }
    }
}
