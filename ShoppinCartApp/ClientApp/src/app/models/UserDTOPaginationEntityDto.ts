import { UserModel } from "./UserModel";

export class UserDTOPaginationEntityDto {
  entities?: UserModel[] | null;
  count?: number;
}
