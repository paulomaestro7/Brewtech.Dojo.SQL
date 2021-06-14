using Brewtech.Dojo.SQL.Dados;
using Brewtech.Dojo.SQL.Dados.Interface;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Brewtech.Dojo.SQL
{
    class Program
    {
        private static IServiceProvider _serviceProvider;
        static void Main(string[] args)
        {
            Iniciar();

            var dados = _serviceProvider.GetService<IDados>();

            Resultado1(dados);

            Resultado2(dados);

            Resultado3(dados);

            Resultado4(dados);

            Resultado5(dados);

            Resultado6(dados);

            Resultado7(dados);

            Resultado8(dados);

            Resultado9(dados);

            Resultado10(dados);

            Console.WriteLine("Isso ai man!");
        }

        private static void Resultado1(IDados dados)
        {
            var resultado1 = dados.Resultado1();
            Console.WriteLine("1 - Quantas pessoas tem cadastradas e quantas de cada tipo que já comprou algum produto");
            Console.WriteLine($"Quantidade de pessoas cadastratas {resultado1.QuantidadePessoaCadastrada}");
            Console.WriteLine($"Quantidade de pessoa física {resultado1.QuantidadePessoaFisica}");
            Console.WriteLine($"Quantidade de pessoa jurídica {resultado1.QuantidadePessoaJuridica}");
            PuloDoGato();
        }

        private static void Resultado2(IDados dados)
        {
            var resultado2 = dados.Resultado2();
            Console.WriteLine("2 - Qual a quantidade de pedidos por cliente");
            resultado2.ForEach(f => { 
                Console.WriteLine($"Nome da pessoa {f.Nome}");
                Console.WriteLine($"Quantidade de pedidos {f.QuantidadePedido}");
            });
            PuloDoGato();
        }

        private static void Resultado3(IDados dados)
        {
            var resultado3 = dados.Resultado3();
            Console.WriteLine("3 - Entre 01/01/2021 até 01/05/2021 quantos pedidos para pessoa jurídica e física foram realizados");
            Console.WriteLine($"Quantidade de pessoa física {resultado3.QuantidadePessoaFisica}");
            Console.WriteLine($"Quantidade de pessoa jurídica {resultado3.QuantidadePessoaJuridica}");
            PuloDoGato();
        }

        private static void Resultado4(IDados dados)
        {
            var resultado4 = dados.Resultado4();
            Console.WriteLine("4 - Top 10 de pedidos pessoa jurídica e física");
            resultado4.ForEach(f => {
                Console.WriteLine($"Nome pessoa {f.NomePessoa}");
                Console.WriteLine($"Data da compra {f.DataCompra}");
                Console.WriteLine($"Valor total da compra {f.ValorTotal}");
            });
            
            PuloDoGato();
        }

        private static void Resultado5(IDados dados)
        {
            var resultado5 = dados.Resultado5();
            Console.WriteLine("5 - Do produto mais vendido, qual maior valor e menor valor e nome de quem comprou");
            Console.WriteLine($"Nome do produto {resultado5.NomeProduto}");
            Console.WriteLine($"Maior valor {resultado5.MaiorValor}");
            Console.WriteLine($"Menor valor {resultado5.MenorValor}");
            PuloDoGato();
        }

        private static void Resultado6(IDados dados)
        {
            var resultado6 = dados.Resultado6();
            Console.WriteLine("6 - Qual o produto menos vendido, qual maior valor e menor valor e nome de quem comprou");
            Console.WriteLine($"Nome do produto {resultado6.NomeProduto}");
            Console.WriteLine($"Maior valor {resultado6.MaiorValor}");
            Console.WriteLine($"Menor valor {resultado6.MenorValor}");
            PuloDoGato();
        }

        private static void Resultado7(IDados dados)
        {
            var resultado7 = dados.Resultado7();
            Console.WriteLine("7 - Qual cliente comprou o produto mais caro de todos os tempos e qual o percentual aplicado em cima do preço mínimo");
            Console.WriteLine($"Nome da pessoa {resultado7.NomePessoa}");
            Console.WriteLine($"Nome do produto {resultado7.NomeProduto}");
            Console.WriteLine($"Valor do produto {resultado7.Valor}");
            Console.WriteLine($"Percentual do produto {resultado7.Percentual}");
            PuloDoGato();
        }

        private static void Resultado8(IDados dados)
        {
            var resultado8 = dados.Resultado8();
            Console.WriteLine("8 - Número de vendas realizados por cliente pessoa física e valor total que cada cliente gastou");
            resultado8.ForEach(f => {
                Console.WriteLine($"Nome da pessoa {f.NomePessoa}");
                Console.WriteLine($"Quantidade de pedidos {f.QuantidadePedidos}");
                Console.WriteLine($"Valor gasto {f.ValorGasto}");
            });

            PuloDoGato();
        }

        private static void Resultado9(IDados dados)
        {
            var resultado9 = dados.Resultado9();
            Console.WriteLine("9 - Maior valor faturado em um dia");
            Console.WriteLine($"Data de maior faturamento {resultado9.Data}");
            Console.WriteLine($"Quantidade de pedidos no dia {resultado9.QuantidadePedidos}");
            Console.WriteLine($"Valor faturado no dia {resultado9.ValorFaturado}");

            PuloDoGato();
        }

        private static void Resultado10(IDados dados)
        {
            var resultado10 = dados.Resultado10();
            Console.WriteLine("10 - Valor total que a loja vendeu");
            Console.WriteLine($"Valor total que a loja vendeu {resultado10.ValorTotal}");

            PuloDoGato();
        }


        private static void PuloDoGato()
        {
            Console.WriteLine("");
            Console.WriteLine("");
        }

        private static void Iniciar()
        {
            var services = new ServiceCollection();
            services.Dados();
            _serviceProvider = services.BuildServiceProvider();
        }
    }
}
