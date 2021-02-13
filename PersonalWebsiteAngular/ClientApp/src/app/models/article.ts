import { Observable } from 'rxjs';
import { Input } from '@angular/core';
import { ExperienceInfo } from './experienceInfo';
import { Education } from './education';

export class Article {
  id: number;
  fullId: string;
  date: string;
  type: string;
  name: string;
  title: string;
  subtitle: string;
  summary: string;
  content: string;
  headerImage: string
  pinned: boolean;
  accentColour: string;
  titleTextColour: string;
  isBlogEntry: boolean;
  hasContent: boolean;
  hasSubTitle: boolean;
  isUrl: boolean;
  educationInfo: Education[] = [];
  info: ExperienceInfo[] = [];
  modeUrl: boolean;
  modeArticle: boolean;
  modeNoContent: boolean;
  selected: boolean;
}
