using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Brewtech.Dojo.SQL.Dados.CarregarBase
{
    public static class CargaPessoa
    {
        public static void CargaPessoaFisica(this DojoSQLContext dojoSQLContext)
        {
            var lstPessoa = new List<PessoaFisica>();
            for (int i = 0; i < 1000; i++)
            {
                Console.WriteLine($"Pessoa Fisica {i}");
                lstPessoa.Add(new PessoaFisica
                {
                    Cpf = i.ToString().PadLeft(11, '0'),
                    IdPessoaNavigation = new Pessoa
                    {
                        Nome = $"PessoaFisica{i}"
                    }
                });
            }
            dojoSQLContext.PessoaFisica.AddRange(lstPessoa);
            dojoSQLContext.SaveChanges();
        }

        public static void CargaPessoaJuridica(this DojoSQLContext dojoSQLContext)
        {
            var lstPessoa = new List<PessoaJuridica>();
            for (int i = 0; i < 1000; i++)
            {
                Console.WriteLine($"Pessoa Juridica {i}");

                lstPessoa.Add(new PessoaJuridica
                {
                    Cnpj = i.ToString().PadLeft(14, '0'),
                    RazaoSocial = $"RazaoPessoaJuridica{i}",
                    IdPessoaNavigation = new Pessoa
                    {
                        Nome = $"PessoaJuridica{i}"
                    }
                });
            }
            dojoSQLContext.PessoaJuridica.AddRange(lstPessoa);
            dojoSQLContext.SaveChanges();
        }
    }
}
