export interface ResponseModel<DataType extends any> {
    success: boolean;
    data: DataType;
    message: string;
    errors: string[];
}