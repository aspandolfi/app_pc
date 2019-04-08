using ControleBO.Application.Interfaces;
using ControleBO.Domain.Core.Bus;
using ControleBO.Domain.Core.Notifications;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ControleBO.Api.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
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

        // GET: api/Vitima/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Vitima
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Vitima/5
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
