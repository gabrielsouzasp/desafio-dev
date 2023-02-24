using DesafioDev.Web.Controllers;
using DesafioDev.Web.Interfaces.Services;
using DesafioDev.Web.Models;
using DesafioDev.Web.Models.Dtos;
using DesafioDev.Web.Models.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace DesafioDev.UnitTest.Controllers
{
    public class TransactionControllerTest
    {
        private readonly Mock<ITransactionService> _mockTransactionService;
        private readonly TransactionController _controller;

        public TransactionControllerTest()
        {
            _mockTransactionService = new Mock<ITransactionService>();
            _controller = new TransactionController(_mockTransactionService.Object);
        }

        [Fact]
        public async Task Get_Should_Return_Ok_When_Transactions_Exist()
        {
            // Arrange
            var mockResult = new TransactionDto
            {
                Transactions = new List<TransactionModel>
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
                    }
                }
            };

            _mockTransactionService.Setup(s => s.GetTransactionsAsync()).ReturnsAsync(mockResult);

            // Act
            var result = await _controller.Get();

            // Assert
            Assert.IsType<OkObjectResult>(result);
            var okResult = result as OkObjectResult;
            Assert.Equal(mockResult, okResult.Value);
        }

        [Fact]
        public async Task Get_Should_Return_NoContent_When_Transactions_Do_Not_Exist()
        {
            // Arrange
            var mockResult = new TransactionDto { Transactions = new List<TransactionModel>() };

            _mockTransactionService.Setup(s => s.GetTransactionsAsync()).ReturnsAsync(mockResult);

            // Act
            var result = await _controller.Get();

            // Assert
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async Task Post_Should_Return_Ok_When_File_Is_Successfully_Processed()
        {
            // Arrange
            var mockFile = new Mock<IFormFile>();
            _mockTransactionService.Setup(s => s.SaveTransactionsAsync(mockFile.Object)).ReturnsAsync(true);

            // Act
            var result = await _controller.Post(mockFile.Object);

            // Assert
            Assert.IsType<OkObjectResult>(result);
            var okResult = result as OkObjectResult;
            Assert.Equal("O arquivo foi processado e salvo com sucesso.", okResult.Value);
        }

        [Fact]
        public async Task Post_Should_Return_BadRequest_When_File_Processing_Fails()
        {
            // Arrange
            var mockFile = new Mock<IFormFile>();
            _mockTransactionService.Setup(s => s.SaveTransactionsAsync(mockFile.Object)).ReturnsAsync(false);

            // Act
            var result = await _controller.Post(mockFile.Object);

            // Assert
            Assert.IsType<BadRequestObjectResult>(result);
            var badRequestResult = result as BadRequestObjectResult;
            Assert.Equal("Erro ao processar o arquivo enviado.", badRequestResult.Value);
        }
    }
}
