export class LoginInput {
  email: string;
  password: string;
  constructor() {
    this.email = '';
    this.password = '';
  }
}
export class LoginResult {
  id:number;
  email: string;
  name: string;
  status: string;
  token: string;
  isHauptUser: boolean;
  lastUpdateDateTime: string;
  constructor() {
    this.token = '';
    this.id = 0;
    this.email = '';
    this.name = '';
    this.status = '';
    this.isHauptUser = false;
    this.lastUpdateDateTime = '';

  }
}

export class ConfirmUserInput {
  runGuid: string;
  password: string;
  constructor() {
    this.runGuid = '';
    this.password = '';
  }
}
export class RegistrierUserInput {
  email: string;
  name: string;
  constructor() {
    this.email = '';
    this.name = '';
  }
}