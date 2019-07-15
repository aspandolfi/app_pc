abstract class UsuarioBase {
  id: string = '';
  nome: string = '';
  email: string = '';

  constructor(obj?: any) {
    if (obj) {
      Object.assign(this, obj);
    }
  }
}

export class Usuario extends UsuarioBase {
  regra: string;

  constructor(obj?: any) {
    super(obj);
  }
}

export class RegisterUsuario extends Usuario {
  senhaAtual?: string;
  senha?: string;
  confirmarSenha?: string;

  constructor(obj?: any) {
    super(obj);
  }

  limparSenhas() {
    this.senhaAtual = null;
    this.senha = null;
    this.confirmarSenha = null;
  }
}
