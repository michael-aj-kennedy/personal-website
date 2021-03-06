import { Component, OnInit, Inject, Input } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-view-cv',
  templateUrl: './app-page-not-found.component.html',
  styleUrls: ['./app-page-not-found.component.scss']
})
export class AppPageNotFoundComponent implements OnInit {
  
  private _type = "blog";
  @Input() get articleType(): string {
    return this._type;
  }

  private _id = "-2";
  @Input() get articleId(): string {
    return this._id;
  }

  private _articleSource = "blog";
  @Input() get articleSource(): string {
    return this._articleSource;
  }

  @Input() get wordpress404(): boolean {
    return window.location.href.indexOf("/wp") > 0 || window.location.href.indexOf("/wordpress") > 0;
  }
  
  constructor(private route: ActivatedRoute) {


    
  }


  ngOnInit() {

  }
}
