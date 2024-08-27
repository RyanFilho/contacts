export interface IContactModel {
    contactId: number;
    name: string;
    phoneNumber: string;
    saveDate: Date;
    userId: string;
  }
  
  export class ContactModel implements IContactModel {    
    public contactId: number = 0;
    public saveDate: Date = new Date();
  constructor(
    public name: string,
    public phoneNumber: string,    
    public userId: string,  
  ) { }
}