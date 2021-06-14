using System;
using System.Collections.Generic;

#nullable disable

namespace Brewtech.Dojo.SQL.Dados
{
    public partial class ProdutoPrecoTipo
    {
        public int IdTipo { get; set; }
        public int IdProdutoPreco { get; set; }
        public decimal Percentual { get; set; }

        public virtual ProdutoPreco IdProdutoPrecoNavigation { get; set; }
        public virtual Tipo IdTipoNavigation { get; set; }
    }
}
