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

    var componentName = e.constructor.name;
    var routeInfo = null;

    if (e.route != null && e.route.component != null) {
      routeInfo = e.route;
    }

    if (componentName === "AppViewCvComponent") {
      menuItem = "cv";
    }
    else if (componentName === "AppViewArticleComponent") {
      menuItem = e.route.params.value.type;
    }

    if (menuItem !== this.activeMenu) {
      this.activeMenu = menuItem;

      //get menu the article we expect to be selected
      //get the type of article (or default to "about")


      //get article list
      this.httpClient.get<Article[]>(this.base + 'api/v2/Articles?itemType=' + this.activeMenu).subscribe(result => {
        this.articles = result;

        //mark matching sidebar item as selected
        //mark matching article as selected
      }, error => console.error(error));
    }
    else {
      //mark matching article as selected
    }

    
  }




  ngOnInit() {
    
  }
}
