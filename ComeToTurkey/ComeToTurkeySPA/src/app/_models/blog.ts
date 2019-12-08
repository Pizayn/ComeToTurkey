import { Comment } from './comment';
import { BlogCategory } from './blogcategory';
import {BlogLike } from './bloglike';
import { City } from './city';



export interface Blog {
    blogId:number;
    text:string;
    description:string;
    title:string;
    userId:number;
    mainPhotoUrl:string;
    blogCategoryId:number;
    comments:Comment[];
    blogCategory:BlogCategory
    userFirstName:string;
    userLastName:String;
    photoUrl:string;
    city:City;
    createdTime:Date;
    commentsReceivedCount:number;
    blogLikesCount:number;
    blogLikes:BlogLike[];
    cityId:number;
  
}
