using ControleBO.Application.Interfaces;
using ControleBO.Domain.Core.Bus;
using ControleBO.Domain.Core.Notifications;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

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
        public IActionResult GetEstatisticaAssunto([FromQuery]DateTime? de, [FromQuery]DateTime? ate)
        {
            return Response(_relatorioAppService.GetEstatisticaAssunto(de, ate));
        }

        // GET: api/relatorio/relacao-procedimentos?situacaoId?={situacaoId}
        [HttpGet("relacao-procedimentos")]
        public IActionResult GetRelacaoProcedimentos([FromQuery]int? situacaoId, [FromQuery]DateTime? de, [FromQuery]DateTime? ate)
        {
            return Response(_relatorioAppService.GetRelacaoProcedimentos(situacaoId, de, ate));
        }

        // GET: api/relatorio/relacao-indiciados
        [HttpGet("relacao-indiciados")]
        public IActionResult GetRelacaoIndiciados()
        {
            return Response(_relatorioAppService.GetRelacaoIndiciados());
        }

        // GET: api/relatorio/relacao-vitimas
        [HttpGet("relacao-vitimas")]
        public IActionResult GetRelacaoVitimas()
        {
            return Response(_relatorioAppService.GetRelacaoVitimas());
        }
    }
}
