/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { ArticleViewService } from './article-view.service';

describe('Service: ArticleView', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [ArticleViewService]
    });
  });

  it('should ...', inject([ArticleViewService], (service: ArticleViewService) => {
    expect(service).toBeTruthy();
  }));
});
