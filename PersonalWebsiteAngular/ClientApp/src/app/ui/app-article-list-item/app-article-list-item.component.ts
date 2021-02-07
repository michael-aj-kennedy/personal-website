import { Component, OnInit, Inject, Input, HostBinding } from '@angular/core';
import { Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { Article } from '../../models/article';
import { DomSanitizer, SafeHtml, Title } from '@angular/platform-browser';
declare var $: any;

@Component({
  selector: 'app-article-list-item',
  templateUrl: './app-article-list-item.component.html',
  styleUrls: ['./app-article-list-item.component.scss']
})
export class AppArticleListItemComponent implements OnInit {
  //private properties
  private httpClient: HttpClient;
  private base: string;

  private _article = null;
  @Input() get article(): Article {
    return this._article;
  }
  set article(val: Article) {
    this._article = val;
  }

  //constructor
  constructor(private titleService: Title, private sanitizer: DomSanitizer, http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.httpClient = http;
    this.base = baseUrl;    
  }

  ngOnInit() {

  }
}
