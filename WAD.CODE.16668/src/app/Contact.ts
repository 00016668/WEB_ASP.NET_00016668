export interface Contact {
    id: number;
    firstName: string;
    lastName: string;
    phoneNumber: string;
    email: string;
    dateOfBirth: Date;
    groupId: number;
    group?: {
      id: number;
      groupName: string;
    };
  }
  