import { Observable } from 'rxjs';
import { Input } from '@angular/core';

export class ItemType {
  id: number;
  type: string;
  name: string;
  sortOrder: number;
  visible: boolean;
  source: string;
  defaultId: number;
  selected: boolean;
}
