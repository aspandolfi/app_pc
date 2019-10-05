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
    public class SituacaoController : ApiController
    {
        private readonly ISituacaoAppService _situacaoAppService;

        public SituacaoController(ISituacaoAppService situacaoAppService,
                                  INotificationHandler<DomainNotification> notifications,
                                  IMediatorHandler mediator)
            : base(notifications, mediator)
        {
            _situacaoAppService = situacaoAppService;
        }

        // GET: api/Situacao
        [HttpGet]
        public IActionResult Get()
        {
            return Response(_situacaoAppService.GetAll());
        }

        // GET: api/Situacao/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Response(_situacaoAppService.GetById(id));
        }

        // POST: api/Situacao
        [HttpPost]
        public IActionResult Post([FromBody] string value)
        {
            return Response();
        }

        // PUT: api/Situacao/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] string value)
        {
            return Response();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Response();
        }
    }
}
