import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { Pagination, PaginationResult } from 'app/_models/pagination';
import { UserService } from 'app/_services/user.service';
import { AuthService } from 'app/_services/auth.service';
import { AlertifyService } from 'app/_services/alertify.service';
import { ActivatedRoute} from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Follow } from 'app/_models/follow';
import { Comment } from 'app/_models/comment';

@Component({
  selector: 'app-blog-comment',
  templateUrl: './blog-comment.component.html',
  styleUrls: ['./blog-comment.component.scss']
})
export class BlogCommentComponent implements OnInit {
  newMessage:any={};
  public commentForm:FormGroup;
  currentBlogId:number;
  @Input() comments:Comment[];
  @Input() pagination:Pagination;
  @Input() commentCount:number;
  @Output() public commentCounts=new EventEmitter();
  constructor(private userService: UserService, private authService: AuthService,
    private route: ActivatedRoute, private alertify: AlertifyService,private fb:FormBuilder) { }
  
    ngOnInit() {
  
     
      this.route.params.subscribe(params=> {
        this.currentBlogId=params['id']
      })
      this.createForm();
    


    }
    createForm() {
      this.commentForm=this.fb.group(
        {
          comment:['',Validators.required],
  
        }
        )
  
    }
    loadMessages() {
      this.userService.getComments(this.authService.decodedToken.nameid, this.pagination.currentPage,
            this.pagination.itemsPerPage,this.currentBlogId)
            .subscribe( (res: PaginationResult<Comment[]>) => {
                this.comments = res.result;
                this.pagination = res.pagination;
            }, error => {
              this.alertify.error(error);
            });
    }
    pageChanged(event: any): void {
      this.pagination.currentPage = event.page;
      this.loadMessages();
    }
  
    sendComment() {
      this.newMessage.recipientId =this.currentBlogId;
      this.userService.sendComment(this.authService.decodedToken.nameid, this.newMessage)
                  .subscribe((res: Comment) => {
                    this.comments.unshift(res);
                    this.commentForm.reset();
                    this.commentCount= this.commentCount+1;
                    this.commentCounts.emit(this.commentCount)
  
                  }, error => {
                    this.alertify.error(error.error);
                  });
    }
    isme(senderId:any) {
      if(senderId == this.authService.decodedToken.nameid) {
        return true;
      }
     return false;
  
  
    }
    deleteComment(id: number) {
      this.alertify.confirm('Are you sure you want to delete this message?', () => {
        this.userService.deleteComment(this.authService.decodedToken.nameid,id).subscribe( () => {
          this.comments.splice(this.comments.findIndex(m => m.id === id), 1);
          this.alertify.success('Message has been deleted');
          this.commentCount= this.commentCount-1;
          this.commentCounts.emit(this.commentCount);
        }, error => {
          this.alertify.error('Failed to delete the message');
        });
      });
    }
  

}
