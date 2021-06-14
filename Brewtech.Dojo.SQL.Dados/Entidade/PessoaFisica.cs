using System;
using System.Collections.Generic;

#nullable disable

namespace Brewtech.Dojo.SQL.Dados
{
    public partial class PessoaFisica
    {
        public int Id { get; set; }
        public string Cpf { get; set; }
        public int IdPessoa { get; set; }

        public virtual Pessoa IdPessoaNavigation { get; set; }
    }
}
