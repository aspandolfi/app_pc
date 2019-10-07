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
    public class AssuntoController : ApiController
    {
        private readonly IAssuntoAppService _assuntoAppService;

        public AssuntoController(INotificationHandler<DomainNotification> notifications,
                                 IMediatorHandler mediator,
                                 IAssuntoAppService assuntoAppService) : base(notifications, mediator)
        {
            _assuntoAppService = assuntoAppService;
        }

        // GET: api/Assunto
        [HttpGet]
        public IActionResult Get()
        {
            return Response(_assuntoAppService.GetAll());
        }

        // GET: api/Assunto/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Response(_assuntoAppService.GetById(id));
        }

        // POST: api/Assunto
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AssuntoViewModel assuntoVm)
        {
            int id = await _assuntoAppService.Register(assuntoVm);

            if (!IsValidOperation())
            {
                return Response(assuntoVm, "Falha ao salvar o Assunto.");
            }

            assuntoVm = _assuntoAppService.GetById(id);

            return Response(assuntoVm, "O Assunto foi salvo com sucesso!");
        }

        // PUT: api/Assunto/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] AssuntoViewModel assuntoVm)
        {
            _assuntoAppService.Update(assuntoVm);

            if (!IsValidOperation())
            {
                return Response(assuntoVm, "Falha ao salvar o Assunto.");
            }

            return Response(assuntoVm, "O Assunto foi atualizado com sucesso!");
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _assuntoAppService.Remove(id);

            if (!IsValidOperation())
            {
                return Response(id, "Falha ao remover o Assunto.");
            }

            return Response(id, "O Assunto foi removido com sucesso!");
        }

        [HttpGet("ultimaAtualizacao")]
        public IActionResult GetUltimaAtualizacao()
        {
            return Response(_assuntoAppService.UltimaAtualizacao());
        }
    }
}
