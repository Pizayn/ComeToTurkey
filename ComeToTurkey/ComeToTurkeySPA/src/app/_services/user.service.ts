import { Injectable } from '@angular/core';
import { environment } from 'environments/environment';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { User } from 'app/_models/user';
import { map } from 'rxjs/operators';
import { PaginationResult } from 'app/_models/pagination';
import { Message } from 'app/_models/message';
import { Comment } from 'app/_models/comment';
import { Blog } from 'app/_models/blog';
import { City } from 'app/_models/city';
import { BlogCategory } from 'app/_models/blogcategory';
import { Destination } from 'app/_models/destination';
import { About } from 'app/_models/about';
import { News } from 'app/_models/news';


@Injectable({
  providedIn: 'root'
})
export class UserService {
  baseUrl=environment.apiUrl+'users/'

constructor(private http:HttpClient) { }

getUser(id):Observable<User>{
 return this.http.get<User>(this.baseUrl+id);
}
Upload(userId:number,user:User){
  return this.http.put(this.baseUrl+userId,user)
}
updateUser(id: number, user: User) {
  return this.http.put(this.baseUrl  + id, user);
}
setMainPhoto(userId, photoId) {
  return this.http.post(
    this.baseUrl + userId + "/photos/" + photoId + "/setMain",
    {}
  );
}
DeletePhoto(userId, photoId) {
  return this.http.delete(
    this.baseUrl + userId + "/photos/" + photoId
  );
}
getMessages(id: number, page?, itemsPerPage?, messageContainer?) {
  const paginatedResult: PaginationResult<Message[]> = new PaginationResult<Message[]>();
  let params = new HttpParams();
  params = params.append('MessageContainer', messageContainer);
  if (page != null && itemsPerPage != null) {
    params = params.append('pageNumber', page);
    params = params.append('pageSize', itemsPerPage);
  }
  return this.http.get<Message[]>(this.baseUrl  + id + '/messages', {observe: 'response', params})
    .pipe(
      map(response => {
        paginatedResult.result = response.body;
        if (response.headers.get('Pagination') != null) {
          paginatedResult.pagination = JSON.parse(response.headers.get('Pagination'));
         }
        return paginatedResult;
        }));
}
getMessageThread(id: number, recipientId: number) {
  return this.http.get<Message[]>(this.baseUrl  + id + '/messages/thread/' + recipientId);
}
sendMessage(id: number, message: Message) {
  return this.http.post(this.baseUrl  + id + '/messages', message);
}
deleteMessage(id: number, userId: number) {
  return this.http.post(this.baseUrl  + userId + '/messages/' + id, {});
}
markAsRead(id: number, userId: number) {
  return this.http.post(this.baseUrl  + userId + '/messages/' + id + '/read', {}).subscribe();
}
sendFollow(id:number,recipentId:number){
  return this.http.post(this.baseUrl + id +'/follow/'+recipentId,{});
}
sendUnFollow(id:number,recipentId:number){
  return this.http.delete(this.baseUrl + id +'/unfollow/'+recipentId,{});
}
isFollowing(userId:number,currentUserId:number){
  return this.http.get(this.baseUrl + userId +'/isfollow/'+currentUserId,{});
}



getComments(id: number, page?, itemsPerPage?, blogId?) {
  const paginatedResult: PaginationResult<Comment[]> = new PaginationResult<Comment[]>();
  let params = new HttpParams();
  if (page != null && itemsPerPage != null) {
    params = params.append('pageNumber', page);
    params = params.append('pageSize', itemsPerPage);
    params= params.append("blogId",blogId)
  }
  return this.http.get<Comment[]>(this.baseUrl  + id + '/comments', {observe: 'response', params})
    .pipe(
      map(response => {
        paginatedResult.result = response.body;
        if (response.headers.get('Pagination') != null) {
          paginatedResult.pagination = JSON.parse(response.headers.get('Pagination'));
         }
        return paginatedResult;
        }));
}
sendComment(id: number, comment: Comment) {
  return this.http.post(this.baseUrl  + id + '/comments', comment);
}
deleteComment(userId: number, id: number) {
  return this.http.post(this.baseUrl  + userId + '/comments/' + id, {});
}
createBlog(userId:number,blog:Blog)
{
  return this.http.post(this.baseUrl+userId+'/blogs/',blog);
}
getBlog(userId:number,blogId:number):Observable<Blog>
{
  return this.http.get<Blog>(this.baseUrl+userId+'/blogs/'+blogId)
}
getBlogs(id:number,page?, itemsPerPage?,blogParams?): Observable<PaginationResult<Blog[]>> {
  const paginationResult: PaginationResult<Blog[]> = new PaginationResult<Blog[]>();
  let params = new HttpParams();
  if (page != null && itemsPerPage != null) {
    params = params.append("pageNumber", page);
    params = params.append("pageSize", itemsPerPage);
  }
  if(blogParams!=null)
  {
    params=params.append('blogCategoryId',blogParams.blogCategoryId)
  }
  return this.http.get<Blog[]>(this.baseUrl +id+ '/blogs/' ,{observe:'response',params}).pipe(
    map(response=>{
      paginationResult.result=response.body;         //response body ile verilen parametrelere göre verileri aldık user gelcek apiden
      if(response.headers.get('Pagination')!=null){          //headersdan ise verilen parametrelerin değerlerini aldık page 1 pagesize=3 gibi
        paginationResult.pagination=JSON.parse(response.headers.get('Pagination'))  //jsonu çevirdik
      }
      return paginationResult;
    })
  );
}
getUsers():Observable<User[]>
{
  return this.http.get<User[]>(this.baseUrl);
}

sendLike(userId:number,blogId:number){
  return this.http.post(this.baseUrl + userId +'/blogs/'+blogId+'/like',{});
}
sendUnLike(userId:number,blogId:number){
  return this.http.delete(this.baseUrl + userId +'/blogs/'+blogId+'/unlike',{});
}
getCities():Observable<City[]>
{
  return this.http.get<City[]>(this.baseUrl+"/cities");
}
getBlogCategories():Observable<BlogCategory[]>
{
  return this.http.get<BlogCategory[]>(this.baseUrl+"/blogcategories");
}
getDestinations():Observable<Destination[]>
{
 return this.http.get<Destination[]>(environment.apiUrl+"destinations")
}
getAboutPage():Observable<About>
{
  return this.http.get<About>(environment.apiUrl+"abouts");

}
getNews():Observable<News[]>
{
  return this.http.get<News[]>(this.baseUrl+"news");
}
getPopularBlogs():Observable<Blog[]>
{
  return this.http.get<Blog[]>("http://localhost:49567/api/users/popularblogs");
}


}
