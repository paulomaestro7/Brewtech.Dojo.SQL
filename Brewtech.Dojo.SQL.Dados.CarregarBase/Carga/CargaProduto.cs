using System;
using System.Collections.Generic;

namespace Brewtech.Dojo.SQL.Dados.CarregarBase
{

    public static class CargaProduto
    {
        public static void CargaProdutos(this DojoSQLContext dojoSQLContext)
        {
            var lstProduto = new List<Produto>();
            for (int i = 0; i < 1000; i++)
            {
                Console.WriteLine($"Produto {i}");
                lstProduto.Add(new Produto
                {
                    Nome = $"Produto{i}",
                    Ean13 = i.ToString().PadLeft(13, '0'),
                });
            }
            
            dojoSQLContext.Produto.AddRange(lstProduto);
            dojoSQLContext.SaveChanges();
        }
    }
}
