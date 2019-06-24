using AutoMapper;
using ControleBO.Application.ViewModels;
using ControleBO.Domain.Commands;

namespace ControleBO.Application.Mappers
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<ProcedimentoTipoViewModel, RegisterNewProcedimentoTipoCommand>()
                .ConstructUsing(c => new RegisterNewProcedimentoTipoCommand(c.Sigla, c.Descricao));
            CreateMap<ProcedimentoTipoViewModel, UpdateProcedimentoTipoCommand>()
                .ConstructUsing(c => new UpdateProcedimentoTipoCommand(c.Id, c.Sigla, c.Descricao));

            CreateMap<VitimaViewModel, RegisterNewVitimaCommand>()
                .ConstructUsing(v => new RegisterNewVitimaCommand(v.Email, v.ProcedimentoId,
                                     v.Nome, v.NomePai, v.NomeMae, v.DataNascimento, v.Idade, v.Telefone, v.MunicipioId));
            CreateMap<VitimaViewModel, UpdateVitimaCommand>()
                .ConstructUsing(v => new UpdateVitimaCommand(v.Id, v.Email, v.ProcedimentoId,
                                     v.Nome, v.NomePai, v.NomeMae, v.DataNascimento, v.Idade, v.Telefone, v.MunicipioId));

            CreateMap<IndiciadoViewModel, RegisterNewIndiciadoCommand>()
                .ConstructUsing(v => new RegisterNewIndiciadoCommand(v.Apelido, v.ProcedimentoId,
                         v.Nome, v.NomePai, v.NomeMae, v.DataNascimento, v.Idade, v.Telefone, v.MunicipioId));
            CreateMap<IndiciadoViewModel, UpdateIndiciadoCommand>()
                .ConstructUsing(v => new UpdateIndiciadoCommand(v.Id, v.Apelido, v.ProcedimentoId,
                                     v.Nome, v.NomePai, v.NomeMae, v.DataNascimento, v.Idade, v.Telefone, v.MunicipioId));

            CreateMap<ProcedimentoViewModel, RegisterNewProcedimentoCommand>().
                ConstructUsing(p => new RegisterNewProcedimentoCommand(p.BoletimUnificado,
                                                                       p.BoletimOcorrencia,
                                                                       p.NumeroProcessual,
                                                                       p.Gampes,
                                                                       p.Anexos,
                                                                       p.LocalFato,
                                                                       p.DataFato,
                                                                       p.DataInstauracao,
                                                                       p.TipoCriminal,
                                                                       p.AndamentoProcessual,
                                                                       p.TipoProcedimentoId,
                                                                       p.VaraCriminalId,
                                                                       p.ComarcaId,
                                                                       p.AssuntoId,
                                                                       p.ArtigoId,
                                                                       p.DelegaciaOrigemId));
            CreateMap<ProcedimentoViewModel, UpdateProcedimentoCommand>().
                ConstructUsing(p => new UpdateProcedimentoCommand(p.Id,
                                                                  p.BoletimUnificado,
                                                                  p.BoletimOcorrencia,
                                                                  p.NumeroProcessual,
                                                                  p.Gampes,
                                                                  p.Anexos,
                                                                  p.LocalFato,
                                                                  p.DataFato,
                                                                  p.DataInstauracao,
                                                                  p.TipoCriminal,
                                                                  p.AndamentoProcessual,
                                                                  p.TipoProcedimentoId,
                                                                  p.VaraCriminalId,
                                                                  p.ComarcaId,
                                                                  p.AssuntoId,
                                                                  p.ArtigoId,
                                                                  p.DelegaciaOrigemId));

            CreateMap<AssuntoViewModel, RegisterNewAssuntoCommand>()
                .ConstructUsing(a => new RegisterNewAssuntoCommand(a.Descricao));
            CreateMap<AssuntoViewModel, UpdateAssuntoCommand>()
                .ConstructUsing(a => new UpdateAssuntoCommand(a.Id, a.Descricao));

            CreateMap<ArtigoViewModel, RegisterNewArtigoCommand>()
                .ConstructUsing(a => new RegisterNewArtigoCommand(a.Descricao));
            CreateMap<AssuntoViewModel, UpdateArtigoCommand>()
                .ConstructUsing(a => new UpdateArtigoCommand(a.Id, a.Descricao));

            CreateMap<VaraCriminalCommand, RegisterNewVaraCriminalCommand>()
                .ConstructUsing(a => new RegisterNewVaraCriminalCommand(a.Descricao));
            CreateMap<VaraCriminalViewModel, UpdateVaraCriminalCommand>()
                .ConstructUsing(a => new UpdateVaraCriminalCommand(a.Id, a.Descricao));

            CreateMap<MunicipioViewModel, RegisterNewMunicipioCommand>()
                .ConstructUsing(m => new RegisterNewMunicipioCommand(m.Nome, m.UF, m.CEP));
            CreateMap<MunicipioViewModel, UpdateMunicipioCommand>()
                .ConstructUsing(m => new UpdateMunicipioCommand(m.Id, m.Nome, m.UF, m.CEP));

            CreateMap<MovimentacaoViewModel, RegisterNewMovimentacaoCommand>()
                .ConstructUsing(m => new RegisterNewMovimentacaoCommand(m.Destino, m.Data, m.RetornouEm, m.ProcedimentoId));
            CreateMap<MovimentacaoViewModel, UpdateMovimentacaoCommand>()
                .ConstructUsing(m => new UpdateMovimentacaoCommand(m.Id, m.Destino, m.Data, m.RetornouEm, m.ProcedimentoId));

            CreateMap<SituacaoProcedimentoViewModel, RegisterNewSituacaoProcedimentoCommand>()
                .ConstructUsing(m => new RegisterNewSituacaoProcedimentoCommand(m.ProcedimentoId, m.SituacaoId, m.SituacaoTipoId, m.DataRelatorio, m.Observacao));
            CreateMap<SituacaoProcedimentoViewModel, UpdateSituacaoProcedimentoCommand>()
                .ConstructUsing(m => new UpdateSituacaoProcedimentoCommand(m.Id, m.ProcedimentoId, m.SituacaoId, m.SituacaoTipoId, m.DataRelatorio, m.Observacao));

            CreateMap<ObjetoApreendidoViewModel, RegisterNewObjetoApreendidoCommand>()
                .ConstructUsing(m => new RegisterNewObjetoApreendidoCommand(m.Descricao, m.Local, m.ProcedimentoId));
            CreateMap<ObjetoApreendidoViewModel, UpdateObjetoApreendidoCommand>()
                .ConstructUsing(m => new UpdateObjetoApreendidoCommand(m.Id, m.Descricao, m.Local, m.ProcedimentoId));
        }
    }
}
