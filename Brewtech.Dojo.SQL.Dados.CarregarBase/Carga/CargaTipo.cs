using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using NpgsqlTypes;

namespace Brewtech.Dojo.SQL.Dados.CarregarBase
{

    public static class CargaTipo
    {
        public static void CargaTipos(this DojoSQLContext dojoSQLContext)
        {
            var lstTipo = new List<Tipo>();
            lstTipo.Add(new Tipo
            {
                Id = 1,
                Nome = "Hora semana"
            });
            lstTipo.Add(new Tipo
            {
                Id = 2,
                Nome = "Feriado"
            });
            lstTipo.Add(new Tipo
            {
                Id = 3,
                Nome = "Por data"
            });

            dojoSQLContext.Tipo.AddRange(lstTipo);
            dojoSQLContext.SaveChanges();
        }
        public static void CargaTipoVigencia(this DojoSQLContext dojoSQLContext)
        {
            var lstVigencia = new List<TipoVigencia>();
            for (int i = 0; i < 24; i++)
            {
                Console.WriteLine($"Tipo Vigencia {i}");
                lstVigencia.Add(new TipoVigencia
                {
                    IdTipo = 1,
                    Inicio = DateTime.MinValue.AddHours(i),
                    Fim = i == 23 ? DateTime.MinValue.AddHours(i + 1).AddSeconds(-1) : DateTime.MinValue.AddHours(i + 1)
                });

            }
            dojoSQLContext.TipoVigencia.AddRange(lstVigencia);
            dojoSQLContext.SaveChanges();
        }
        public static void CargaTipoVigenciaFeriado(this DojoSQLContext dojoSQLContext)
        {
            var lstVigencia = new List<TipoVigencia>();

            lstVigencia.Add(new TipoVigencia
            {
                IdTipo = 2,
                Inicio = Convert.ToDateTime("12/06/2021"),
                Fim = Convert.ToDateTime("12/06/2021")
            });
            lstVigencia.Add(new TipoVigencia
            {
                IdTipo = 2,
                Inicio = Convert.ToDateTime("12/08/2020"),
                Fim = Convert.ToDateTime("12/08/2020")
            });

            dojoSQLContext.TipoVigencia.AddRange(lstVigencia);
            dojoSQLContext.SaveChanges();
        }
        public static void CargaTipoVigencias(this DojoSQLContext dojoSQLContext)
        {
            var lstVigencia = new List<TipoVigencia>();

            lstVigencia.Add(new TipoVigencia
            {
                IdTipo = 3,
                Inicio = Convert.ToDateTime("01/05/2021"),
                Fim = Convert.ToDateTime("01/06/2021")
            });
            lstVigencia.Add(new TipoVigencia
            {
                IdTipo = 3,
                Inicio = Convert.ToDateTime("01/12/2020"),
                Fim = Convert.ToDateTime("12/01/2021")
            });

            dojoSQLContext.TipoVigencia.AddRange(lstVigencia);
            dojoSQLContext.SaveChanges();
        }
        
    }
}
