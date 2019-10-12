import { Pessoa } from './pessoa';

export class Vitima extends Pessoa {
  constructor(procedimentoId: number, obj?: any) {
    super(procedimentoId, obj);
  }
}
