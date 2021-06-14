using System;
using System.Collections.Generic;

#nullable disable

namespace Brewtech.Dojo.SQL.Dados
{
    public partial class PessoaJuridica
    {
        public int Id { get; set; }
        public string RazaoSocial { get; set; }
        public string Cnpj { get; set; }
        public int IdPessoa { get; set; }

        public virtual Pessoa IdPessoaNavigation { get; set; }
    }
}
