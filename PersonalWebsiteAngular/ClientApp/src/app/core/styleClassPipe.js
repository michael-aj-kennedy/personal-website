//import { Pipe, PipeTransform } from '@angular/core';
//import { DomSanitizer, SafeHtml } from '@angular/platform-browser';
//@Pipe({
//  name: 'StyleClass'
//})
//export class StyleClassPipe implements PipeTransform {
//  constructor(private sanitizer: DomSanitizer) { }
//  transform(html: any, styleSelector: any, styleValue: any): SafeHtml {
//    const style = ` style = "${styleSelector}: ${styleValue};"`;
//    const indexPosition = html.indexOf('>');
//    const newHtml = [html.slice(0, indexPosition), style, html.slice(indexPosition)].join('');
//    return this.sanitizer.bypassSecurityTrustHtml(newHtml);
//  }
//}
//# sourceMappingURL=styleClassPipe.js.map