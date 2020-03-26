import { Directive, Input, HostListener, ElementRef } from '@angular/core';

@Directive({
  selector: 'img[default]'
})
export class DefaultImageDirective {
  @Input() default: string;

  constructor(
    private element: ElementRef
  ) {}

  @HostListener('error')
  updateUrl() {
      this.element.nativeElement.attributes['src'].value = this.default;
  }
}
