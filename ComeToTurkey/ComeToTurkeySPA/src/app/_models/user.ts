import { Photo } from "./photo";
import { Follow } from "./follow";

export class User {
    firstName: string;
    lastName:string;
    username: string;
    id: number;
    gender: string;
    photoUrl:string;
    countryId: string;
    email:string;
    aboutMe:string;
    status:string;
    dateofbirth: Date;
    age:number;
    created:Date;
    password: string;
    followers:Follow[];
    photos?: Photo[];
}
