# Problema

Uma empresa precisa calcular o desconto do INSS sobre o salário dos seus empregados. 
O desconto do INSS segue uma tabela anual que contém alíquotas para determinadas faixas de salários. O valor do desconto é igual à porcentagem da alíquota sobre o salário. Entretanto, quando o empregado tiver um salário superior ao limite máximo da tabela, o desconto é um valor pré-estabelecido, chamado de teto.
Abaixo segue as tabelas de 2011 e 2012: 

## 2011 
| Salário-de-contribuição (R$) | Alíquota para fins de recolhimento ao INSS (%) |
| --- | --- |
| até R$ 1.106,90 | 8 |
| de R$  1.106,91 a R$ 1.844,83 | 9 |
| de R$ 1.844,84 até R$ 3.689,66 | 11 |
| Teto | 405.86 |


## 2012 
| Salário-de-contribuição (R$) | Alíquota para fins de recolhimento ao INSS (%) |
| --- | --- |
| até R$ 1000,00 | 7 |
| de R$  1.000,01 a R$ 1.500,00 | 8 |
|de R$ 3.000,01 até R$ 4.000,00 | 9 |
| de R$ 3.000,01 até R$ 4.000,00 | 11 |
| Teto | 500 |



# Solução 

## Projeto INSS 
Contém Classe FaixaImposto responsável por representar cada faixa a ser calculada.
Dentro da Services está uma factory (FactoryMethod) responsável por definir qual faixa será usada para calcular, segundo o ano salário definido na entrada. 
Para cada ano é criado uma classe INSS para representar a tabela do ano em questão, cada uma responsável por calcular a faixa seguindo a tabela definida para o ano.
A classe BaseInss contém os métodos que serão iguais para calcular a tabela em qualquer ano, assim evitando repetição de código nas Services.

## Projeto INSS.UnitTest
Contém a execução dos métodos e classes definidos no projeto INSS, usando dados simulados de salários para realizar os calculos de INSS.