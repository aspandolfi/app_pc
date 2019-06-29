class UsuarioBase {
  id: string;
  nome: string;
  email: string;
}

export class Usuario extends UsuarioBase {
  regra: string;
}

export class RegisterUsuario extends UsuarioBase {
  senha: string;
  confirmarSenha: string;
}
