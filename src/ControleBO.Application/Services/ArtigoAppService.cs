using AutoMapper;
using ControleBO.Application.Interfaces;
using ControleBO.Application.ViewModels;
using ControleBO.Domain.Commands;
using ControleBO.Domain.Core.Bus;
using ControleBO.Domain.Interfaces.Repositories;
using ControleBO.Domain.Models;

namespace ControleBO.Application.Services
{
    public class ArtigoAppService : AppServiceBase<ArtigoViewModel,
                                                   Artigo,
                                                   RegisterNewArtigoCommand,
                                                   UpdateArtigoCommand,
                                                   RemoveArtigoCommand>,
                                    IArtigoAppService
    {
        public ArtigoAppService(IMapper mapper, IArtigoRepository repository, IMediatorHandler bus) : base(mapper, repository, bus)
        {
        }
    }
}
