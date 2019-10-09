export class Pessoa {
  id: number;
  nome: string;
  nomePai: string;
  nomeMae: string;
  naturalidadeId: number;
  dataNascimento: Date;
  email: string;
  telefone: string;
  idade: number;
  procedimentoId: number;

  constructor(procedimentoId: number) {
    this.procedimentoId = procedimentoId;
  }
}
