using INSS.Models;
using INSS.Models.Enums;
using INSS.Services;
using System.Collections.Generic;

namespace INSS.UnitTest.ServiceTest
{
    internal class InssFaixaInvalida : BaseInss
    {
        public override List<FaixaImposto> GetFaixasImposto() => new List<FaixaImposto>
        {
            new FaixaImposto(8m, 0, 1106.9m, EFaixa.DINAMICA),
            new FaixaImposto(8m, 0, 1106.9m, EFaixa.DINAMICA),
            new FaixaImposto(9m, 1106.91m, 1844.83m, EFaixa.DINAMICA),
            new FaixaImposto(9m, 1106.91m, 1844.83m, EFaixa.DINAMICA),
            new FaixaImposto(11m, 1844.84m, 3689.66m, EFaixa.DINAMICA),
            new FaixaImposto(405.86m,  3689.67m, decimal.MaxValue, EFaixa.ESTATICA)
        };
    }
}
