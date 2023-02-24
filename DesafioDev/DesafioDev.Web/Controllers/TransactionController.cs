using DesafioDev.Web.Interfaces.Services;
using DesafioDev.Web.Models.Dtos;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace DesafioDev.Web.Controllers
{
    [Route("[controller]")]
    public class TransactionController : ControllerBase
    {
        readonly ITransactionService _transactionService;

        public TransactionController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        [HttpGet]
        [SwaggerResponse(StatusCodes.Status200OK, "Dados lidos com sucesso.", typeof(TransactionDto))]
        [SwaggerResponse(StatusCodes.Status204NoContent, "Não há dados.")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Erro ao obter os dados.")]
        public async Task<IActionResult> Get()
        {
            var result = await _transactionService.GetTransactionsAsync();

            if (result != null && result.Transactions.Any())
                return Ok(result);

            return NoContent();
        }

        [HttpPost]
        [SwaggerResponse(StatusCodes.Status200OK, "O arquivo foi processado e salvo com sucesso.")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Erro ao processar o arquivo enviado.")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Erro na aplicação.")]
        public async Task<IActionResult> Post(IFormFile file)
        {
            var result = await _transactionService.SaveTransactionsAsync(file);

            if (result)
                return Ok("O arquivo foi processado e salvo com sucesso.");

            return BadRequest("Erro ao processar o arquivo enviado.");
        }
    }
}
