export class ObjetoApreendido {
  id: number;
  descricao: string;
  local?: string;
  dataInsercao: Date = new Date();
  dataApreensao: Date;
  procedimentoId: number;

  get DataInsercao() {
    return this.dataInsercao;
  }

  set DataInsercao(value: any) {
    if (value) {
      this.dataInsercao = new Date(value);
    }
  }

  get DataApreensao() {
    return this.dataApreensao;
  }

  set DataApreensao(value: any) {
    if (value) {
      this.dataApreensao = new Date(value);
    }
  }

  constructor(procedimentoId: number, obj?: any) {
    if (obj) {
      Object.assign(this, obj);
      this.DataApreensao = obj.dataApreensao;
    }
    this.procedimentoId = procedimentoId;
  }
}
