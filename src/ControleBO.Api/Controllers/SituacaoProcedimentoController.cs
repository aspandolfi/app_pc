using ControleBO.Application.Interfaces;
using ControleBO.Application.ViewModels;
using ControleBO.Domain.Core.Bus;
using ControleBO.Domain.Core.Notifications;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ControleBO.Api.Controllers
{
    [Route("api/situacao-procedimento")]
    [Produces("application/json")]
    [ApiController]
    public class SituacaoProcedimentoController : ApiController
    {
        private readonly ISituacaoProcedimentoAppService _situacaoProcedimentoAppService;

        public SituacaoProcedimentoController(ISituacaoProcedimentoAppService situacaoProcedimentoAppService,
                                              INotificationHandler<DomainNotification> notifications,
                                              IMediatorHandler mediator) : base(notifications, mediator)
        {
            _situacaoProcedimentoAppService = situacaoProcedimentoAppService;
        }

        // GET: api/situacao-procedimento
        [HttpGet]
        public IActionResult Get()
        {
            return Response(_situacaoProcedimentoAppService.GetAll());
        }

        // GET: api/situacao-procedimento/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Response(_situacaoProcedimentoAppService.GetById(id));
        }

        [HttpGet("procedimento/{procedimentoId}")]
        public IActionResult GetByProcedimentoId(int procedimentoId)
        {
            return Response(_situacaoProcedimentoAppService.GetCurrentByProcedimentoId(procedimentoId));
        }

        // POST: api/situacao-procedimento
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] SituacaoProcedimentoViewModel situacaoProcedimentoVm)
        {
            int id = await _situacaoProcedimentoAppService.Register(situacaoProcedimentoVm);

            if (!IsValidOperation())
            {
                return Response(situacaoProcedimentoVm, "Falha ao salvar a situação.");
            }

            return Response(id, "A situação foi salva com sucesso!");
        }

        // PUT: api/situacao-procedimento/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] SituacaoProcedimentoViewModel situacaoProcedimentoVm)
        {
            _situacaoProcedimentoAppService.Update(situacaoProcedimentoVm);

            if (!IsValidOperation())
            {
                return Response(situacaoProcedimentoVm, "Falha ao salvar a situação.");
            }

            return Response(id, "A situação foi atualizado com sucesso!");
        }

        // DELETE: api/situacao-procedimento/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _situacaoProcedimentoAppService.Remove(id);

            if (!IsValidOperation())
            {
                return Response(id, "Falha ao remover a situação.");
            }

            return Response(id, "A situação foi removida com sucesso!");
        }
    }
}
