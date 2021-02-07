import { Component, OnInit, Inject, Input } from '@angular/core';
import { Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-view-about',
  templateUrl: './app-view-about.component.html',
  styleUrls: ['./app-view-about.component.scss']
})
export class AppViewAboutComponent implements OnInit {
  
  //private properties
  /*private httpClient: HttpClient;
  private base: string;
  private firstNavigate = true;
  private activeMenu = "";
  private currentRoute = "";*/

  //public properties
  //public properties
  private _type = "blog";
  @Input() get articleType(): string {
    return this._type;
  }

  private _id = "-1";
  @Input() get articleId(): string {
    return this._id;
  }

  private _articleSource = "about";
  @Input() get articleSource(): string {
    return this._articleSource;
  }

  constructor(router: Router, http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    
  }


  ngOnInit() {

  }
}
