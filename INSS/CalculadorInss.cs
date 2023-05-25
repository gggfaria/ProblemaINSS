using INSS.Services.Factories;
using INSS.Services.Interfaces;
using System;

namespace INSS
{
    public class CalculadorInss : ICalculadorInss
    {
        public decimal CalcularDesconto(DateTime data, decimal salario)
        {
         
            IFactoryInss factoryInss = new FactoryInss();
            int ano = data.Year;
            IInss inss = factoryInss.MakeInss(ano);
            return inss.Calcula(salario);
        }
    }
}
