import { Injectable } from '@angular/core';
import { HttpClient, HttpResponse } from '@angular/common/http';
import { IConfiguration } from './configuration.model';

@Injectable({
  providedIn: 'root'
})
export class ConfigurationService {

  public environmentConfiguration: IConfiguration;
  private readonly configFile = 'config.json';

  constructor(private readonly http: HttpClient) {
  }

  load() {
    const fileUrl: string = 'app/' + this.configFile;
    return new Promise(resolve => {
      this.http.get<IConfiguration>(fileUrl)
        .subscribe(config => {
          this.environmentConfiguration = config;
          resolve();
        });
    });
  }
}
