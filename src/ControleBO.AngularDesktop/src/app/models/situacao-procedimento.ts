export class SituacaoProcedimento {
  id: number;
  dataRelatorio?: Date;
  observacao: string;
  procedimentoId: number;
  situacaoId: number;
  situacaoTipoId?: number;

  constructor(obj: object) {
    if (obj) {
      Object.assign(this, obj);
    }
  }
}
