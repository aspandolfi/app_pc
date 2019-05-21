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
                .ConstructUsing(c => new RegisterNewProcedimentoTipoCommand(c.Sigla.Trim(), c.Descricao.Trim()));
            CreateMap<ProcedimentoTipoViewModel, UpdateProcedimentoTipoCommand>()
                .ConstructUsing(c => new UpdateProcedimentoTipoCommand(c.Id, c.Sigla.Trim(), c.Descricao.Trim()));
            CreateMap<VitimaViewModel, RegisterNewVitimaCommand>()
                .ConstructUsing(v => new RegisterNewVitimaCommand(v.Email.Trim(), v.ProcedimentoId,
                                     v.Nome.Trim(), v.NomePai.Trim(), v.NomeMae.Trim(), v.DataNascimento, v.Idade, v.Telefone.Trim(), v.MunicipioId));
            CreateMap<VitimaViewModel, UpdateVitimaCommand>()
                .ConstructUsing(v => new UpdateVitimaCommand(v.Id, v.Email.Trim(), v.ProcedimentoId,
                                     v.Nome.Trim(), v.NomePai.Trim(), v.NomeMae.Trim(), v.DataNascimento, v.Idade, v.Telefone.Trim(), v.MunicipioId));
            CreateMap<ProcedimentoViewModel, RegisterNewProcedimentoCommand>().
                ConstructUsing(p => new RegisterNewProcedimentoCommand(p.BoletimUnificado.Trim(),
                                                                       p.BoletimOcorrencia.Trim(),
                                                                       p.NumeroProcessual.Trim(),
                                                                       (string.IsNullOrEmpty(p.Gampes) ? p.Gampes : p.Gampes.Trim()),
                                                                       (string.IsNullOrEmpty(p.Anexos) ? p.Anexos : p.Anexos.Trim()),
                                                                       (string.IsNullOrEmpty(p.LocalFato) ? p.LocalFato : p.LocalFato.Trim()),
                                                                       p.DataFato,
                                                                       p.DataInstauracao,
                                                                       (string.IsNullOrEmpty(p.TipoCriminal) ? p.TipoCriminal : p.TipoCriminal.Trim()),
                                                                       (string.IsNullOrEmpty(p.AndamentoProcessual) ? p.AndamentoProcessual : p.AndamentoProcessual.Trim()),
                                                                       p.TipoProcedimentoId,
                                                                       p.VaraCriminalId,
                                                                       p.ComarcaId,
                                                                       p.AssuntoId,
                                                                       p.ArtigoId,
                                                                       p.DelegaciaOrigemId));
            CreateMap<ProcedimentoViewModel, UpdateProcedimentoCommand>().
                ConstructUsing(p => new UpdateProcedimentoCommand(p.Id,
                                                                  p.BoletimUnificado.Trim(),
                                                                  p.BoletimOcorrencia.Trim(),
                                                                  p.NumeroProcessual.Trim(),
                                                                  p.Gampes.Trim(),
                                                                  p.Anexos.Trim(),
                                                                  p.LocalFato.Trim(),
                                                                  p.DataFato,
                                                                  p.DataInstauracao,
                                                                  p.TipoCriminal.Trim(),
                                                                  p.AndamentoProcessual.Trim(),
                                                                  p.TipoProcedimentoId,
                                                                  p.VaraCriminalId,
                                                                  p.ComarcaId,
                                                                  p.AssuntoId,
                                                                  p.ArtigoId,
                                                                  p.DelegaciaOrigemId));
            CreateMap<AssuntoViewModel, RegisterNewAssuntoCommand>()
                .ConstructUsing(a => new RegisterNewAssuntoCommand(a.Descricao.Trim()));
            CreateMap<AssuntoViewModel, UpdateAssuntoCommand>()
                .ConstructUsing(a => new UpdateAssuntoCommand(a.Id, a.Descricao.Trim()));
            CreateMap<ArtigoViewModel, RegisterNewArtigoCommand>()
                .ConstructUsing(a => new RegisterNewArtigoCommand(a.Descricao.Trim()));
            CreateMap<AssuntoViewModel, UpdateArtigoCommand>()
                .ConstructUsing(a => new UpdateArtigoCommand(a.Id, a.Descricao.Trim()));
            CreateMap<VaraCriminalCommand, RegisterNewVaraCriminalCommand>()
                .ConstructUsing(a => new RegisterNewVaraCriminalCommand(a.Descricao.Trim()));
            CreateMap<VaraCriminalViewModel, UpdateVaraCriminalCommand>()
                .ConstructUsing(a => new UpdateVaraCriminalCommand(a.Id, a.Descricao.Trim()));
            CreateMap<MunicipioViewModel, RegisterNewMunicipioCommand>()
                .ConstructUsing(m => new RegisterNewMunicipioCommand(m.Nome.Trim(), m.UF.Trim(), m.CEP.Trim()));
            CreateMap<MunicipioViewModel, UpdateMunicipioCommand>()
                .ConstructUsing(m => new UpdateMunicipioCommand(m.Id, m.Nome.Trim(), m.UF.Trim(), m.CEP.Trim()));


        }
    }
}
