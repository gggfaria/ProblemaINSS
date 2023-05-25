using INSS.Models;
using INSS.Models.Enums;
using System.Collections.Generic;

namespace INSS.Services
{
    public class Inss2012 : BaseInss
    {
        public override List<FaixaImposto> GetFaixasImposto() => new List<FaixaImposto>
        {
            new FaixaImposto(7m, 0, 1000.00m, EFaixa.DINAMICA),
            new FaixaImposto(8m, 1000.01m, 1500m, EFaixa.DINAMICA),
            new FaixaImposto(9m, 1500.01m, 3000m, EFaixa.DINAMICA),
            new FaixaImposto(11m, 3000.01m, 4000m, EFaixa.DINAMICA),
            new FaixaImposto(500m,  4000.01m, decimal.MaxValue, EFaixa.ESTATICA)
        };

    }
}
