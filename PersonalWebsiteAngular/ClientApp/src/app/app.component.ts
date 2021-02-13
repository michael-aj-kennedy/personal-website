import { Component, OnInit, Inject, Input } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { PageInfo } from './models/pageInfo';
import { HttpClient } from '@angular/common/http';
import { ItemType } from './models/itemType';
import { Article } from './models/article';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  title = "app";

  //private properties
  private httpClient: HttpClient;
  private base: string;

  //public properties
  private _itemTypes: ItemType[];
  @Input() get itemTypes(): ItemType[] {
    return this._itemTypes;
  }
  set itemTypes(val: ItemType[]) {
    this._itemTypes = val;
    this.setSelectedMenuItem();
  }

  private _activeArticleId = "";
  @Input() get activeArticleId(): string {
    return this._activeArticleId;
  }
  set activeArticleId(val: string) {
    this._activeArticleId = val;
  }

  private _activeMenu = "";
  @Input() get activeMenu(): string {
    return this._activeMenu;
  }
  set activeMenu(val: string) {
    this._activeMenu = val;
  }

  private _articles: Article[];
  @Input() get articles(): Article[] {
    return this._articles;
  }
  set articles(val: Article[]) {
    this._articles = val;
  }

  private _forceSidebar: boolean;
  @Input() get forceSidebar(): boolean {
    return this._forceSidebar;
  }
  set forceSidebar(val: boolean) {
    this._forceSidebar = val;
  }

  updateSidebarVisibility(val: boolean) {
    console.log(val);
    this.forceSidebar = val;
  }

  constructor(router: Router, http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.httpClient = http;
    this.base = baseUrl;

    //get menu items
    this.httpClient.get<PageInfo>(this.base + 'api/v2/Menu').subscribe(result => {
      this.itemTypes = result.menuItems;
    }, error => console.error(error));
  }

  routeActivated(e) {
    let menuItem = "blog";
    let articleId = "-1";
    const componentName = e.constructor.name;

    if (componentName === "AppViewCvComponent") {
      menuItem = "cv";
      articleId = e.route.params.value.id;
    }
    else if (componentName === "AppViewArticleComponent") {
      menuItem = e.route.params.value.type;
      articleId = e.route.params.value.id;
    }
    else if (componentName === "AppViewAboutComponent") {
      menuItem = "about";
      articleId = "-1";
    }   
    
    this.activeArticleId = articleId;

    if (menuItem !== this.activeMenu) {
      this.activeMenu = menuItem;
      this.setSelectedMenuItem();

      //get article list
      this.httpClient.get<Article[]>(this.base + 'api/v2/Articles?itemType=' + this.activeMenu).subscribe(result => {
        this.articles = result;
      }, error => console.error(error));
    }
  }

  setSelectedMenuItem() {
    const activeMenuItem = this.activeMenu == null || this.activeMenu == "" ? "blog" : this.activeMenu;

    if (this.itemTypes != null) {
      for (let i = 0; i < this.itemTypes.length; i++) {
        this.itemTypes[i].selected = (this.itemTypes[i].type == activeMenuItem);
      }
    }
  }


  ngOnInit() {
    
  }
}
