using ControleBO.Application.Interfaces;
using ControleBO.Application.Services;
using ControleBO.Domain.CommandHandler;
using ControleBO.Domain.Commands;
using ControleBO.Domain.Core.Bus;
using ControleBO.Domain.Core.Notifications;
using ControleBO.Domain.Interfaces;
using ControleBO.Domain.Interfaces.Repositories;
using ControleBO.Infra.CrossCutting.Bus;
using ControleBO.Infra.Data.Context;
using ControleBO.Infra.Data.Repositories;
using ControleBO.Infra.Data.UoW;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace ControleBO.Infra.CrossCutting.IoC
{
    public class BootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // Infra - Data
            services.AddEntityFrameworkNpgsql()
                .AddDbContext<SpcContext>();

            //services.AddScoped<SpcContext>();
            //services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IAssuntoRepository, AssuntoRepository>();
            services.AddScoped<IMunicipioRepository, MunicipioRepository>();
            services.AddScoped<IProcedimentoRepository, ProcedimentoRepository>();
            services.AddScoped<IProcedimentoTipoRepository, ProcedimentoTipoRepository>();
            services.AddScoped<IVaraCriminalRepository, VaraCriminalRepository>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            // Domain - Events
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();

            // Domain Bus
            services.AddScoped<IMediatorHandler, InMemoryBus>();

            // Domain - Commands
            services.AddScoped<IRequestHandler<RegisterNewAssuntoCommand, int>, AssuntoCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateAssuntoCommand, int>, AssuntoCommandHandler>();
            services.AddScoped<IRequestHandler<RemoveAssuntoCommand, int>, AssuntoCommandHandler>();

            services.AddScoped<IRequestHandler<RegisterNewMunicipioCommand, int>, MunicipioCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateMunicipioCommand, int>, MunicipioCommandHandler>();
            services.AddScoped<IRequestHandler<RemoveMunicipioCommand, int>, MunicipioCommandHandler>();

            services.AddScoped<IRequestHandler<RegisterNewProcedimentoCommand, int>, ProcedimentoCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateProcedimentoCommand, int>, ProcedimentoCommandHandler>();
            services.AddScoped<IRequestHandler<RemoveProcedimentoCommand, int>, ProcedimentoCommandHandler>();

            services.AddScoped<IRequestHandler<RegisterNewProcedimentoTipoCommand, int>, ProcedimentoTipoCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateProcedimentoTipoCommand, int>, ProcedimentoTipoCommandHandler>();
            services.AddScoped<IRequestHandler<RemoveProcedimentoTipoCommand, int>, ProcedimentoTipoCommandHandler>();

            // Application

            services.AddScoped<IProcedimentoAppService, ProcedimentoAppService>();
            services.AddScoped<IProcedimentoTipoAppService, ProcedimentoTipoAppService>();

        }
    }
}
