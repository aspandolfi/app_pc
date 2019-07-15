using System.Threading.Tasks;
using ControleBO.Application.Interfaces;
using ControleBO.Application.ViewModels;
using ControleBO.Domain.Core.Bus;
using ControleBO.Domain.Core.Notifications;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ControleBO.Api.Controllers
{
    [Route("api/tipo-situacao")]
    [Produces("application/json")]
    [Authorize("Bearer")]
    [ApiController]
    public class TipoSituacaoController : ApiController
    {
        private readonly ISituacaoTipoAppService _situacaoTipoAppService;

        public TipoSituacaoController(ISituacaoTipoAppService situacaoTipoAppService,
                                      INotificationHandler<DomainNotification> notifications,
                                      IMediatorHandler mediator)
            : base(notifications, mediator)
        {
            _situacaoTipoAppService = situacaoTipoAppService;
        }

        // GET: api/situacao-tipo
        [HttpGet]
        public IActionResult Get()
        {
            return Response(_situacaoTipoAppService.GetAll());
        }

        // GET: api/situacao-tipo/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Response(_situacaoTipoAppService.GetById(id));
        }

        // POST: api/situacao-tipo
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] SituacaoTipoViewModel situacaoTipoVm)
        {
            var taskRegister = _situacaoTipoAppService.Register(situacaoTipoVm);

            if (!IsValidOperation())
            {
                return Response(situacaoTipoVm, "Falha ao salvar o tipo.");
            }

            return Response(await taskRegister, "O Tipo foi salvo com sucesso!");
        }

        // PUT: api/situacao-tipo/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] SituacaoTipoViewModel situacaoTipoVm)
        {
            _situacaoTipoAppService.Update(situacaoTipoVm);

            if (!IsValidOperation())
            {
                return Response(situacaoTipoVm, "Falha ao salvar o tipo.");
            }

            return Response(situacaoTipoVm, "O Tipo foi atualizado com sucesso!");
        }

        // DELETE: api/situacao-tipo/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _situacaoTipoAppService.Remove(id);

            if (!IsValidOperation())
            {
                return Response(id, "Falha ao remover o tipo.");
            }

            return Response(id, "O Tipo foi removido com sucesso!");
        }

        [HttpGet("ultimaAtualizacao/situacao/{situacaoId}")]
        public IActionResult GetUltimaAtualizacao(int situacaoId)
        {
            return Response(_situacaoTipoAppService.UltimaAtualizacao(situacaoId));
        }
    }
}
