import { Injectable } from '@angular/core';
import { HttpClient, HttpParams, HttpErrorResponse, HttpResponse } from '@angular/common/http';
import { Observable } from 'rxjs';
import { KeyValuePipe } from '@angular/common';
import { ConfigurationService } from '../configuration/configuration.service';
import { map } from 'rxjs/operators';
import { SearchType } from 'src/app/news/news-search/news-search.component';
import { isRegExp } from 'util';
import { SearchResultDto } from 'src/app/shared/search';
import { CybernewsApiResponse } from 'src/app/shared/article';


@Injectable({
  providedIn: 'root'
})
export class SearchService {
  private readonly apiUrl;

  constructor(
    private readonly http: HttpClient,
    private readonly pipe: KeyValuePipe,
    private readonly configuration: ConfigurationService
  ) {
    this.apiUrl = configuration.environmentConfiguration.CybernewsApi.Url;
  }


  objectsToQueryString(objs: Array<any>): HttpParams {
    let httpParams = new HttpParams();

    objs.forEach(obj => {
      obj = this.pipe.transform(obj);
      obj.forEach(item => {
        if(item.value){
          httpParams = httpParams.set(item.key, item.value);
        }
      });
    });

    return httpParams;
  }

  search(type: SearchType, query: string): Observable<SearchResultDto> {
    let url = `${this.apiUrl}/search`;

    const queryParams = {keyword : query, type};

    const httpParams = this.objectsToQueryString([queryParams]);

    return this.http.request<CybernewsApiResponse>('get', url, {
        params: httpParams,
      })
      .pipe(
        map((response: CybernewsApiResponse) => {
          return response.data as SearchResultDto;
        })
      );
  }
}
