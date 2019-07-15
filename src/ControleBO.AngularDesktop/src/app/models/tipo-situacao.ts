export class TipoSituacao {
  id: number;
  descricao: string;
  situacaoId: number;

  constructor(situacaoId?: number) {
    if (situacaoId) {
      this.situacaoId = situacaoId;
    }
  }
}
