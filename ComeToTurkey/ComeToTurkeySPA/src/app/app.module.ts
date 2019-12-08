import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';
import {JwtModule} from '@auth0/angular-jwt';

import { AppRoutingModule } from './app.routing';
import { ComponentsModule } from './components/components.module';

import { AppComponent } from './app.component';

import { DashboardComponent } from './dashboard/dashboard.component';
import { UserProfileComponent } from './user-profile/user-profile.component';
import { TableListComponent } from './table-list/table-list.component';
import { TypographyComponent } from './typography/typography.component';
import { IconsComponent } from './icons/icons.component';
import { UpgradeComponent } from './upgrade/upgrade.component';
import {
  AgmCoreModule
} from '@agm/core';
import { AdminLayoutComponent } from './layouts/admin-layout/admin-layout.component';
import { NavComponent } from './start/nav/nav.component';
import { MainComponent } from './start/main/main.component';
import { FooterComponent } from './start/footer/footer.component';
import { BlogComponent } from './blog/blog/blog.component';
import { RegisterComponent } from './account/register/register.component';
import { MatDialogModule, MatFormFieldModule, MatButtonModule, MatInputModule, MatAutocomplete, MatOption, MatAutocompleteModule, MatOptionModule, MatSelectModule, MatIconModule } from '@angular/material';
import { LoginComponent } from './account/login/login.component';
import { BlogDetailComponent } from './blog/blog-detail/blog-detail.component';
import { UserBlogComponent } from './blog/user-blog/user-blog.component';
import { AlertifyService } from './_services/alertify.service';
import { HttpClientModule } from '@angular/common/http';
import { from } from 'rxjs';
import { AuthService } from './_services/auth.service';
import { UserEditComponent } from './user/user-edit/user-edit.component';
import {UserEditResolver } from './_resolvers/user-edit.resolver';
import { TabsModule } from 'ngx-bootstrap/tabs';
import { PhotoEditorComponent } from './user/photo-editor/photo-editor.component';
import { FileUploadModule } from 'ng2-file-upload';
import { BsDatepickerModule } from 'ngx-bootstrap/datepicker';
import { MessagesComponent } from './user/messages/messages.component';
import { MessagesResolver } from './_resolvers/messages.resolver';
import { PaginationModule } from 'ngx-bootstrap/pagination';
import { NgxGalleryModule } from 'ngx-gallery';
import { UserDetailComponent } from './user/user-detail/user-detail.component';
import { UserDetailResolver } from './_resolvers/user-detail.resolver';
import { UserMessagesComponent } from './user/user-messages/user-messages.component';
import { UserService } from './_services/user.service';
import { BlogDetailResolver } from './_resolvers/blog-detail.resolver';
import {TimeAgoPipe} from 'time-ago-pipe';
import { NgxEditorModule } from 'ngx-editor';
import { AddBlogComponent } from './blog/add-blog/add-blog.component';
import { CKEditorModule } from 'ng2-ckeditor';
import { BlogCommentComponent } from './blog/blog-comment/blog-comment.component';
import { CommentResolver } from './_resolvers/comment.resolver';
import { BlogsResolver } from './_resolvers/blogs.resolver';
import { UserSearchComponent } from './user/user-search/user-search.component';
import { DestinationComponent } from './destination/destination/destination.component';
import { AboutComponent } from './start/about/about.component';
import { HomeComponent } from './start/home/home.component';
import { DestinationViewComponent } from './components/destination/destination.component';
import { AdminDashboard } from './_models/admin/admindashboard';
import { AdminDashboardResolver } from './_resolvers/admin-dashboard.resolver';
import { AddNewsComponent } from './icons/add-news/add-news.component';
import { NewsDetailResolver } from './_resolvers/news-detail.resolver';
import { NewsDetailComponent } from './blog/blog/news-detail/news-detail.component';
import { NewsComponent } from './components/news/news.component';
import { PopularUserBlogsComponent } from './components/popular-user-blogs/popular-user-blogs.component';



@NgModule({
   imports: [
      BrowserAnimationsModule,
      FormsModule,
      ReactiveFormsModule,
      HttpModule,
      MatDialogModule,
      ComponentsModule,
      HttpClientModule,
      BsDatepickerModule.forRoot(),
      TabsModule.forRoot(),
      JwtModule,
      MatButtonModule,
      PaginationModule.forRoot(),
      MatInputModule,
      MatFormFieldModule,
      MatAutocompleteModule,
      MatOptionModule,
      NgxEditorModule,
      CKEditorModule,
      NgxGalleryModule,
      MatSelectModule,
      FileUploadModule,
      RouterModule,
      AppRoutingModule,
      MatIconModule,
      AgmCoreModule.forRoot({
        apiKey: 'YOUR_GOOGLE_MAPS_API_KEY'
      })
   ],


  declarations: [
    AppComponent,
    AdminLayoutComponent,
    NavComponent,
    MainComponent,
    FooterComponent,
    BlogComponent,
    LoginComponent,
    RegisterComponent,
    BlogDetailComponent,
    UserBlogComponent,
    UserEditComponent,
    MessagesComponent,
    PhotoEditorComponent,
    UserDetailComponent,
    UserMessagesComponent,
    TimeAgoPipe,
    AddBlogComponent,
    BlogCommentComponent,
    DestinationComponent,
    AboutComponent,
    UserSearchComponent,
    HomeComponent,
    DestinationViewComponent,
    AddNewsComponent,
    NewsDetailComponent,
    NewsComponent,
    PopularUserBlogsComponent,
   

  ],
  entryComponents:[
    RegisterComponent,
    LoginComponent,
    AddBlogComponent,
    AddNewsComponent,


  ],
  providers: [
    AlertifyService,
    AuthService,
    UserEditResolver,
    MessagesResolver,
    UserDetailResolver,
    UserService,
    BlogDetailResolver,
    CommentResolver,
    BlogsResolver,
    AdminDashboard,
    AdminDashboardResolver,
    NewsDetailResolver
  ],

  bootstrap: [AppComponent]
})
export class AppModule { }
