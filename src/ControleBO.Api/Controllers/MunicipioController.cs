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
    public class MunicipioController : ApiController
    {
        private readonly IMunicipioAppService _municipioAppService;

        public MunicipioController(INotificationHandler<DomainNotification> notifications,
                                   IMediatorHandler mediator,
                                   IMunicipioAppService municipioAppService) : base(notifications, mediator)
        {
            _municipioAppService = municipioAppService;
        }

        // GET: api/Municipio
        [HttpGet]
        [ResponseCache(Duration = 72000, Location = ResponseCacheLocation.Any)]
        public IActionResult Get()
        {
            return Response(_municipioAppService.GetAll());
        }

        // GET: api/Municipio
        [HttpGet("searchBytext/{text}")]
        public IActionResult GetByText(string text)
        {
            return Response(_municipioAppService.GetAllByText(text));
        }

        // GET: api/Municipio/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Response(_municipioAppService.GetById(id));
        }

        // POST: api/Municipio
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] MunicipioViewModel municipioVm)
        {
            int id = await _municipioAppService.Register(municipioVm);

            if (!IsValidOperation())
            {
                return Response(municipioVm, "Falha ao salvar o município.");
            }

            return Response(id, "O município foi salvo com sucesso!");
        }

        // PUT: api/Municipio/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] MunicipioViewModel municipioVm)
        {
            _municipioAppService.Update(municipioVm);

            if (!IsValidOperation())
            {
                return Response(municipioVm, "Falha ao salvar o município.");
            }

            return Response(id, "O município foi atualizado com sucesso!");
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _municipioAppService.Remove(id);

            if (!IsValidOperation())
            {
                return Response(id, $"Falha ao remover o município # {id}.");
            }

            return Response(id, "O município foi removido com sucesso!");
        }

        [HttpGet("ultimaAtualizacao")]
        public IActionResult GetUltimaAtualizacao()
        {
            return Response(_municipioAppService.UltimaAtualizacao());
        }
    }
}
