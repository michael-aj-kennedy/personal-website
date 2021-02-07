import { Component, OnInit, Inject, Input } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-view-cv',
  templateUrl: './app-view-cv.component.html',
  styleUrls: ['./app-view-cv.component.scss']
})
export class AppViewCvComponent implements OnInit {
  
  //private properties
  /*private httpClient: HttpClient;
  private base: string;
  private firstNavigate = true;
  private activeMenu = "";
  private currentRoute = "";*/

  //public properties
  //public properties
  private _type = "cv";
  @Input() get articleType(): string {
    return this._type;
  }

  private _id = "";
  @Input() get articleId(): string {
    return this._id;
  }
  set articleId(val: string) {
    this._id = val;
  }

  private _articleSource = "cv";
  @Input() get articleSource(): string {
    return this._articleSource;
  }

  constructor(private route: ActivatedRoute) {
    this.articleId = null;
    this.route.params.subscribe(params => {
      this.articleId = params == null || params.id == null ? "" : params.id;
    });
  }


  ngOnInit() {

  }
}
