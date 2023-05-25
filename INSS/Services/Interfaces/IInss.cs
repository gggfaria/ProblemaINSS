using INSS.Models;
using System.Collections.Generic;

namespace INSS.Services.Interfaces
{
    public interface IInss
    {
        decimal Calcula(decimal salario);
        List<FaixaImposto> GetFaixasImposto();

    }
}
