using AutoMapper;
using ControleBO.Application.Interfaces;
using ControleBO.Domain.Core.Bus;
using ControleBO.Domain.Core.Commands;
using ControleBO.Domain.Core.Models;
using ControleBO.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;

namespace ControleBO.Application.Services
{
    public abstract class AppServiceBase<TViewModel, TModel, TRegisterCommand, TUpdateCommand, TRemoveCommand> : IAppServiceBase<TViewModel>
        where TModel : Entity
        where TRegisterCommand : Command
        where TUpdateCommand : Command
        where TRemoveCommand : Command
    {
        protected readonly IRepository<TModel> Repository;
        protected readonly IMapper Mapper;
        protected readonly IMediatorHandler Bus;

        public AppServiceBase(IMapper mapper,
                              IRepository<TModel> repository,
                              IMediatorHandler bus)
        {
            Repository = repository;
            Mapper = mapper;
            Bus = bus;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public virtual IEnumerable<TViewModel> GetAll()
        {
            return Mapper.Map<IEnumerable<TModel>, IEnumerable<TViewModel>>(Repository.GetAllAsNoTracking());
        }

        public TViewModel GetById(int id)
        {
            return Mapper.Map<TModel, TViewModel>(Repository.GetById(id));
        }

        public virtual IEnumerable<TViewModel> GetPaged(int page, int pageSize)
        {
            return Mapper.Map<IEnumerable<TModel>, IEnumerable<TViewModel>>(Repository.GetPaged(x => x.CriadoEm, page, pageSize));
        }

        public virtual Task<int> Register(TViewModel tViewModel)
        {
            var registerCommand = Mapper.Map<TViewModel, TRegisterCommand>(tViewModel);
            return Bus.SendCommand(registerCommand);
        }

        public virtual void Remove(int id)
        {
            Type type = typeof(TRemoveCommand);
            ConstructorInfo ctor = type.GetConstructor(new[] { typeof(int) });

            var removeCommand = ctor.Invoke(new object[] { id }) as TRemoveCommand;
            Bus.SendCommand(removeCommand);
        }

        public DateTime? UltimaAtualizacao()
        {
            return Repository.LastUpdate();
        }

        public virtual void Update(TViewModel tViewModel)
        {
            var updateCommand = Mapper.Map<TViewModel, TUpdateCommand>(tViewModel);
            Bus.SendCommand(updateCommand);
        }
    }
}
