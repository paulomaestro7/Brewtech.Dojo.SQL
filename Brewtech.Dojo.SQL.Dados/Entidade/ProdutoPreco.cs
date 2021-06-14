using System;
using System.Collections.Generic;

#nullable disable

namespace Brewtech.Dojo.SQL.Dados
{
    public partial class ProdutoPreco
    {
        public ProdutoPreco()
        {
            ProdutoPrecoTipos = new HashSet<ProdutoPrecoTipo>();
        }

        public int Id { get; set; }
        public int IdProduto { get; set; }
        public decimal Preco { get; set; }
        public DateTime? DataInicio { get; set; }
        public DateTime? DataFinal { get; set; }

        public virtual Produto IdProdutoNavigation { get; set; }
        public virtual ICollection<ProdutoPrecoTipo> ProdutoPrecoTipos { get; set; }
    }
}
