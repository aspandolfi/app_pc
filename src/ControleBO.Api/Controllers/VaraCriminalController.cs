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
    public class VaraCriminalController : ApiController
    {
        private readonly IVaraCriminalAppService _varaCriminalAppService;

        public VaraCriminalController(INotificationHandler<DomainNotification> notifications,
                                      IMediatorHandler mediator,
                                      IVaraCriminalAppService varaCriminalAppService) : base(notifications, mediator)
        {
            _varaCriminalAppService = varaCriminalAppService;
        }

        // GET: api/VaraCriminal
        [HttpGet]
        public IActionResult Get()
        {
            return Response(_varaCriminalAppService.GetAll());
        }

        // GET: api/VaraCriminal/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Response(_varaCriminalAppService.GetById(id));
        }

        // POST: api/VaraCriminal
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] VaraCriminalViewModel varaCriminalVm)
        {
            int id = await _varaCriminalAppService.Register(varaCriminalVm);

            if (!IsValidOperation())
            {
                return Response(varaCriminalVm, "Falha ao salvar a vara criminal.");
            }

            return Response(id, "A Vara Criminal foi salvo com sucesso!");
        }

        // PUT: api/VaraCriminal/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] VaraCriminalViewModel varaCriminalVm)
        {
            _varaCriminalAppService.Update(varaCriminalVm);

            if (!IsValidOperation())
            {
                return Response(varaCriminalVm, "Falha ao atualizar a vara criminal.");
            }

            return Response(id, "A Vara Criminal foi atualizada com sucesso!");
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _varaCriminalAppService.Remove(id);

            if (!IsValidOperation())
            {
                return Response(id, "Falha ao remover a vara criminal.");
            }

            return Response(id, "A Vara Criminal foi removida com sucesso!");
        }

        [HttpGet("ultimaAtualizacao")]
        public IActionResult GetUltimaAtualizacao()
        {
            return Response(_varaCriminalAppService.UltimaAtualizacao());
        }
    }
}
