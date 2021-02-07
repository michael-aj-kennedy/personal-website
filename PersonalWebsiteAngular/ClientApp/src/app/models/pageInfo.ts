import { Observable } from 'rxjs';
import { Input } from '@angular/core';
import { Article } from './article';
import { ItemType } from './itemType';

export class PageInfo {
  menuItems: ItemType[] = [];
  articles: Article[] = [];
  article: Article;
}
