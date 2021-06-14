using System;

namespace Brewtech.Dojo.SQL.Dados.CarregarBase
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Iniciando Carga");

            var contexto = new DojoSQLContext();
            using (var tran = contexto.Database.BeginTransaction())
            {
                try
                {
                    contexto.CargaPessoaFisica();
                    contexto.CargaPessoaJuridica();
                    contexto.CargaTipos();
                    contexto.CargaTipoVigencia();
                    contexto.CargaTipoVigenciaFeriado();
                    contexto.CargaTipoVigencias();
                    contexto.CargaProdutos();
                    contexto.CargaProdutoPrecos();
                    contexto.CargaProdutoPrecosTipos();
                    contexto.CargaPedidos();
                    tran.Commit();
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    throw;
                }
            }

            Console.WriteLine("Finalizado Carga");

        }
    }
}
