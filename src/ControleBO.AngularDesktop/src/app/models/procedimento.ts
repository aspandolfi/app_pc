import { UltimaMovimentacao } from './ultima-movimentacao';

export class Procedimento {

  private dataInsercao: Date;
  private dataFato: Date;
  private dataInstauracao: Date;

  id: number;
  boletimUnificado: string;
  boletimOcorrencia: string;
  numeroProcessual: string;
  gampes: string;
  tipoProcedimentoId: number;
  anexos: string;
  localFato: string;
  varaCriminalId: number;
  comarcaId: number;
  assuntoId: number;
  artigoId: number;
  delegaciaId: number;
  situacao: string;
  ultimasMovimentacoes: UltimaMovimentacao[];

  set DataInsercao(value: any) {
    if (value) {
      this.dataInsercao = new Date(value);
    }
  }

  get DataInsercao() {
    return this.dataInsercao;
  }

  set DataFato(value: any) {
    if (value) {
      this.dataFato = new Date(value);
    }
  }

  get DataFato() {
    return this.dataFato;
  }

  set DataInstauracao(value: any) {
    if (value) {
      this.dataInstauracao = new Date(value);
    }
  }

  get DataInstauracao() {
    return this.dataInstauracao;
  }

  constructor(obj?: any) {
    Object.assign(this, obj);
  }

}

export class ProcedimentoList {
  id: number;
  numeroCadastro: string;
  boletimUnificado: string;
  boletimOcorrencia: string;
  numeroProcessual: string;
  tipoProcedimento: string;
  dataInsercao: Date;
  comarca: string;
  andamentoProcessual: string;

  constructor(obj?: any) {
    Object.assign(this, obj);
  }
}
