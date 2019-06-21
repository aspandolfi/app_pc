export class Movimentacao {
  id: number;
  destino: string;
  data: Date;
  retornouEm?: Date;

  constructor() {
    this.data = new Date();
  }
}
