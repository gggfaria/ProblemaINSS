using INSS.UnitTest.ServiceTest;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace INSS.UnitTest
{
    [TestClass]
    public class CalculadorInssTest
    {
        [TestClass]
        public class CalculadoraTest
        {
            [TestMethod]
            [DataRow("2011-01-01", 1106.9, 1018.35)]
            [DataRow("2011-01-01", 1000, 920)]
            [DataRow("2011-12-31", 1, 0.92)]
            [DataRow("2011-11-30", 2.27, 2.09)]
            [DataRow("2011-05-21", 3, 2.76)]
            public void CalcularInss_Ano2011_ReturnPrimeiraFaixaCorreto(string dataStr, double salario, double descontoCorreto)
            {
                AssertCalculadoraResultadoCorreto(dataStr, salario, descontoCorreto);
            }

            

            [TestMethod]
            [DataRow("2011-01-01", 1106.91, 1007.29)]
            [DataRow("2011-01-31", 1200, 1092)]
            [DataRow("2011-01-31", 1844.83, 1678.80)]
            public void CalcularInss_Ano2011_ReturnSegundaFaixaCorreto(string dataStr, double salario, double descontoCorreto)
            {
                AssertCalculadoraResultadoCorreto(dataStr, salario, descontoCorreto);
            }

            [TestMethod]
            [DataRow("2011-01-31", 1844.84, 1641.91)]
            [DataRow("2011-01-31", 1900, 1691)]
            [DataRow("2011-01-01", 3689.66, 3283.80)]
            public void CalcularInss_Ano2011_ReturnTerceiraFaixaCorreto(string dataStr, double salario, double descontoCorreto)
            {
                AssertCalculadoraResultadoCorreto(dataStr, salario, descontoCorreto);
            }


            [TestMethod]
            [DataRow("2011-01-31", 3689.66, 3283.8)]
            [DataRow("2011-01-31", 999999, 999999 - 405.86)]
            public void CalcularInss_Ano2011_ReturnTetoCorreto(string dataStr, double salario, double descontoCorreto)
            {
                AssertCalculadoraResultadoCorreto(dataStr, salario, descontoCorreto);
            }


            [TestMethod]
            [DataRow("2012-01-31", 1000, 930)]
            [DataRow("2012-05-02", 90, 83.7)]
            [DataRow("2012-01-31", 1, 0.93)]
            [DataRow("2012-01-31", 999, 929.07)]
            public void CalcularInss_Ano2012_ReturnPrimeraFaixaCorreto(string dataStr, double salario, double descontoCorreto)
            {
                AssertCalculadoraResultadoCorreto(dataStr, salario, descontoCorreto);
            }

            [TestMethod]
            [DataRow("2012-01-31", 1000.01, 920.01)]
            [DataRow("2012-05-02", 1200, 1104)]
            [DataRow("2012-01-31", 1500, 1380)]
            public void CalcularInss_Ano2012_ReturnSegundaFaixaCorreto(string dataStr, double salario, double descontoCorreto)
            {
                AssertCalculadoraResultadoCorreto(dataStr, salario, descontoCorreto);
            }

            [TestMethod]
            [DataRow("2012-01-31", 1500.01, 1365.01)]
            [DataRow("2012-05-02", 1660, 1510.6)]
            [DataRow("2012-01-31", 3000, 2730)]
            public void CalcularInss_Ano2012_ReturnTerceiraFaixaCorreto(string dataStr, double salario, double descontoCorreto)
            {
                AssertCalculadoraResultadoCorreto(dataStr, salario, descontoCorreto);
            }

            [TestMethod]
            [DataRow("2012-01-31", 3000.01, 2670.01)]
            [DataRow("2012-01-31", 4000, 3560)]
            [DataRow("2012-05-02", 3561.53, 3169.76)]
            public void CalcularInss_Ano2012_ReturnQuartaFaixaCorreto(string dataStr, double salario, double descontoCorreto)
            {
                AssertCalculadoraResultadoCorreto(dataStr, salario, descontoCorreto);
            }

            [TestMethod]
            [DataRow("2012-01-31", 35500.01, 35000.01)]
            [DataRow("2012-01-31", 4000.01, 3500.01)]
            [DataRow("2012-05-02", 99999999, 99999499)]
            public void CalcularInss_Ano2012_ReturnTetoCorreto(string dataStr, double salario, double descontoCorreto)
            {
                AssertCalculadoraResultadoCorreto(dataStr, salario, descontoCorreto);
            }

            [TestMethod]
            public void CalcularInss_FaixaInvalida_RetornarInvalidOperationException()
            {
                var calculadorInssFaixaInvalida = new InssFaixaInvalida();

                Assert.ThrowsException<InvalidOperationException>(() => calculadorInssFaixaInvalida.Calcula(1000));
            }

            [TestMethod]
            [DataRow("1999-01-31")]
            [DataRow("1973-09-02")]
            [DataRow("2100-01-01")]
            public void CalcularInss_DataInvalida_RetornarArgumentException(string dataStr)
            {
                DateTime data = Convert.ToDateTime(dataStr);
                ICalculadorInss calculadorInss = new CalculadorInss();

                Assert.ThrowsException<ArgumentException>(() => calculadorInss.CalcularDesconto(data, 0));
            }

            [TestMethod]
            [DataRow("2011-01-31", -1)]
            [DataRow("2012-01-31", -9999)]
            public void CalcularInss_SalarioNegativo_Return(string dataStr, double salario)
            {
                DateTime data = Convert.ToDateTime(dataStr);
                ICalculadorInss calculadorInss = new CalculadorInss();

                Assert.ThrowsException<ArgumentException>(() => calculadorInss.CalcularDesconto(data, Convert.ToDecimal(salario)));

            }

            private void AssertCalculadoraResultadoCorreto(string dataStr, double salario, double descontoCorreto)
            {
                DateTime data = Convert.ToDateTime(dataStr);
                ICalculadorInss calculadorInss = new CalculadorInss();

                var salarioComDesconto = calculadorInss.CalcularDesconto(data, Convert.ToDecimal(salario));
                var salarioComDescontoArredondado = decimal.Round(salarioComDesconto, 2, MidpointRounding.AwayFromZero);

                Assert.AreEqual(Convert.ToDecimal(descontoCorreto), salarioComDescontoArredondado);
            }

        }
    }
}
