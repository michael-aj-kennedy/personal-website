import { Component, OnInit, Inject, Input, HostBinding } from '@angular/core';
import { Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { Article } from '../../models/article';
import { DomSanitizer, SafeHtml, Title } from '@angular/platform-browser';
declare var $: any;
declare function recordPage(val: string): any;

@Component({
  selector: 'app-article',
  templateUrl: './app-article.component.html',
  styleUrls: ['./app-article.component.scss']
})
export class AppArticleComponent implements OnInit { 
  //private properties
  private httpClient: HttpClient;
  private base: string;

  //public properties
  private _type = null;
  @Input() get articleType(): string {
    return this._type;
  }
  set articleType(val: string) {
    this._type = val;
    this.loadArticle();
  }

  private _id = null;
  @Input() get articleId(): string {
    return this._id;
  }
  set articleId(val: string) {
    this._id = val;
    this.loadArticle();
  }

  private _articleSource = null;
  @Input() get articleSource(): string {
    return this._articleSource;
  }
  set articleSource(val: string) {
    this._articleSource = val;
    this.loadArticle();
  }

  private _article = null;
  @Input() get article(): Article {
    return this._article;
  }
  set article(val: Article) {
    this._article = val;
  }

  @Input() get title(): string {
    return this.article != null && this.article.title != null ? this.article.title : "";
  }

  @Input() get subTitle(): string {
    return this.article != null && this.article.subtitle != null ? this.article.subtitle : "";
  }

  @Input() get hasSubTitle(): boolean {
    return this.article != null && this.article.subtitle != null && this.article.subtitle.trim() != "";
  }

  @Input() get date(): string {
    return this.article != null && this.article.date != null ? this.article.date : "";
  }

  @Input() get content(): SafeHtml {
    return this.sanitizer.bypassSecurityTrustHtml(this.article != null && this.article.content != null
      ? ("<style> .article-content img { border:solid 1px " + this.accentColour + " !important; } </style>" + this.article.content)
      : "");
  }

  @Input() get headerImage(): string {
    return this.article != null && this.article.headerImage != null ? this.article.headerImage : "";
  }

  @Input() get hasHeaderImage(): boolean {
    return this.headerImage != "";
  }

  @Input() get hasDate(): boolean {
    const articleDate = this.date;
    return articleDate != null && articleDate != "" && !articleDate.endsWith("2000");
  }

  @Input() get accentColour(): string {
    let returnData = "rgb(235, 235, 235)";

    if (this.article != null && this.article.accentColour != null && this.article.accentColour != "") {
      returnData = this.article.accentColour;
    }

    return returnData;
  }

  @Input() get titleTextColour(): string {
    let returnData = "rgb(33, 37, 41)";

    if (this.article != null && this.article.titleTextColour != null && this.article.titleTextColour != "") {
      returnData = this.article.titleTextColour;
    }
    
    return returnData;
  }

  constructor(private titleService: Title, private sanitizer: DomSanitizer, http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.httpClient = http;
    this.base = baseUrl;    
  }
  
  loadArticle() {
    if (this.articleSource != null && this.articleType != null && this.articleId != null) {
      //get article
      this.httpClient.get<Article>(this.base + 'api/v2/Article?itemType=' + this.articleType + "&articleId=" + this.articleId).subscribe(result => {
        this.article = result;
        $("#article .content-main-scroll").scrollTop(0);

        let pageTitle = "Michael Kennedy - " + result.title;
        if (result.subtitle != null && result.subtitle != "") {
          pageTitle = pageTitle + " - " + result.subtitle;
        }
        this.titleService.setTitle(pageTitle);
        recordPage(window.location.pathname);
      }, error => console.error(error));
    }
  }

  ngOnInit() {

  }
}
