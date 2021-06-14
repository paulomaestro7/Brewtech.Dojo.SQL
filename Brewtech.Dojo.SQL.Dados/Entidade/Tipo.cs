using System;
using System.Collections.Generic;

#nullable disable

namespace Brewtech.Dojo.SQL.Dados
{
    public partial class Tipo
    {
        public Tipo()
        {
            ProdutoPrecoTipos = new HashSet<ProdutoPrecoTipo>();
            TipoVigencia = new HashSet<TipoVigencia>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public bool? Situacao { get; set; }

        public virtual ICollection<ProdutoPrecoTipo> ProdutoPrecoTipos { get; set; }
        public virtual ICollection<TipoVigencia> TipoVigencia { get; set; }
    }
}
