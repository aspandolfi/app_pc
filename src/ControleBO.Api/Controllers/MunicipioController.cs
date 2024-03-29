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
        [Authorize(Roles = Roles.SuperUserAdmin)]
        public async Task<IActionResult> Post([FromBody] MunicipioViewModel municipioVm)
        {
            int id = await _municipioAppService.Register(municipioVm);

            if (!IsValidOperation())
            {
                return Response(municipioVm, "Falha ao salvar o município.");
            }

            municipioVm = _municipioAppService.GetById(id);

            return Response(municipioVm, "O município foi salvo com sucesso!");
        }

        // PUT: api/Municipio/5
        [HttpPut("{id}")]
        [Authorize(Roles = Roles.SuperUserAdmin)]
        public IActionResult Put(int id, [FromBody] MunicipioViewModel municipioVm)
        {
            _municipioAppService.Update(municipioVm);

            if (!IsValidOperation())
            {
                return Response(municipioVm, "Falha ao salvar o município.");
            }

            return Response(municipioVm, "O município foi atualizado com sucesso!");
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        [Authorize(Roles = Roles.SuperUserAdmin)]
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
