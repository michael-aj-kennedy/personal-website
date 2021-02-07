import { Component, OnInit, Inject, Input } from '@angular/core';
import { Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-search-result',
  templateUrl: './app-search-result.component.html',
  styleUrls: ['./app-search-result.component.scss']
})
export class AppSearchResultComponent implements OnInit {



  //private properties
  /*private httpClient: HttpClient;
  private base: string;
  private firstNavigate = true;
  private activeMenu = "";
  private currentRoute = "";*/

  //public properties
  /*private _itemTypes: ItemType[];
  @Input() get itemTypes(): ItemType[] {
    return this._itemTypes;
  }
  set itemTypes(val: ItemType[]) {
    this._itemTypes = val;
  }*/


  constructor(router: Router, http: HttpClient, @Inject('BASE_URL') baseUrl: string) {

  }


  ngOnInit() {

  }
}
