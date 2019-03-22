export interface Result<T extends any> {
  success: boolean;
  data: T;
  message: string;
  errors: string[];
}
