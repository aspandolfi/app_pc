export class Login {
  email: string;
  password: string;
  rememberMe: boolean;
}

export class Authentication {

  private _created: Date;
  private _expiration: Date;

  token: string;

  get created() {
    return this._created;
  }

  set created(date: any) {
    if (date) {
      this._created = new Date(date);
    }
  }

  get expiration() {
    return this._expiration;
  }

  set expiration(date: any) {
    if (date) {
      this._expiration = new Date(date);
    }
  }

  constructor(obj?: any) {
    if (obj) {
      Object.assign(this, obj);
    }
  }
}
