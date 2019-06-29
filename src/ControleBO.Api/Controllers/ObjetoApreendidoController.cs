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
    [Route("api/objeto-apreendido")]
    [Produces("application/json")]
    [Authorize("Bearer")]
    [ApiController]
    public class ObjetoApreendidoController : ApiController
    {
        private readonly IObjetoApreendidoAppService _objetoApreendidoAppService;
        public ObjetoApreendidoController(IObjetoApreendidoAppService objetoApreendidoAppService,
                                          INotificationHandler<DomainNotification> notifications,
                                          IMediatorHandler mediator)
            : base(notifications, mediator)
        {
            _objetoApreendidoAppService = objetoApreendidoAppService;
        }

        // GET: api/objeto-apreendido
        [HttpGet]
        public IActionResult Get()
        {
            return Response(_objetoApreendidoAppService.GetAll());
        }

        // GET: api/objeto-apreendido/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Response(_objetoApreendidoAppService.GetById(id));
        }

        // GET: api/objeto-apreendido/procedimento/{procedimentoId}
        [HttpGet("procedimento/{procedimentoId}")]
        public IActionResult GetByProcedimentoId(int procedimentoId)
        {
            return Response(_objetoApreendidoAppService.GetByProcedimentoId(procedimentoId));
        }

        // POST: api/objeto-apreendido
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ObjetoApreendidoViewModel objetoApreendidoVm)
        {
            var taskId = _objetoApreendidoAppService.Register(objetoApreendidoVm);

            if (!IsValidOperation())
            {
                return Response(objetoApreendidoVm, "Falha ao salvar o objeto.");
            }

            objetoApreendidoVm = _objetoApreendidoAppService.GetById(await taskId);

            return Response(objetoApreendidoVm, "O Objeto foi salvo com sucesso!");
        }

        // PUT: api/objeto-apreendido/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] ObjetoApreendidoViewModel objetoApreendidoVm)
        {
            _objetoApreendidoAppService.Update(objetoApreendidoVm);

            if (!IsValidOperation())
            {
                return Response(objetoApreendidoVm, "Falha ao salvar o objeto.");
            }

            return Response(objetoApreendidoVm, "O Objeto foi atualizado com sucesso!");
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _objetoApreendidoAppService.Remove(id);

            if (!IsValidOperation())
            {
                return Response(id, "Falha ao remover o objeto.");
            }

            return Response(id, "O Objeto foi removido com sucesso!");
        }
    }
}
