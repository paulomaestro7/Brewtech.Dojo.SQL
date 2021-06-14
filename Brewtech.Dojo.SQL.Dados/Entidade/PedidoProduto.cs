using System;
using System.Collections.Generic;

#nullable disable

namespace Brewtech.Dojo.SQL.Dados
{
    public partial class PedidoProduto
    {
        public int Id { get; set; }
        public int IdPedido { get; set; }
        public int IdProduto { get; set; }
        public int Quantidade { get; set; }
        public decimal Preco { get; set; }

        public virtual Pedido IdPedidoNavigation { get; set; }
        public virtual Produto IdProdutoNavigation { get; set; }
    }
}
