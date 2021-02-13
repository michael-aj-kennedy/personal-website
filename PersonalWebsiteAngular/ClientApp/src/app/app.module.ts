import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { MatRippleModule } from '@angular/material/core';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { AppHeaderComponent } from './ui/app-header/app-header.component';
import { AppSearchResultComponent } from './ui/app-search-result/app-search-result.component';
import { AppPrimaryImageComponent } from './ui/app-primary-image/app-primary-image.component';
import { AppArticleComponent } from './ui/app-article/app-article.component';
import { AppSidebar } from './ui/app-sidebar/app-sidebar.component';
import { AppContactMethods } from './ui/app-contact-methods/app-contact-methods.component';
import { AppViewArticleComponent } from './articles/app-view-article/app-view-article.component';
import { AppViewAboutComponent } from './articles/app-view-about/app-view-about.component';
import { AppViewCvComponent } from './articles/app-view-cv/app-view-cv.component';
import { AppArticleListComponent } from './ui/app-article-list/app-article-list.component';
import { BindCssVariableDirective } from './core/bind-css-variable.directive';
import { AppArticleListItemComponent } from './ui/app-article-list-item/app-article-list-item.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    AppHeaderComponent,
    AppSearchResultComponent,
    AppPrimaryImageComponent,
    AppArticleComponent,
    AppSidebar,
    AppContactMethods,
    AppViewArticleComponent,
    AppViewAboutComponent,
    AppViewCvComponent,
    AppArticleListComponent,
    BindCssVariableDirective,
    AppArticleListItemComponent
  ],
  imports: [
    MatRippleModule,
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: AppViewAboutComponent, pathMatch: 'full' },  //about
      { path: 'about', component: AppViewAboutComponent },                //about
      { path: 'About', redirectTo: 'about' },                             //about
      { path: 'blog', component: AppViewArticleComponent },               //blog with first article
      { path: 'Blog', redirectTo: 'blog' },                               //blog with first article
      { path: 'blog/entry/:id', component: AppViewArticleComponent },     //blog with first article
      { path: 'Blog/entry/:id', redirectTo: 'articles/blog/:id' },        //blog with first article
      { path: 'cv', component: AppViewCvComponent },                      //cv with most recent item
      { path: 'Cv', redirectTo: 'cv' },                                   //cv with most recent item
      { path: 'articles/:type', component: AppViewArticleComponent },     //specified article list
      { path: 'articles/:type/:id', component: AppViewArticleComponent }, //specified article
      //{ path: '**', component: PageNotFoundComponent },  // Wildcard route for a 404 page
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
