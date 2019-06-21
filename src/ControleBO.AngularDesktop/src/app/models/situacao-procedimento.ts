export class SituacaoProcedimento {

  private dataRelatorio?: Date;

  id: number;
  observacao: string;
  procedimentoId: number;
  situacaoId: number;
  situacaoTipoId?: number;

  get DataRelatorio() {
    return this.dataRelatorio;
  }

  set DataRelatorio(value: any) {
    if (value) {
      this.dataRelatorio = new Date(value);
    }
  }

  constructor(obj: any) {
    if (obj) {
      Object.assign(this, obj);
      this.DataRelatorio = obj.dataRelatorio;
    }
  }
}
