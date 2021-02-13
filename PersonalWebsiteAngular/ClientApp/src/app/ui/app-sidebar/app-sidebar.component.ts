import { Component, OnInit, Inject, Input, EventEmitter, Output } from '@angular/core';
import { Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { ItemType } from '../../models/itemType';

@Component({
  selector: 'app-sidebar',
  templateUrl: './app-sidebar.component.html',
  styleUrls: ['./app-sidebar.component.scss']
})
export class AppSidebar {
  @Output() updateSidebarVisibility = new EventEmitter<boolean>();

  //public properties
  private _itemTypes: ItemType[];
  @Input() get itemTypes(): ItemType[] {
    return this._itemTypes;
  }
  set itemTypes(val: ItemType[]) {
    this._itemTypes = val;
  }

  showSidebar(itemType) {
    this.updateSidebarVisibility.emit(itemType !== "about")
  }

}
