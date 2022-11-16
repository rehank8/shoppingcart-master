export class UserModel {
  id?: string | undefined;
  fkRoleId?: number;
  username?: string | undefined;
  password?: string | undefined;
  phoneNo?: string | undefined;
  emailId?: string | undefined;
  address?: string | undefined;
  ipAddress?: string | undefined;
  isActive?: boolean;
  rememberMe?: boolean;
}
