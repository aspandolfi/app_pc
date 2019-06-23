export class Movimentacao {
  id: number;
  destino: string;
  data: Date;
  retornouEm?: Date;
  procedimentoId: number;

  constructor(procedimentoId?: number) {
    this.data = new Date();
    this.procedimentoId = procedimentoId;
  }
}
