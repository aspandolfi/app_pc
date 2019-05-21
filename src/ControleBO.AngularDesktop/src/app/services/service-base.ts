export interface IServiceBase<TModel> {
  create(model: TModel);
  update(model: TModel);
  delete(id: number);
  get(id: number);
  getAll();
  getAllPaged(page: number, pageSize: number);
}
