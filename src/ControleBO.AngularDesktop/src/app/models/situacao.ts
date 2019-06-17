import { TipoSituacao } from './tipo-situacao';

export class Situacao {
  id: number;
  descricao?: string;
  tipos?: TipoSituacao[];
}
