using System;
using System.Collections.Generic;

#nullable disable

namespace Brewtech.Dojo.SQL.Dados
{
    public partial class Pedido
    {
        public Pedido()
        {
            PedidoProdutos = new HashSet<PedidoProduto>();
        }

        public int Id { get; set; }
        public int IdPessoa { get; set; }
        public char Situacao { get; set; }
        public DateTime? Data { get; set; }
        public decimal Total { get; set; }

        public virtual Pessoa IdPessoaNavigation { get; set; }
        public virtual ICollection<PedidoProduto> PedidoProdutos { get; set; }
    }
}
