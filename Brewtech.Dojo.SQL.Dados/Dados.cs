using Brewtech.Dojo.SQL.Dados.Dto;
using Brewtech.Dojo.SQL.Dados.Interface;
using System;
using System.Collections.Generic;

namespace Brewtech.Dojo.SQL.Dados
{
    public class Dados : IDados
    {
        //1 - Quantas pessoas tem cadastradas e quantas de cada tipo que já comprou algum produto
        public Resultado1 Resultado1()
        {
            return new Resultado1()
            {
                QuantidadePessoaCadastrada = 2,
                QuantidadePessoaFisica = 1,
                QuantidadePessoaJuridica = 1
            };
        }

        //2 - Qual a quantidade de pedidos por cliente
        public List<Resultado2> Resultado2()
        {
            return new List<Resultado2> {
                new Resultado2{
                    Nome = "Roberto Valerio",
                    QuantidadePedido = 10
                },
                new Resultado2{
                    Nome = "Amadeu Assad",
                    QuantidadePedido = 9
                }
            };
        }

        //3 - Entre 01/01/2021 até 01/05/2021 quantos pedidos para pessoa jurídica e física foram realizados
        public Resultado3 Resultado3()
        {
            return new Resultado3
            {
                QuantidadePessoaFisica = 156,
                QuantidadePessoaJuridica = 15
            };
        }

        //4 - Top 10 de pedidos pessoa jurídica e física
        public List<Resultado4> Resultado4()
        {
            return new List<Resultado4>
            {
                new Resultado4{
                    NomePessoa = "Roberto Valerio",
                    DataCompra = DateTime.Now,
                    ValorTotal = 1000.99M
                },
                new Resultado4{
                    NomePessoa = "Amadeu Assad",
                    DataCompra = DateTime.Now,
                    ValorTotal = 100.89M
                }
            };
        }

        //5 - Do produto mais vendido, qual maior valor e menor valor e nome de quem comprou
        public Resultado5 Resultado5()
        {
            return new Resultado5
            {
                NomeProduto = "Anador",
                MaiorValor = 15.55M,
                MenorValor = 1.22M
            };
        }

        //6 - Qual o produto menos vendido, qual maior valor e menor valor e nome de quem comprou
        public Resultado6 Resultado6()
        {
            return new Resultado6
            {
                NomeProduto = "Anador Gotas",
                MaiorValor = 1.55M,
                MenorValor = 1.22M
            };
        }

        //7 - Qual cliente comprou o produto mais caro de todos os tempos e qual o percentual aplicado em cima do preço mínimo
        public Resultado7 Resultado7()
        {
            return new Resultado7
            {
                NomePessoa = "Roberto Valerio",
                NomeProduto = "Anador Gotas",
                Valor = 55.55M,
                Percentual = 55
            };
        }

        //8 - Número de vendas realizados por cliente pessoa física e valor total que cada cliente gastou
        public List<Resultado8> Resultado8()
        {
            return new List<Resultado8>
            {
                new Resultado8{ 
                    NomePessoa = "Roberto Valerio",
                    QuantidadePedidos = 15,
                    ValorGasto = 15547.45M
                },
                new Resultado8{
                    NomePessoa = "Amadeu Assad",
                    QuantidadePedidos = 10,
                    ValorGasto = 1257.40M
                }
            };
        }

        //9 - Maior valor faturado em um dia
        public Resultado9 Resultado9()
        {
            return new Resultado9
            {
                Data = DateTime.Now,
                QuantidadePedidos = 544,
                ValorFaturado = 1548787.22M
            };
        }

        //10 - Valor total que a loja vendeu
        public Resultado10 Resultado10()
        {
            return new Resultado10
            {
                ValorTotal = 1554879787.99M
            };
        }
    }
}