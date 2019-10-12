export abstract class Pessoa {

  private dataNascimento: Date;

  id: number;
  nome: string;
  nomePai: string;
  nomeMae: string;
  naturalidadeId: number;
  naturalidade: string;
  email: string;
  telefone: string;
  idade: number;
  procedimentoId: number;

  get DataNascimento() {
    return this.dataNascimento;
  }

  set DataNascimento(value: any) {
    if (value) {
      this.dataNascimento = new Date(value);
    }
  }

  constructor(procedimentoId: number, obj?: any) {
    if (obj) {
      Object.assign(this, obj);
      this.DataNascimento = obj.dataNascimento;
    }
    this.procedimentoId = procedimentoId;
  }
}
