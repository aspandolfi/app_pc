import { Vitima } from './vitima';

export class Indiciado extends Vitima {

  apelido: string;

  constructor(procedimentoId: number) {
    super(procedimentoId);
    this.apelido = '';
  }
}
