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
    public class VitimaController : ApiController
    {
        private readonly IVitimaAppService _vitimaAppService;
        public VitimaController(IVitimaAppService vitimaAppService,
                                INotificationHandler<DomainNotification> notifications,
                                IMediatorHandler mediator)
            : base(notifications, mediator)
        {
            _vitimaAppService = vitimaAppService;
        }

        // GET: api/Vitima
        [HttpGet]
        public IActionResult Get()
        {
            return Response(_vitimaAppService.GetAll());
        }

        // GET: api/Vitima/Procedimento/1
        [HttpGet("procedimento/{procedimentoId}")]
        public IActionResult GetByProcedimentoId(int procedimentoId)
        {
            return Response(_vitimaAppService.GetAllByProcedimentoId(procedimentoId));
        }

        // GET: api/Vitima/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Response(_vitimaAppService.GetById(id));
        }

        // POST: api/Vitima
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] VitimaViewModel vitimaVm)
        {
            var taskId = _vitimaAppService.Register(vitimaVm);

            if (!IsValidOperation())
            {
                return Response(vitimaVm, "Falha ao salvar a vítima.");
            }

            vitimaVm = _vitimaAppService.GetById(await taskId);

            return Response(vitimaVm, "A Vítima foi salva com sucesso!");
        }

        // PUT: api/Vitima/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] VitimaViewModel vitimaVm)
        {
            _vitimaAppService.Update(vitimaVm);

            if (!IsValidOperation())
            {
                return Response(vitimaVm, "Falha ao salvar a vítima.");
            }

            return Response(vitimaVm, "A Vítima foi atualizada com sucesso!");
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _vitimaAppService.Remove(id);

            if (!IsValidOperation())
            {
                return Response(id, "Falha ao remover a vítima.");
            }

            return Response(id, "A Vítima foi removida com sucesso!");
        }
    }
}
