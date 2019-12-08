import { NgModule } from '@angular/core';
import { CommonModule, } from '@angular/common';
import { BrowserModule  } from '@angular/platform-browser';
import { Routes, RouterModule } from '@angular/router';

import { AdminLayoutComponent } from './layouts/admin-layout/admin-layout.component';
import { HomeComponent } from './home/home.component';
import { MainComponent } from './start/main/main.component';
import { BlogComponent } from './blog/blog/blog.component';
import { BlogDetailComponent } from './blog/blog-detail/blog-detail.component';
import { UserBlogComponent } from './blog/user-blog/user-blog.component';
import { RegisterComponent } from './account/register/register.component';
import { UserEditComponent } from './user/user-edit/user-edit.component';
import { UserEditResolver } from './_resolvers/user-edit.resolver';
import { MessagesComponent } from './user/messages/messages.component';
import { MessagesResolver } from './_resolvers/messages.resolver';
import { UserDetailComponent } from './user/user-detail/user-detail.component';
import { UserDetailResolver } from './_resolvers/user-detail.resolver';
import { BlogDetailResolver } from './_resolvers/blog-detail.resolver';
import { AddBlogComponent } from './blog/add-blog/add-blog.component';
import { CommentResolver } from './_resolvers/comment.resolver';
import { BlogsResolver } from './_resolvers/blogs.resolver';
import { DestinationComponent } from './destination/destination/destination.component';
import { AboutComponent } from './start/about/about.component';
import { MainRoutes } from './start/main/main-routes.routing';
import { AdminDashboardResolver } from './_resolvers/admin-dashboard.resolver';

const routes: Routes =[
 {
    path: 'admin',
    component: AdminLayoutComponent,
    children: [{
      path: '',
      loadChildren: './layouts/admin-layout/admin-layout.module#AdminLayoutModule',
      resolve:{dashboard:AdminDashboardResolver},
    }]
  },
  { path: '', component: MainComponent,  children: MainRoutes },
  









];

@NgModule({
  imports: [
    CommonModule,
    BrowserModule,
    RouterModule.forRoot(routes,{
       useHash: true
    })
  ],
  exports: [
  ],
})
export class AppRoutingModule { }
