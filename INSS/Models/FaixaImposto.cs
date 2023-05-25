using INSS.Models.Enums;

namespace INSS.Models
{
    public class FaixaImposto
    {
        public FaixaImposto(decimal valor, decimal valorInicial, decimal valorFinal, EFaixa operacao)
        {
            Valor = valor;
            ValorInicial = valorInicial;
            ValorFinal = valorFinal;
            Operacao = operacao;
        }

        public decimal Valor { get; private set; }
        public decimal ValorInicial { get; private set; }
        public decimal ValorFinal { get; private set; }
        public EFaixa Operacao { get; private set; }
    }
}
