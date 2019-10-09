import { Pessoa } from './pessoa';

export class Indiciado extends Pessoa {

  apelido: string;

  constructor(procedimentoId: number) {
    super(procedimentoId);
    this.apelido = '';
  }
}
