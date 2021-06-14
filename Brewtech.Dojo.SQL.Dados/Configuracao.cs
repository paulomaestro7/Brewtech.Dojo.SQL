using Brewtech.Dojo.SQL.Dados.Interface;
using Microsoft.Extensions.DependencyInjection;

namespace Brewtech.Dojo.SQL.Dados
{
    public static class Configuracao
    {
        public static void Dados(this IServiceCollection services) 
        {
            services.AddSingleton<IDados, Dados>();
        }
    }
}
