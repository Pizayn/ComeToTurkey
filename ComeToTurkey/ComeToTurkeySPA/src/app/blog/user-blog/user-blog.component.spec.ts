/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { UserBlogComponent } from './user-blog.component';

describe('UserBlogComponent', () => {
  let component: UserBlogComponent;
  let fixture: ComponentFixture<UserBlogComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ UserBlogComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(UserBlogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
