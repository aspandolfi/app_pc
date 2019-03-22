export interface IMessage {
  text: string,
  data?: any;
  isError: boolean;
}

export class Message implements IMessage {
  text: string;
  data?: any;
  isError: boolean;

  constructor(text: string, data?: any, isError: boolean = false) {
    this.text = text;
    this.data = data;
    this.isError = isError;
  }
}
