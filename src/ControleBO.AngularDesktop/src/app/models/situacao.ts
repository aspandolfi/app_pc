import { TipoSituacao } from './tipo-situacao';

export class Situacao {

  static readonly NaDelegacia: string = 'NaDelegacia';
  static readonly NaJustica: string = 'NaJustica';
  static readonly Relatado: string = 'Relatado';
  static readonly Outros: string = 'Outros';

  id: number;
  codigo: string = Situacao.NaDelegacia;
  descricao?: string;
  tipos?: TipoSituacao[];
}
