using Swashbuckle.AspNetCore.Annotations;

namespace DesafioDev.Web.Models.Dtos
{
    public class TransactionDto
    {
        [SwaggerSchema("Transações")]
        public List<TransactionModel> Transactions { get; set; }

        [SwaggerSchema("Totalizador de saldo")]
        public decimal TotalAmount { get; set; }
    }
}
