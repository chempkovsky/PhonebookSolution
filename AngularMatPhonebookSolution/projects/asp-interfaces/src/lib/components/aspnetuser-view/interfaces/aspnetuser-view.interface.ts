
export interface IaspnetuserView {
      id: string|null;  // System.String
      email: string|null;  // System.String
      emailConfirmed: boolean|null;  // System.Boolean
      phoneNumber: string|null;  // System.String
      phoneNumberConfirmed: boolean|null;  // System.Boolean
      twoFactorEnabled: boolean|null;  // System.Boolean
      lockoutEnd: number|null;  // System.DateTimeOffset ?
      lockoutEnabled: boolean|null;  // System.Boolean
      accessFailedCount: number|null;  // System.Int32
      userName: string|null;  // System.String
}


