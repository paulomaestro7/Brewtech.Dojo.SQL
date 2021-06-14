using System;
using System.Collections.Generic;
using System.Linq;

namespace Brewtech.Dojo.SQL.Dados.CarregarBase
{

    public static class CargaProdutoPrecoTipo
    {
        public static void CargaProdutoPrecosTipos(this DojoSQLContext dojoSQLContext)
        {
            var produtoPreco = dojoSQLContext.ProdutoPreco.Select(s => s.Id).ToList();
            var tipos = dojoSQLContext.Tipo.Select(s => s.Id).ToList();

            var lstProdutoPrecoTipo = new List<ProdutoPrecoTipo>();

            tipos.ForEach(f =>
            {
                for (int i = 0; i < 500; i++)
                {
                    Console.WriteLine($"Produto Preco Tipo {i}");
                    var produto = produtoPreco.Where(w => w == PegaProdutoRandomico()).FirstOrDefault();
                    if (!lstProdutoPrecoTipo.Any(a => a.IdTipo == f && a.IdProdutoPreco == produto) && produto > 0)
                    {
                        lstProdutoPrecoTipo.Add(new ProdutoPrecoTipo
                        {
                            IdTipo = f,
                            IdProdutoPreco = produto,
                            Percentual = PegaPercentual()
                        });
                    }
                }
            });
                        
            dojoSQLContext.ProdutoPrecoTipo.AddRange(lstProdutoPrecoTipo);
            dojoSQLContext.SaveChanges();
        }
        public static int PegaProdutoRandomico()
        {
            return new Random().Next(1, 1000);
        }
        private static int PegaPercentual()
        {
            return new Random().Next(100);
        }
    }
}
