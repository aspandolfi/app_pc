using ControleBO.Application.Interfaces;
using ControleBO.Application.ViewModels;
using ControleBO.Domain.Core.Bus;
using ControleBO.Domain.Core.Notifications;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ControleBO.Api.Controllers
{
    [Route("api/movimentacao")]
    [Produces("application/json")]
    [ApiController]
    public class MovimentacaoController : ApiController
    {
        private readonly IMovimentacaoAppService _movimentacaoAppService;

        public MovimentacaoController(IMovimentacaoAppService movimentacaoAppService,
                                      INotificationHandler<DomainNotification> notifications,
                                      IMediatorHandler mediator) : base(notifications, mediator)
        {
            _movimentacaoAppService = movimentacaoAppService;
        }

        // GET: api/UltimaMovimentacao
        [HttpGet]
        public IActionResult Get()
        {
            return Response(_movimentacaoAppService.GetAll());
        }

        // GET: api/Ultima-Movimentacao/Procedimento/1
        [HttpGet("procedimento/{procedimentoId}")]
        public IActionResult GetByProcedimentoId(int procedimentoId)
        {
            return Response(_movimentacaoAppService.GetByProcedimentoId(procedimentoId));
        }

        // GET: api/UltimaMovimentacao/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Response(_movimentacaoAppService.GetById(id));
        }

        // POST: api/UltimaMovimentacao
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] MovimentacaoViewModel movimentacaoVm)
        {
            var taskId = _movimentacaoAppService.Register(movimentacaoVm);

            if (!IsValidOperation())
            {
                return Response(movimentacaoVm, "Falha ao salvar a movimentação.");
            }

            movimentacaoVm = _movimentacaoAppService.GetById(await taskId);

            return Response(movimentacaoVm, "A movimentação foi salva com sucesso!");
        }

        // PUT: api/UltimaMovimentacao/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] MovimentacaoViewModel movimentacaoVm)
        {
            _movimentacaoAppService.Update(movimentacaoVm);

            if (!IsValidOperation())
            {
                return Response(movimentacaoVm, "Falha ao salvar a movimentação.");
            }

            return Response(movimentacaoVm, "A movimentação foi salva com sucesso!");
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _movimentacaoAppService.Remove(id);

            if (!IsValidOperation())
            {
                return Response(id, "Falha ao remover a movimentação.");
            }

            return Response(id, "A movimentação foi removida com sucesso!");
        }
    }
}
