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
            services.AddScoped<IArtigoRepository, ArtigoRepository>();
            services.AddScoped<IAssuntoRepository, AssuntoRepository>();
            services.AddScoped<IMunicipioRepository, MunicipioRepository>();
            services.AddScoped<IProcedimentoRepository, ProcedimentoRepository>();
            services.AddScoped<IProcedimentoTipoRepository, ProcedimentoTipoRepository>();
            services.AddScoped<IVaraCriminalRepository, VaraCriminalRepository>();
            services.AddScoped<IUnidadePolicialRepository, UnidadePolicialRepository>();
            services.AddScoped<IVitimaRepository, VitimaRepository>();
            services.AddScoped<IIndiciadoRepository, IndiciadoRepository>();
            services.AddScoped<ISituacaoRepository, SituacaoRepository>();
            services.AddScoped<ISituacaoProcedimentoRepository, SituacaoProcedimentoRepository>();
            services.AddScoped<ISituacaoTipoRepository, SituacaoTipoRepository>();
            services.AddScoped<IMovimentacaoRepository, MovimentacaoRepository>();

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

            services.AddScoped<IRequestHandler<RegisterNewVaraCriminalCommand, int>, VaraCriminalCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateVaraCriminalCommand, int>, VaraCriminalCommandHandler>();
            services.AddScoped<IRequestHandler<RemoveVaraCriminalCommand, int>, VaraCriminalCommandHandler>();

            services.AddScoped<IRequestHandler<RegisterNewArtigoCommand, int>, ArtigoCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateArtigoCommand, int>, ArtigoCommandHandler>();
            services.AddScoped<IRequestHandler<RemoveArtigoCommand, int>, ArtigoCommandHandler>();

            services.AddScoped<IRequestHandler<RegisterNewVitimaCommand, int>, VitimaCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateVitimaCommand, int>, VitimaCommandHandler>();
            services.AddScoped<IRequestHandler<RemoveVitimaCommand, int>, VitimaCommandHandler>();

            services.AddScoped<IRequestHandler<RegisterNewIndiciadoCommand, int>, IndiciadoCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateIndiciadoCommand, int>, IndiciadoCommandHandler>();
            services.AddScoped<IRequestHandler<RemoveIndiciadoCommand, int>, IndiciadoCommandHandler>();

            services.AddScoped<IRequestHandler<RegisterNewSituacaoCommand, int>, SituacaoCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateSituacaoCommand, int>, SituacaoCommandHandler>();
            services.AddScoped<IRequestHandler<RemoveSituacaoCommand, int>, SituacaoCommandHandler>();

            services.AddScoped<IRequestHandler<RegisterNewSituacaoProcedimentoCommand, int>, SituacaoProcedimentoCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateSituacaoProcedimentoCommand, int>, SituacaoProcedimentoCommandHandler>();
            services.AddScoped<IRequestHandler<RemoveSituacaoProcedimentoCommand, int>, SituacaoProcedimentoCommandHandler>();

            services.AddScoped<IRequestHandler<RegisterNewMovimentacaoCommand, int>, MovimentacaoCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateMovimentacaoCommand, int>, MovimentacaoCommandHandler>();
            services.AddScoped<IRequestHandler<RemoveMovimentacaoCommand, int>, MovimentacaoCommandHandler>();

            // Application
            services.AddScoped<IProcedimentoAppService, ProcedimentoAppService>();
            services.AddScoped<IProcedimentoTipoAppService, ProcedimentoTipoAppService>();
            services.AddScoped<IMunicipioAppService, MunicipioAppService>();
            services.AddScoped<IVaraCriminalAppService, VaraCriminalAppService>();
            services.AddScoped<IArtigoAppService, ArtigoAppService>();
            services.AddScoped<IAssuntoAppService, AssuntoAppService>();
            services.AddScoped<IUnidadePolicialAppService, UnidadePolicialAppService>();
            services.AddScoped<IVitimaAppService, VitimaAppService>();
            services.AddScoped<IIndiciadoAppService, IndiciadoAppService>();
            services.AddScoped<ISituacaoAppService, SituacaoAppService>();
            services.AddScoped<ISituacaoProcedimentoAppService, SituacaoProcedimentoAppService>();
            services.AddScoped<IMovimentacaoAppService, MovimentacaoAppService>();

        }
    }
}
