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
    [Route("api/procedimento")]
    [Produces("application/json")]
    [Authorize("Bearer")]
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
            return Response(_procedimentoAppService.GetAllAsListViewModel());
        }

        [HttpGet("ultimaAtualizacao")]
        public IActionResult GetUltimaAtualizacao()
        {
            return Response(_procedimentoAppService.UltimaAtualizacao());
        }

        // GET: api/procedimento/paginate?page={page}&pageSize={pageSize}
        [HttpGet("paginate")]
        public IActionResult Get([FromQuery]int page, [FromQuery]int pageSize)
        {
            return Response(_procedimentoAppService.GetAllPagedAsDatatable(page, pageSize));
        }

        // GET: api/procedimento/datatablequery?draw={draw}...
        //[HttpGet("datatablequery")]
        //public IActionResult GetAsDatatableQuery([FromQuery]DatatableQueryInputViewModel datatableQuery)
        //{
        //    return Response(_procedimentoAppService.GetAllQueryableAsDatatable(datatableQuery));
        //}

        [HttpGet("datatablequery")]
        public IActionResult GetAsDatatableQuery([FromQuery]int draw,
                                                 [FromQuery(Name = "order[0][column]")]int orderColumn,
                                                 [FromQuery(Name = "order[0][dir]")]string orderDir,
                                                 [FromQuery]int start,
                                                 [FromQuery]int length,
                                                 [FromQuery(Name = "search[value]")]string searchText)
        {
            var input = new DatatableQueryInputViewModel
            {
                Draw = draw,
                OrderColumn = orderColumn == 0 ? 1 : orderColumn,
                OrderDir = orderDir,
                Start = start,
                Length = length,
                TextToSearch = searchText
            };

            return Response(_procedimentoAppService.GetAllQueryableAsDatatable(input));
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
            var TaskId = _procedimentoAppService.Register(procedimentoVm);

            if (!IsValidOperation())
            {
                return Response(procedimentoVm, "Falha ao salvar o procedimento.");
            }

            return Response(await TaskId, "O Procedimento foi salvo com sucesso!");
        }

        // PUT: api/Procedimento/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] ProcedimentoViewModel procedimentoVm)
        {
            _procedimentoAppService.Update(procedimentoVm);

            if (!IsValidOperation())
            {
                return Response(procedimentoVm, "Falha ao salvar o procedimento.");
            }

            return Response(id, "O Procedimento foi atualizado com sucesso!");
        }

        // DELETE: api/Procedimento/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _procedimentoAppService.Remove(id);

            if (!IsValidOperation())
            {
                return Response(id, "Falha ao remover o procedimento.");
            }

            return Response(id, "O Procedimento foi removido com sucesso!");
        }
    }
}
