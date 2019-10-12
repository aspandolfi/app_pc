using ControleBO.Application.Interfaces;
using ControleBO.Application.ViewModels;
using ControleBO.Domain.Core.Bus;
using ControleBO.Domain.Core.Notifications;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ControleBO.Api.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [Authorize("Bearer")]
    [ApiController]
    public class IndiciadoController : ApiController
    {
        private readonly IIndiciadoAppService _indiciadoAppService;

        public IndiciadoController(IIndiciadoAppService indiciadoAppService,
                                   INotificationHandler<DomainNotification> notifications,
                                   IMediatorHandler mediator)
            : base(notifications, mediator)
        {
            _indiciadoAppService = indiciadoAppService;
        }

        // GET: api/Indiciado
        [HttpGet]
        public IActionResult Get()
        {
            return Response(_indiciadoAppService.GetAll());
        }

        [HttpGet("searchByName")]
        public IActionResult GetByText([FromQuery]string s)
        {
            return Response(_indiciadoAppService.GetIndiciadosByText(s));
        }

        // GET: api/Indiciado/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Response(_indiciadoAppService.GetById(id));
        }

        // GET: api/Indiciado/Procedimento/1
        [HttpGet("procedimento/{procedimentoId}")]
        public IActionResult GetByProcedimentoId(int procedimentoId)
        {
            return Response(_indiciadoAppService.GetAllByProcedimentoId(procedimentoId));
        }

        // POST: api/Indiciado
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] IndiciadoViewModel indiciadoVm)
        {
            var taskId = _indiciadoAppService.Register(indiciadoVm);

            if (!IsValidOperation())
            {
                return Response(indiciadoVm, "Falha ao salvar o indiciado.");
            }

            indiciadoVm = _indiciadoAppService.GetById(await taskId);

            return Response(indiciadoVm, "O Indiciado foi salvo com sucesso!");
        }

        // PUT: api/Indiciado/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] IndiciadoViewModel indiciadoVm)
        {
            _indiciadoAppService.Update(indiciadoVm);

            if (!IsValidOperation())
            {
                return Response(indiciadoVm, "Falha ao salvar o indiciado.");
            }

            indiciadoVm = _indiciadoAppService.GetById(indiciadoVm.Id);

            return Response(indiciadoVm, "O Indiciado foi atualizado com sucesso!");
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _indiciadoAppService.Remove(id);

            if (!IsValidOperation())
            {
                return Response(id, "Falha ao remover o indiciado.");
            }

            return Response(id, "O Indiciado foi removido com sucesso!");
        }
    }
}
