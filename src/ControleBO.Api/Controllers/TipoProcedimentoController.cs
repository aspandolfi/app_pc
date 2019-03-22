using ControleBO.Application.Interfaces;
using ControleBO.Application.ViewModels;
using ControleBO.Domain.Core.Bus;
using ControleBO.Domain.Core.Notifications;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ControleBO.Api.Controllers
{
    [Route("api/tipo-procedimento")]
    [Produces("application/json")]
    [ApiController]
    public class TipoProcedimentoController : ApiController
    {
        private readonly IProcedimentoTipoAppService _procedimentoTipoAppService;

        public TipoProcedimentoController(IProcedimentoTipoAppService procedimentoTipoAppService,
                                          INotificationHandler<DomainNotification> notifications,
                                          IMediatorHandler mediator)
            : base(notifications, mediator)
        {
            _procedimentoTipoAppService = procedimentoTipoAppService;
        }

        // GET: api/tipo-procedimento
        [HttpGet]
        public IActionResult Get()
        {
            return Response(_procedimentoTipoAppService.GetAll());
        }

        // GET: api/tipo-procedimento/paginate?page={page}&pageSize={pageSize}
        [HttpGet("paginate")]
        public IActionResult Get([FromQuery]int page, [FromQuery]int pageSize)
        {
            return Response(_procedimentoTipoAppService.GetPaged(page, pageSize));
        }

        // GET: api/tipo-procedimento/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            return Response(_procedimentoTipoAppService.GetById(id));
        }

        // POST: api/tipo-procedimento
        [HttpPost]
        public IActionResult Post([FromBody] ProcedimentoTipoViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(vm);
            }

            _procedimentoTipoAppService.Register(vm);

            return Response(vm, "Tipo de Procedimento cadastrado com sucesso!");
        }

        // PUT: api/tipo-procedimento/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] ProcedimentoTipoViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(vm);
            }

            _procedimentoTipoAppService.Update(vm);

            return Response(vm, "Tipo de Procedimento atualizado com sucesso!");
        }

        // DELETE: api/tipo-procedimento/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _procedimentoTipoAppService.Remove(id);

            return Response(null, "Tipo de Procedimento removido com sucesso!");
        }
    }
}
