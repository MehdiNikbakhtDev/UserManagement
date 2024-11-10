export class LoginInput {
  username: string;
  password: string;
  constructor() {
    this.username = '';
    this.password = '';
  }
}
export class LoginResult {
  username: string;
  firstname: string;
  lastname: string;
  mobile: string;
  userId: string;
  token: string;
  constructor() {
    this.token = '';
    this.username = '';
    this.firstname = '';
    this.lastname = '';
    this.mobile = '';
    this.userId = '';
  }
}

