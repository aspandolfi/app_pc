export interface Chart {
  title: string;
  yAxisTitle: string;
  categories: string[];
  series: ChartSerie[];
}

export interface ChartSerie {
  name: string;
  data: number[];
}
