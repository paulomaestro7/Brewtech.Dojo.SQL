using System;
using System.Collections.Generic;

#nullable disable

namespace Brewtech.Dojo.SQL.Dados
{
    public partial class Produto
    {
        public Produto()
        {
            PedidoProdutos = new HashSet<PedidoProduto>();
            ProdutoPrecos = new HashSet<ProdutoPreco>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Ean13 { get; set; }
        public bool? Situacao { get; set; }

        public virtual ICollection<PedidoProduto> PedidoProdutos { get; set; }
        public virtual ICollection<ProdutoPreco> ProdutoPrecos { get; set; }
    }
}
