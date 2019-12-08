import { Injectable } from '@angular/core';
import { environment } from 'environments/environment';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { AdminDashboard } from 'app/_models/admin/admindashboard';
import { News } from 'app/_models/news';

@Injectable({
  providedIn: 'root'
})
export class AdminService {
baseUrl=environment.apiUrl;
constructor(private http:HttpClient) { }

getDashBoard():Observable<AdminDashboard>
{
  return this.http.get<AdminDashboard>(this.baseUrl+"admin");

}
createNews(news:News)
{
  return this.http.post(this.baseUrl+'admin',news);
}
getNews(newId:number):Observable<News>
{
  return this.http.get<News>(this.baseUrl+'admin/'+newId)
}

}
