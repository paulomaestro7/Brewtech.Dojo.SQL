using System;
using System.Collections.Generic;
using System.Linq;

namespace Brewtech.Dojo.SQL.Dados.CarregarBase
{

    public static class CargaPedido
    {
        public static void CargaPedidos(this DojoSQLContext dojoSQLContext)
        {
            var produto = dojoSQLContext.Produto.Select(s => s.Id).ToList();
            var pessoa = dojoSQLContext.Pessoa.Select(s => s.Id).ToList();

            var lstPedido = new List<Pedido>();
            for (int i = 0; i < 10000; i++)
            {
                Console.WriteLine($"Adicionando Pedido {i}");
                var idProduto = produto.Where(w => w == CargaProdutoPrecoTipo.PegaProdutoRandomico()).FirstOrDefault();
                var idPessoa = pessoa.Where(w => w == PegaPessoa()).FirstOrDefault();
                var quantidade = PegaQuantidade();
                if (idProduto > 0 && idPessoa > 0)
                {
                    lstPedido.Add(new Pedido
                    {
                        PedidoProdutos = new List<PedidoProduto>
                        {
                            new PedidoProduto
                            {
                                IdProduto = idProduto,
                                Quantidade = quantidade,
                                Preco = quantidade * 1
                            }
                        },
                        Total = quantidade * 1,
                        IdPessoa = idPessoa,
                        Data = PegaData(),
                        Situacao = PegaSituacao()
                    });
                }
            }

            dojoSQLContext.Pedido.AddRange(lstPedido);
            dojoSQLContext.SaveChanges();
        }
        private static int PegaQuantidade()
        {
            return new Random().Next(1, 20);
        }
        private static int PegaPessoa()
        {
            return new Random().Next(1, 2000);
        }
        private static DateTime PegaData()
        {
            var dias = new Random().Next(1, 2000);
            return DateTime.Now.AddDays(-dias);
        }
        private static char PegaSituacao()
        {
            var situacao = new Random().Next(1, 4);
            switch (situacao)
            {
                case 1:
                    return 'A';
                case 2:
                    return 'F';
                case 3:
                    return 'R';
                case 4:
                    return 'P';
            }
            return 'A';
        }
    }
}
