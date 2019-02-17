using ControleBO.Infra.Data.Context;
using Microsoft.Extensions.DependencyInjection;

namespace ControleBO.Infra.CrossCutting.IoC
{
    public class BootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddEntityFrameworkNpgsql()
                .AddDbContext<SpcContext>();
        }
    }
}
