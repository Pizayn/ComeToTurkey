import { Routes, RouterModule } from '@angular/router';
import { DestinationComponent } from 'app/destination/destination/destination.component';
import { BlogComponent } from 'app/blog/blog/blog.component';
import { BlogDetailComponent } from 'app/blog/blog-detail/blog-detail.component';
import { CommentResolver } from 'app/_resolvers/comment.resolver';
import { BlogDetailResolver } from 'app/_resolvers/blog-detail.resolver';
import { BlogsResolver } from 'app/_resolvers/blogs.resolver';
import { UserBlogComponent } from 'app/blog/user-blog/user-blog.component';
import { UserEditComponent } from 'app/user/user-edit/user-edit.component';
import { RegisterComponent } from 'app/account/register/register.component';
import { UserEditResolver } from 'app/_resolvers/user-edit.resolver';
import { UserDetailComponent } from 'app/user/user-detail/user-detail.component';
import { MessagesResolver } from 'app/_resolvers/messages.resolver';
import { MessagesComponent } from 'app/user/messages/messages.component';
import { AddBlogComponent } from 'app/blog/add-blog/add-blog.component';
import { UserDetailResolver } from 'app/_resolvers/user-detail.resolver';
import { AboutComponent } from '../about/about.component';
import { HomeComponent } from '../home/home.component';
import { NewsDetailComponent } from 'app/blog/blog/news-detail/news-detail.component';
import { NewsDetailResolver } from 'app/_resolvers/news-detail.resolver';

export const MainRoutes: Routes = [
  {path: 'destination', component: DestinationComponent},
  {path:'',component:HomeComponent,redirectTo:'',pathMatch:'full'},
  {path:'news',component:BlogComponent},
  {path:'blogdetail/:id',component:BlogDetailComponent,resolve:{comments:CommentResolver,blog:BlogDetailResolver}},
  {path:'news/:id',component:NewsDetailComponent,resolve:{news:NewsDetailResolver}},
  {path:'userblog',component:UserBlogComponent,resolve:{blogs:BlogsResolver}},
  {path:'register',component:RegisterComponent},
  {path:'user/edit',component:UserEditComponent,resolve:{user:UserEditResolver}},
  {path: 'messages', component: MessagesComponent,resolve:{messages:MessagesResolver}},
  {path: 'user/:id', component: UserDetailComponent,resolve:{user:UserDetailResolver}},
  {path: 'blog/add', component: AddBlogComponent},
  {path: 'about', component: AboutComponent},

  
];


