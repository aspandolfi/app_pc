export class Procedimento {
  id: number;
  numeroCadastro: string;
  numeroProcessual: string;
  tipoProcedimento: string;
  dataInsercao: string;
  situacao: string;
  varaCriminal: string;
}

export interface IProcedimentoViewModel {
  id: number;
  numeroCadastro: string;
  boletimUnificado: string;
  boletimOcorrencia: string;
  numeroProcessual: string;
  tipoProcedimento: string;
  comarca: string;
  andamentoProcessual: string;
}
