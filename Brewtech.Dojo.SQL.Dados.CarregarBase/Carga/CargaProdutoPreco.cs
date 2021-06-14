using System;
using System.Collections.Generic;
using System.Linq;

namespace Brewtech.Dojo.SQL.Dados.CarregarBase
{

    public static class CargaProdutoPreco
    {
        public static void CargaProdutoPrecos(this DojoSQLContext dojoSQLContext)
        {
            var produtos = dojoSQLContext.Produto.Select(s => s.Id).ToList();

            var lstProdutoPreco = new List<ProdutoPreco>();
            int i = 0;
            produtos.ForEach(f =>
            {
                Console.WriteLine($"Produto Preco {i}");
                lstProdutoPreco.Add(new ProdutoPreco
                {
                    IdProduto = f,
                    Preco = GeraPreco(),
                    DataInicio = Convert.ToDateTime("01/01/2020"),
                    DataFinal = Convert.ToDateTime("31/12/2020")
                });
                lstProdutoPreco.Add(new ProdutoPreco
                {
                    IdProduto = f,
                    Preco = GeraPreco(),
                    DataInicio = Convert.ToDateTime("01/01/2021"),
                    DataFinal = Convert.ToDateTime("31/12/2021")
                });
                lstProdutoPreco.Add(new ProdutoPreco
                {
                    IdProduto = f,
                    Preco = GeraPreco(),
                    DataInicio = Convert.ToDateTime("01/01/2022"),
                    DataFinal = Convert.ToDateTime("31/12/2022")
                });
                i++;
            });


            dojoSQLContext.ProdutoPreco.AddRange(lstProdutoPreco);
            dojoSQLContext.SaveChanges();
        }
        private static decimal GeraPreco()
        {
            var valor = new Random().Next(10, 1000);
            var valorDec = new Random().Next(0, 99);
            return decimal.Parse($"{valor},{valorDec}");
        }
    }
}
