import { Pessoa } from './pessoa';

export class Indiciado extends Pessoa {

  apelido: string = '';

  constructor(procedimentoId: number, obj?: any) {
    super(procedimentoId, obj);
    if (obj) {
      this.apelido = obj.apelido;
    }
  }
}
