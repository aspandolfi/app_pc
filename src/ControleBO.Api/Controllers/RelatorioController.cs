using ControleBO.Application.Interfaces;
using ControleBO.Domain.Core.Bus;
using ControleBO.Domain.Core.Notifications;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ControleBO.Api.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [Authorize("Bearer")]
    [ApiController]
    public class RelatorioController : ApiController
    {
        private readonly IRelatorioAppService _relatorioAppService;

        public RelatorioController(IRelatorioAppService relatorioAppService,
                                   INotificationHandler<DomainNotification> notifications,
                                   IMediatorHandler mediator)
            : base(notifications, mediator)
        {
            _relatorioAppService = relatorioAppService;
        }

        // GET: api/relatorio/estatistica-assunto
        [HttpGet("estatistica-assunto")]
        public IActionResult GetEstatisticaAssunto()
        {
            return Response(_relatorioAppService.GetEstatisticaAssunto());
        }

        // GET: api/relatorio/relacao-procedimentos?situacaoId?={situacaoId}
        [HttpGet("relacao-procedimentos")]
        public IActionResult GetRelacaoProcedimentos([FromQuery]int situacaoId)
        {
            return Response(_relatorioAppService.GetRelacaoProcedimentos(situacaoId));
        }

        // GET: api/relatorio/relacao-indiciados
        [HttpGet("relacao-indiciados")]
        public IActionResult GetRelacaoIndiciados()
        {
            return Response(_relatorioAppService.GetRelacaoIndiciados());
        }
    }
}
