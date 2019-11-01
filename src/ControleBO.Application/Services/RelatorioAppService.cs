using AutoMapper;
using ControleBO.Application.Interfaces;
using ControleBO.Application.ViewModels;
using ControleBO.Domain.Core.Bus;
using ControleBO.Domain.DataObjects;
using ControleBO.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace ControleBO.Application.Services
{
    public class RelatorioAppService : IRelatorioAppService
    {
        private readonly IMapper Mapper;
        private readonly IMediatorHandler Bus;
        private readonly IRelatorioRepository _relatorioRepository;

        public RelatorioAppService(IRelatorioRepository relatorioRepository,
                                   IMapper mapper,
                                   IMediatorHandler bus)
        {
            Mapper = mapper;
            Bus = bus;
            _relatorioRepository = relatorioRepository;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public DataTableViewModel GetEstatisticaAssunto(DateTime? de, DateTime? ate)
        {
            var result = _relatorioRepository.GetEstatisticaAssunto(de, ate);

            var dt = new DataTableObject();

            dt.AddHeaders("Delitos", "Em Andamento", "Na Justiça", "Relatado", "Outra UniPol", "Total");

            dt.AddDataSet(result.Select(x => new Collection<object>
            {
                x.Assunto,
                x.EmAndamento,
                x.NaJustica,
                x.Relatado,
                x.OutraUniPol,
                x.Total
            }));

            return Mapper.Map<DataTableViewModel>(dt);
        }

        public ChartViewModel GetEstatisticaAssuntoChart()
        {
            var result = _relatorioRepository.GetEstatisticaAssunto().OrderBy(x => x.Assunto);

            var seriesEmAndamento = result.Select(x => x.EmAndamento);
            var seriesNaJustica = result.Select(x => x.NaJustica);
            var seriesRelatado = result.Select(x => x.Relatado);
            var seriesOutro = result.Select(x => x.Outro);

            var charVm = new ChartViewModel
            {
                YAxisTitle = "Número de Procedimentos"
            };

            var series = new List<ChartViewModel.ChartSerieViewModel>
            {
                new ChartViewModel.ChartSerieViewModel
                {
                    Name = "Em andamento",
                    Data = seriesEmAndamento.Cast<dynamic>()
                },
                new ChartViewModel.ChartSerieViewModel
                {
                    Name = "Na justiça",
                    Data = seriesNaJustica.Cast<dynamic>()
                },
                new ChartViewModel.ChartSerieViewModel
                {
                    Name = "Relatado",
                    Data = seriesRelatado.Cast<dynamic>()
                },
                new ChartViewModel.ChartSerieViewModel
                {
                    Name = "Outro",
                    Data = seriesOutro.Cast<dynamic>()
                }
            };

            charVm.Title = "Estatística por Assunto";
            charVm.XAxisCategories = result.Select(x => x.Assunto);
            charVm.Series = series;

            return charVm;
        }

        public DataTableViewModel GetRelacaoIndiciados()
        {
            var result = _relatorioRepository.GetRelacaoIndiciados();

            var dt = new DataTableObject();

            dt.AddHeaders("Investigado",
                "Proced. n°",
                "Artigo",
                "Tipo de Procedimento",
                "Situação");

            dt.AddDataSet(result.Select(x => new Collection<object>
            {
                x.Investigado,
                x.NumeroProcedimento,
                x.Artigo,
                x.TipoProcedimento,
                x.SituacaoAtual
            }));

            return Mapper.Map<DataTableViewModel>(dt);
        }

        public ChartViewModel GetRelacaoIndiciadosChart()
        {
            var result = _relatorioRepository.GetRelacaoIndiciados();

            var grouped = result.GroupBy(x => x.TipoProcedimento);

            var categories = grouped.Select(x => x.Key);

            var seriesEmAndamento = grouped.Select(x => x.Count(y => y.SituacaoAtualId == 1));
            var seriesNaJustica = grouped.Select(x => x.Count(y => y.SituacaoAtualId == 2));
            var seriesRelatado = grouped.Select(x => x.Count(y => y.SituacaoAtualId == 3));
            var seriesOutro = grouped.Select(x => x.Count(y => y.SituacaoAtualId == 4));

            var charVm = new ChartViewModel
            {
                YAxisTitle = "Número de Indiciados"
            };

            var series = new List<ChartViewModel.ChartSerieViewModel>
            {
                new ChartViewModel.ChartSerieViewModel
                {
                    Name = "Em andamento",
                    Data = seriesEmAndamento.Cast<dynamic>()
                },
                new ChartViewModel.ChartSerieViewModel
                {
                    Name = "Na justiça",
                    Data = seriesNaJustica.Cast<dynamic>()
                },
                new ChartViewModel.ChartSerieViewModel
                {
                    Name = "Relatado",
                    Data = seriesRelatado.Cast<dynamic>()
                },
                new ChartViewModel.ChartSerieViewModel
                {
                    Name = "Outro",
                    Data = seriesOutro.Cast<dynamic>()
                }
            };

            charVm.Title = "Relação de Indiciados";
            charVm.XAxisCategories = categories;
            charVm.Series = series;

            return charVm;
        }

        public ChartViewModel GetRelacaoProcedimentoChart()
        {
            var result = _relatorioRepository.GetRelacaoProcedimentoPorSituacao();

            var dataPie = result.Select(x => new ChartViewModel.ChartSerieViewModel.ChartPieData
            {
                Name = x.Situacao,
                Y = x.Count
            });

            var series = new List<ChartViewModel.ChartSerieViewModel>
            {
                new ChartViewModel.ChartSerieViewModel
                {
                    Name = "Situação",
                    ColorByPoint = true,
                    Data = dataPie
                }
            };

            var chartVm = new ChartViewModel
            {
                Title = "Procedimentos por Situação",
                Series = series
            };

            return chartVm;
        }

        public DataTableViewModel GetRelacaoProcedimentos(int? situacaoId, DateTime? de, DateTime? ate)
        {
            var result = _relatorioRepository.GetRelacaoProcedimentos(situacaoId, de, ate);

            var dt = new DataTableObject();

            dt.AddHeaders("Proced n°",
                "Boletim de Ocorrência",
                "Artigo",
                "Indiciados",
                "Unidade Policial",
                "Data do Fato",
                "Instauração",
                "Situação",
                "Observação");

            dt.AddDataSet(result.Select(x => new Collection<object>
            {
                x.NumeroProcedimento,
                x.BoletimOcorrencia,
                x.Artigo,
                x.Indiciados,
                x.UnidadePolicial,
                x.DataFato?.ToString("dd/MM/yyyy"),
                x.Instauracao?.ToString("dd/MM/yyyy"),
                x.Situacao,
                x.Observacao
            }));

            return Mapper.Map<DataTableViewModel>(dt);
        }

        public DataTableViewModel GetRelacaoVitimas()
        {
            var result = _relatorioRepository.GetRelacaoVitimas();

            var dt = new DataTableObject();

            dt.AddHeaders("Vítima",
                "Proced. n°",
                "Artigo",
                "Tipo de Procedimento",
                "Situação");

            dt.AddDataSet(result.Select(x => new Collection<object>
            {
                x.Vitima,
                x.NumeroProcedimento,
                x.Artigo,
                x.TipoProcedimento,
                x.SituacaoAtual
            }));

            return Mapper.Map<DataTableViewModel>(dt);
        }

        public ChartViewModel GetRelacaoVitimasChart()
        {
            var result = _relatorioRepository.GetRelacaoVitimas();

            var grouped = result.GroupBy(x => x.TipoProcedimento);

            var categories = grouped.Select(x => x.Key);

            var seriesEmAndamento = grouped.Select(x => x.Count(y => y.SituacaoAtualId == 1));
            var seriesNaJustica = grouped.Select(x => x.Count(y => y.SituacaoAtualId == 2));
            var seriesRelatado = grouped.Select(x => x.Count(y => y.SituacaoAtualId == 3));
            var seriesOutro = grouped.Select(x => x.Count(y => y.SituacaoAtualId == 4));

            var charVm = new ChartViewModel
            {
                YAxisTitle = "Número de Vítimas"
            };

            var series = new List<ChartViewModel.ChartSerieViewModel>
            {
                new ChartViewModel.ChartSerieViewModel
                {
                    Name = "Em andamento",
                    Data = seriesEmAndamento.Cast<dynamic>()
                },
                new ChartViewModel.ChartSerieViewModel
                {
                    Name = "Na justiça",
                    Data = seriesNaJustica.Cast<dynamic>()
                },
                new ChartViewModel.ChartSerieViewModel
                {
                    Name = "Relatado",
                    Data = seriesRelatado.Cast<dynamic>()
                },
                new ChartViewModel.ChartSerieViewModel
                {
                    Name = "Outro",
                    Data = seriesOutro.Cast<dynamic>()
                }
            };

            charVm.Title = "Relação de Vítimas";
            charVm.XAxisCategories = categories;
            charVm.Series = series;

            return charVm;
        }
    }
}
