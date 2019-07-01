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
}

export class RegisterUsuario extends UsuarioBase {
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
