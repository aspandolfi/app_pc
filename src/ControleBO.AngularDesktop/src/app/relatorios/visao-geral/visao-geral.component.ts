import { Component, OnInit } from '@angular/core';
import * as  Highcharts from 'highcharts';
import * as HighchartsExporting from 'highcharts/modules/exporting';
import * as $ from 'jquery';
import { RelatorioService } from 'src/app/services/relatorio.service';

HighchartsExporting.default(Highcharts);

@Component({
  selector: 'app-visao-geral',
  templateUrl: './visao-geral.component.html',
  styleUrls: ['./visao-geral.component.scss']
})
export class VisaoGeralComponent implements OnInit {

  public options: any = {
    chart: {
      type: 'scatter',
      //height: 700
    },
    title: {
      text: 'Sample Scatter Plot'
    },
    credits: {
      enabled: false
    },
    tooltip: {
      formatter: function () {
        return 'x: ' + Highcharts.dateFormat('%e %b %y %H:%M:%S', this.x) +
          ' y: ' + this.y.toFixed(2);
      }
    },
    xAxis: {
      type: 'datetime',
      labels: {
        formatter: function () {
          return Highcharts.dateFormat('%e %b %y', this.value);
        }
      }
    },
    series: []
  };

  optionsPie: any = {
    chart: {
      plotBackgroundColor: null,
      plotBorderWidth: null,
      plotShadow: false,
      type: 'pie'
    },
    title: {
      text: 'Browser market shares in January, 2018'
    },
    tooltip: {
      pointFormat: '{series.name}: <b>{point.percentage:.1f}%</b>'
    },
    exporting: {
      buttons: {
        contextButton: {
          menuItems: ['printChart']
        }
      }
    },
    plotOptions: {
      pie: {
        allowPointSelect: true,
        cursor: 'pointer',
        dataLabels: {
          enabled: true,
          format: '<b>{point.name}</b>: {point.percentage:.1f} %<br>Total: {point.y}'
        }
      }
    },
    series: [{
      name: '',
      colorByPoint: true,
      data: [{
        name: 'Chrome',
        y: 61.41,
      }, {
        name: 'Internet Explorer',
        y: 11.84
      }, {
        name: 'Firefox',
        y: 10.85
      }, {
        name: 'Edge',
        y: 4.67
      }, {
        name: 'Safari',
        y: 4.18
      }, {
        name: 'Sogou Explorer',
        y: 1.64
      }, {
        name: 'Opera',
        y: 1.6
      }, {
        name: 'QQ',
        y: 1.2
      }, {
        name: 'Other',
        y: 2.61
      }]
    }]
  }

  optionsColumn: any = {
    chart: {
      type: 'column'
    },
    title: {
      text: ''
    },
    xAxis: {
      categories: []
    },
    yAxis: {
      min: 0,
      allowDecimals: false,
      title: {
        text: ''
      },
      stackLabels: {
        enabled: true,
        style: {
          fontWeight: 'bold',
          color: ( // theme
            Highcharts.defaultOptions.title.style &&
            Highcharts.defaultOptions.title.style.color
          ) || 'gray'
        }
      }
    },
    legend: {
      align: 'right',
      x: -30,
      verticalAlign: 'top',
      y: 25,
      floating: true,
      backgroundColor:
        Highcharts.defaultOptions.legend.backgroundColor || 'white',
      borderColor: '#CCC',
      borderWidth: 1,
      shadow: false
    },
    tooltip: {
      headerFormat: '<b>{point.x}</b><br/>',
      pointFormat: '{series.name}: {point.y}<br/>Total: {point.stackTotal}'
    },
    plotOptions: {
      column: {
        stacking: 'normal',
        dataLabels: {
          enabled: true
        }
      }
    },
    series: []
  };

  chartEstatisticaAssunto: Highcharts.Chart;
  chartRelacaoProcedimentos: Highcharts.Chart;
  chartRelacaoVitimas: Highcharts.Chart;
  chartRelacaoIndiciados: Highcharts.Chart;

  constructor(private relatorioService: RelatorioService) { }

  ngOnInit() {

    Highcharts.setOptions({
      lang: {
        printChart: 'Imprimir',
        loading: 'Carregando...',
        noData: 'Sem dados',
        contextButtonTitle: 'Menu do Gráfico'
      },
      credits: {
        enabled: false
      },
      exporting: {
        buttons: {
          contextButton: {
            menuItems: ['printChart']
          }
        }
      }
    });

    this.chartEstatisticaAssunto = Highcharts.chart('myChart', this.optionsColumn);
    this.chartRelacaoProcedimentos = Highcharts.chart('myChart1', this.optionsPie);
    this.chartRelacaoIndiciados = Highcharts.chart('myChart2', this.optionsColumn);
    this.chartRelacaoVitimas = Highcharts.chart('myChart3', this.optionsColumn);

    this.getEstatisticaAssunto();
    this.getRelacaoProcedimentos();
    this.getRelacaoIndiciados();
    this.getRelacaoVitimas();
  }

  private getRelacaoProcedimentos() {

    this.chartRelacaoProcedimentos.showLoading();

    this.relatorioService.getRelacaoProcedimentoChart().subscribe(res => {
      if (res.success) {
        let options1: any = {
          title: {
            text: res.data.title
          },
          series: res.data.series
        };
        this.chartRelacaoProcedimentos.update(options1, true, true, true);
      }
    }).add(() => setTimeout(() => this.chartRelacaoProcedimentos.hideLoading(), 200));
  }

  private getEstatisticaAssunto() {

    this.chartEstatisticaAssunto.showLoading();

    this.relatorioService.getEstatisticaAssuntoChart().subscribe(res => {
      if (res.success) {
        let options: any = {
          title: {
            text: res.data.title
          },
          xAxis: {
            categories: res.data.categories
          },
          yAxis: {
            title: {
              text: res.data.yAxisTitle
            }
          },
          series: res.data.series
        };
        this.chartEstatisticaAssunto.update(options, true, true, true);
      }
    }).add(() => setTimeout(() => this.chartEstatisticaAssunto.hideLoading(), 200));
  }

  private getRelacaoIndiciados() {

    this.chartRelacaoIndiciados.showLoading();

    this.relatorioService.getRelacaoIndiciadosChart().subscribe(res => {
      if (res.success) {
        let options: any = {
          title: {
            text: res.data.title
          },
          xAxis: {
            categories: res.data.categories
          },
          yAxis: {
            title: {
              text: res.data.yAxisTitle
            }
          },
          series: res.data.series
        };
        this.chartRelacaoIndiciados.update(options, true, true, true);
      }
    }).add(() => setTimeout(() => this.chartRelacaoIndiciados.hideLoading(), 200));
  }

  private getRelacaoVitimas() {

    this.chartRelacaoVitimas.showLoading();

    this.relatorioService.getRelacaoVitimasChart().subscribe(res => {
      if (res.success) {
        let options: any = {
          title: {
            text: res.data.title
          },
          xAxis: {
            categories: res.data.categories
          },
          yAxis: {
            title: {
              text: res.data.yAxisTitle
            }
          },
          series: res.data.series
        };
        this.chartRelacaoVitimas.update(options, true, true, true);
      }
    }).add(() => setTimeout(() => this.chartRelacaoVitimas.hideLoading(), 200));
  }
}
