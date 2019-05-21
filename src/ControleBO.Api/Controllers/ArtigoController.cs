using ControleBO.Application.Interfaces;
using ControleBO.Application.ViewModels;
using ControleBO.Domain.Core.Bus;
using ControleBO.Domain.Core.Notifications;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ControleBO.Api.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class ArtigoController : ApiController
    {
        private readonly IArtigoAppService _artigoAppService;

        public ArtigoController(INotificationHandler<DomainNotification> notifications,
                                IMediatorHandler mediator,
                                IArtigoAppService artigoAppService) : base(notifications, mediator)
        {
            _artigoAppService = artigoAppService;
        }

        // GET: api/Artigo
        [HttpGet]
        [ResponseCache(Duration = 3600, Location = ResponseCacheLocation.Any)]
        public IActionResult Get()
        {
            return Response(_artigoAppService.GetAll());
        }

        // GET: api/Artigo/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Response(_artigoAppService.GetById(id));
        }

        // POST: api/Artigo
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ArtigoViewModel artigoVm)
        {
            int id = await _artigoAppService.Register(artigoVm);

            if (!IsValidOperation())
            {
                return Response(artigoVm, "Falha ao salvar o artigo.");
            }

            return Response(id, "O Artigo foi salvo com sucesso!");
        }

        // PUT: api/Artigo/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] ArtigoViewModel artigoVm)
        {
            _artigoAppService.Update(artigoVm);

            if (!IsValidOperation())
            {
                return Response(artigoVm, "Falha ao salvar o artigo.");
            }

            return Response(id, "O Artigo foi atualizado com sucesso!");
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _artigoAppService.Remove(id);

            if (!IsValidOperation())
            {
                return Response(id, "Falha ao remover o artigo.");
            }

            return Response(id, "O Artigo foi removido com sucesso!");
        }
    }
}
