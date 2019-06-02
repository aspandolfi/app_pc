import { Result } from './result';

export interface IMessage {
  text: string,
  data?: any;
  isError: boolean;
  errors: string[];
  action: Action;
}

export class Message implements IMessage {
  text: string;
  data?: any;
  isError: boolean;
  errors: string[];
  action: Action;

  constructor(result: Result<any>, action?: Action) {
    this.text = result.message;
    this.data = result.data;
    this.isError = !result.success;
    this.errors = result.errors;
    this.action = action;
  }
}

export enum Action {
  Created,
  Updated,
  Removed
}
