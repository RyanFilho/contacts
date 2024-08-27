export interface IUserModel {
  userId: number | undefined;
  displayName: string;
  userName: string;  
  adObjId: string;
  saveDate: Date | undefined;
}

export class UserModel implements IUserModel {
    public userId: number | undefined;
    public saveDate: Date | undefined;
  constructor(    
    public displayName: string,
    public userName: string,
    public adObjId: string,    
  ) { }
}