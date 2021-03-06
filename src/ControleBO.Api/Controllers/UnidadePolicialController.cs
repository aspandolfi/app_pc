﻿using ControleBO.Application.Interfaces;
using ControleBO.Application.ViewModels;
using ControleBO.Domain.Core.Bus;
using ControleBO.Domain.Core.Notifications;
using ControleBO.Infra.CrossCutting.Identity.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ControleBO.Api.Controllers
{
    [Route("api/unidade-policial")]
    [Produces("application/json")]
    [Authorize("Bearer")]
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
        [Authorize(Roles = Roles.SuperUserAdmin)]
        public async Task<IActionResult> Post([FromBody] UnidadePolicialViewModel unidadePolicialVm)
        {
            int id = await _unidadePolicialAppService.Register(unidadePolicialVm);

            if (!IsValidOperation())
            {
                return Response(unidadePolicialVm, "Falha ao salvar a unidade policial.");
            }

            unidadePolicialVm = _unidadePolicialAppService.GetById(id);

            return Response(unidadePolicialVm, "A Unidade Policial foi salva com sucesso!");
        }

        // PUT: api/UnidadePolicial/5
        [HttpPut("{id}")]
        [Authorize(Roles = Roles.SuperUserAdmin)]
        public IActionResult Put(int id, [FromBody] UnidadePolicialViewModel unidadePolicialVm)
        {
            _unidadePolicialAppService.Update(unidadePolicialVm);

            if (!IsValidOperation())
            {
                return Response(unidadePolicialVm, "Falha ao salvar a unidade policial.");
            }

            return Response(unidadePolicialVm, "A Unidade Policial foi atualizada com sucesso!");
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        [Authorize(Roles = Roles.SuperUserAdmin)]
        public IActionResult Delete(int id)
        {
            _unidadePolicialAppService.Remove(id);

            if (!IsValidOperation())
            {
                return Response(id, "Falha ao remover a unidade policial.");
            }

            return Response(id, "A Unidade Policial foi removida com sucesso!");
        }

        [HttpGet("ultimaAtualizacao")]
        public IActionResult GetUltimaAtualizacao()
        {
            return Response(_unidadePolicialAppService.UltimaAtualizacao());
        }
    }
}
