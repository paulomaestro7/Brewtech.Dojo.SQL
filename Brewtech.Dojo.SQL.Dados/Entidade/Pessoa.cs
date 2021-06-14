using System;
using System.Collections.Generic;

#nullable disable

namespace Brewtech.Dojo.SQL.Dados
{
    public partial class Pessoa
    {
        public Pessoa()
        {
            Pedidos = new HashSet<Pedido>();
            PessoaFisicas = new HashSet<PessoaFisica>();
            PessoaJuridicas = new HashSet<PessoaJuridica>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public bool? Situacao { get; set; }

        public virtual ICollection<Pedido> Pedidos { get; set; }
        public virtual ICollection<PessoaFisica> PessoaFisicas { get; set; }
        public virtual ICollection<PessoaJuridica> PessoaJuridicas { get; set; }
    }
}
