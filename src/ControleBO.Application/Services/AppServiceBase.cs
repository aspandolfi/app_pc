using AutoMapper;
using ControleBO.Application.Interfaces;
using ControleBO.Domain.Core.Bus;
using ControleBO.Domain.Core.Commands;
using ControleBO.Domain.Core.Models;
using ControleBO.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace ControleBO.Application.Services
{
    public class AppServiceBase<TViewModel, TModel, TRegisterCommand, TUpdateCommand, TRemoveCommand> : IAppServiceBase<TViewModel>
        where TModel : Entity
        where TRegisterCommand : Command
        where TUpdateCommand : Command
        where TRemoveCommand : Command
    {
        private readonly IRepository<TModel> _repository;
        protected readonly IMapper Mapper;
        protected readonly IMediatorHandler Bus;

        public AppServiceBase(IMapper mapper,
                              IRepository<TModel> repository,
                              IMediatorHandler bus)
        {
            _repository = repository;
            Mapper = mapper;
            Bus = bus;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public virtual IEnumerable<TViewModel> GetAll()
        {
            return Mapper.Map<IEnumerable<TModel>, IEnumerable<TViewModel>>(_repository.GetAllAsNoTracking());
        }

        public TViewModel GetById(int id)
        {
            return Mapper.Map<TModel, TViewModel>(_repository.GetById(id));
        }

        public virtual IEnumerable<TViewModel> GetPaged(int page, int pageSize)
        {
            return Mapper.Map<IEnumerable<TModel>, IEnumerable<TViewModel>>(_repository.GetPaged(page, pageSize));
        }

        public virtual void Register(TViewModel tViewModel)
        {
            var registerCommand = Mapper.Map<TViewModel, TRegisterCommand>(tViewModel);
            Bus.SendCommand(registerCommand);
        }

        public virtual void Remove(int id)
        {
            Type type = typeof(TRemoveCommand);
            ConstructorInfo ctor = type.GetConstructor(new[] { typeof(int) });

            var removeCommand = ctor.Invoke(new object[] { id }) as TRemoveCommand;
            Bus.SendCommand(removeCommand);
        }

        public virtual void Update(TViewModel tViewModel)
        {
            var updateCommand = Mapper.Map<TViewModel, TUpdateCommand>(tViewModel);
            Bus.SendCommand(updateCommand);
        }
    }
}
