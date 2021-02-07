import { Component, OnInit, Inject, Input } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-view-article',
  templateUrl: './app-view-article.component.html',
  styleUrls: ['./app-view-article.component.scss']
})
export class AppViewArticleComponent implements OnInit {
  
  //private properties
  /*private httpClient: HttpClient;
  private base: string;
  private firstNavigate = true;
  private activeMenu = "";
  private currentRoute = "";*/

  //public properties
  private _type = "";
  @Input() get articleType(): string {
    return this._type;
  }
  set articleType(val: string) {
    this._type = val;
  }

  private _id = "";
  @Input() get articleId(): string {
    return this._id;
  }
  set articleId(val: string) {
    this._id = val;
  }

  private _articleSource = "article";
  @Input() get articleSource(): string {
    return this._articleSource;
  }

  constructor(private route: ActivatedRoute) {
    this.articleType = null;
    this.articleId = null;
    
    this.route.params.subscribe(params => {
      this.articleType = null;
      this.articleId = null;

      this.articleType = params == null || params.type == null || params.type == "undefined" || params.type == "" ? "blog" : params.type;
      this.articleId = params == null || params.id == null ? "" : params.id;
    });
  }

  ngOnInit() {

  }
}
