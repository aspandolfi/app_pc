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
        public IActionResult Get()
        {
            return Response(_relatorioAppService.GetEstatisticaAssunto());
        }

        // GET: api/Relatorio/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Relatorio
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Relatorio/5
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
