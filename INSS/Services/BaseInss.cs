using INSS.Models;
using INSS.Models.Enums;
using INSS.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace INSS.Services
{
    public abstract class BaseInss: IInss
    {
        public abstract List<FaixaImposto> GetFaixasImposto();

        public decimal Calcula(decimal salario)
        {
            if (salario < 0)
                throw new ArgumentException("Salário não pode ser negativo");

            var impostos = GetFaixasImposto().Single(faixaImposto => Between(salario, faixaImposto));
            switch (impostos.Operacao)
            {
                case EFaixa.ESTATICA:
                    return salario - impostos.Valor;
                case EFaixa.DINAMICA:
                    return salario - (salario * (impostos.Valor / 100)); ;
                default:
                    throw new Exception("Faixa salarial fora do permitido");
            }

        }

        private static bool Between(decimal salario, FaixaImposto faixaImposto)
        {
            return salario >= faixaImposto.ValorInicial && salario <= faixaImposto.ValorFinal;
        }
    }
}
