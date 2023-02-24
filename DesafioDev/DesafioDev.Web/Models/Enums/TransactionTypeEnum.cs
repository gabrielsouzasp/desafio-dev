using System.ComponentModel;

namespace DesafioDev.Web.Models.Enums
{
    public enum TransactionTypeEnum
    {
        [Description("Débito")]
        Debit = 1,
        [Description("Boleto")]
        Slip = 2,
        [Description("Financiamento")]
        Financing = 3,
        [Description("Crédito")]
        Credit = 4,
        [Description("Recebimento Empréstimo")]
        LoanIn = 5,
        [Description("Vendas")]
        Sales = 6,
        [Description("Recebimento TED")]
        TedIn = 7,
        [Description("Recebimento DOC")]
        DocIn = 8,
        [Description("Aluguel")]
        Rent = 9
    }
}
