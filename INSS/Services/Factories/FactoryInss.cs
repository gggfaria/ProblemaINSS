using INSS.Services.Interfaces;
using System;

namespace INSS.Services.Factories
{
    public class FactoryInss : IFactoryInss
    {
        public IInss MakeInss(int ano)
        {
            switch (ano)
            {
                case 2011:
                    return new Inss2011();
                case 2012:
                    return new Inss2012();
                default: throw new ArgumentException("Ano inválido na tabela de INSS");
            }
        }

    }
}
