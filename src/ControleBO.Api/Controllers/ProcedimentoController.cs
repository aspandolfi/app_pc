using ControleBO.Application.Interfaces;
using ControleBO.Application.ViewModels;
using ControleBO.Domain.Core.Bus;
using ControleBO.Domain.Core.Notifications;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ControleBO.Api.Controllers
{
    [Route("api/procedimento")]
    [Produces("application/json")]
    [ApiController]
    public class ProcedimentoController : ApiController
    {
        private readonly IProcedimentoAppService _procedimentoAppService;

        public ProcedimentoController(IProcedimentoAppService procedimentoAppService,
                                      INotificationHandler<DomainNotification> notifications,
                                      IMediatorHandler mediator)
            : base(notifications, mediator)
        {
            _procedimentoAppService = procedimentoAppService;
        }

        // GET: api/Procedimento
        [HttpGet]
        public IActionResult Get()
        {
            return Response(_procedimentoAppService.GetAll());
        }

        // GET: api/Procedimento/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Response(_procedimentoAppService.GetById(id));
        }

        // POST: api/Procedimento
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ProcedimentoViewModel procedimentoVm)
        {
            int id = await _procedimentoAppService.Register(procedimentoVm);

            if (!IsValidOperation())
            {
                return Response(procedimentoVm, "Falha ao salvar o procedimento.");
            }

            return Response(id, "O Procedimento foi salvo com sucesso!");
        }

        // PUT: api/Procedimento/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
