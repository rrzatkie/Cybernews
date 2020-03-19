/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { ArticleRepositoryService } from './article-repository.service';

describe('Service: ArticleRepository', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [ArticleRepositoryService]
    });
  });

  it('should ...', inject([ArticleRepositoryService], (service: ArticleRepositoryService) => {
    expect(service).toBeTruthy();
  }));
});
