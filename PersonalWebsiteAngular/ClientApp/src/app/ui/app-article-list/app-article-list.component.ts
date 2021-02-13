import { Component, OnInit, Inject, Input, EventEmitter, Output } from '@angular/core';
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
  @Output() updateSidebarVisibility = new EventEmitter<boolean>();

  //public properties
  private _articles: Article[];
  @Input() get articles(): Article[] {
    return this._articles;
  }
  set articles(val: Article[]) {
    this._articles = val;
    $("#list .content-main-scroll").scrollTop(0);
    this.setSelectedArticle(this.activeArticleId, false);
  }

  private _activeMenu = "";
  @Input() get activeMenu(): string {
    return this._activeMenu;
  }
  set activeMenu(val: string) {
    this._activeMenu = val;
    this.setSelectedArticle(this.activeArticleId, false);
  }

  private _activeArticleId = "";
  @Input() get activeArticleId(): string {
    return this._activeArticleId;
  }
  set activeArticleId(val: string) {
    this._activeArticleId = val;
    this.setSelectedArticle(this.activeArticleId, false);
  }

  setSelectedArticle(articleId, updateSidebar) {
    if (this.articles != null && this.activeMenu != "") {
      if ((articleId == "" || articleId == null) && this.articles.length > 0) {
        articleId = this.articles[0].fullId
      }

      for (let i = 0; i < this.articles.length; i++) {
        this.articles[i].selected = (this.articles[i].id.toString() == articleId || this.articles[i].fullId == articleId);
      }
    }

    if (updateSidebar) {
      this.updateSidebarVisibility.emit(false);
    }    
  }

  @Input() get year(): string {
    return (new Date()).getFullYear().toString();
  }

  constructor(router: Router, http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    
  }

  ngOnInit() {

  }
}
