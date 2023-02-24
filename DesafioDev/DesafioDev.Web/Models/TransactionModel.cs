using DesafioDev.Web.Models.Enums;
using Swashbuckle.AspNetCore.Annotations;

namespace DesafioDev.Web.Models
{
    public class TransactionModel
    {
        [SwaggerSchema("Tipo da transação")]
        public TransactionTypeEnum Type { get; set; }
        [SwaggerSchema("Data da ocorrência")]
        public string Date { get; set; }
        [SwaggerSchema("Valor da movimentação")]
        public decimal Amount { get; set; }
        [SwaggerSchema("CPF do beneficiário")]
        public string Document { get; set; }
        [SwaggerSchema("Cartão utilizado na transação")]
        public string Card { get; set; }
        [SwaggerSchema("Hora da ocorrência atendendo ao fuso de UTC-3")]
        public string Hour { get; set; }
        [SwaggerSchema("Nome do representante da loja")]
        public string StoreOwner { get; set; }
        [SwaggerSchema("Nome da loja")]
        public string StoreName { get; set; }
    }
}
