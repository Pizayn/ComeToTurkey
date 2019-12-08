import { BlogCategoryToReturns } from "./blogCategoryToReturns";
import { Team } from "../team";
import { User } from "../user";
import { Blog } from "../blog";
import { News } from "../news";
import { Destination } from "../destination";


export class AdminDashboard {
    messageCount: number;
    followerCount: number;
    userCount: number;
    blogCount: number;
    likeCount:number;
    commentCount: number;
    photoCount:number;
    destinationCount:number;
    teams:Team[];
    blogCategoryToReturns:BlogCategoryToReturns[];
    numbers:number[];
    strings:string[];
    users:User[];
    blogs:Blog[];
    news:News[];
    destinations:Destination[];

}
