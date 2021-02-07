import { Component, OnInit, Inject, Input } from '@angular/core';
import { Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { Article } from '../../models/article';
declare var $: any;

@Component({
  selector: 'app-article-list',
  templateUrl: './app-article-list.component.html',
  styleUrls: ['./app-article-list.component.scss']
})
export class AppArticleListComponent implements OnInit { 

  //private properties
  /*private httpClient: HttpClient;
  private base: string;
  private firstNavigate = true;
  private activeMenu = "";
  private currentRoute = "";*/

  //public properties
  private _articles: Article[];
  @Input() get articles(): Article[] {
    return this._articles;
  }
  set articles(val: Article[]) {
    this._articles = val;
    $("#list .content-main-scroll").scrollTop(0);
  }

  private _activeMenu = "";
  @Input() get activeMenu(): string {
    return this._activeMenu;
  }
  set activeMenu(val: string) {
    this._activeMenu = val;
  }

  @Input() get year(): string {
    return (new Date()).getFullYear().toString();
  }


  constructor(router: Router, http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    
  }


  ngOnInit() {

  }
}
