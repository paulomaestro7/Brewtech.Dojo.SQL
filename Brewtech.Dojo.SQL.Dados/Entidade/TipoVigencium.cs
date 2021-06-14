using System;
using System.Collections.Generic;

#nullable disable

namespace Brewtech.Dojo.SQL.Dados
{
    public partial class TipoVigencia
    {
        public int Id { get; set; }
        public int IdTipo { get; set; }
        public DateTime Inicio { get; set; }
        public DateTime Fim { get; set; }
        public bool? Situacao { get; set; }

        public virtual Tipo IdTipoNavigation { get; set; }
    }
}
