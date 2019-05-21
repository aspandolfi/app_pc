using ControleBO.Application.Interfaces;
using ControleBO.Application.ViewModels;
using ControleBO.Domain.Core.Bus;
using ControleBO.Domain.Core.Notifications;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ControleBO.Api.Controllers
{
    [Route("api/unidade-policial")]
    [Produces("application/json")]
    [ApiController]
    public class UnidadePolicialController : ApiController
    {
        private readonly IUnidadePolicialAppService _unidadePolicialAppService;
        public UnidadePolicialController(IUnidadePolicialAppService unidadePolicialAppService,
                                         INotificationHandler<DomainNotification> notifications,
                                         IMediatorHandler mediator) : base(notifications, mediator)
        {
            _unidadePolicialAppService = unidadePolicialAppService;
        }

        // GET: api/UnidadePolicial
        [HttpGet]
        [ResponseCache(Duration = 3600, Location = ResponseCacheLocation.Any)]
        public IActionResult Get()
        {
            return Response(_unidadePolicialAppService.GetAll());
        }

        // GET: api/UnidadePolicial/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Response(_unidadePolicialAppService.GetById(id));
        }

        // POST: api/UnidadePolicial
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UnidadePolicialViewModel unidadePolicialVm)
        {
            int id = await _unidadePolicialAppService.Register(unidadePolicialVm);

            if (!IsValidOperation())
            {
                return Response(unidadePolicialVm, "Falha ao salvar a unidade policial.");
            }

            return Response(id, "A Unidade Policial foi salva com sucesso!");
        }

        // PUT: api/UnidadePolicial/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UnidadePolicialViewModel unidadePolicialVm)
        {
            _unidadePolicialAppService.Update(unidadePolicialVm);

            if (!IsValidOperation())
            {
                return Response(unidadePolicialVm, "Falha ao salvar a unidade policial.");
            }

            return Response(id, "A Unidade Policial foi atualizada com sucesso!");
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _unidadePolicialAppService.Remove(id);

            if (!IsValidOperation())
            {
                return Response(id, "Falha ao remover a unidade policial.");
            }

            return Response(id, "A Unidade Policial foi removida com sucesso!");
        }
    }
}
