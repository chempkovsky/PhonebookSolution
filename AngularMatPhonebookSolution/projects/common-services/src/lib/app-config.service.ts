
import { Injectable, Injector } from '@angular/core';
import { firstValueFrom } from 'rxjs';
import { HttpClient } from '@angular/common/http';

import { IAppConfig } from 'common-interfaces';

@Injectable()
export class AppConfigService {
    public _appConfig: IAppConfig  = {
      webApiUrl: '',
      securityUrl: '',
      permissionWebApi: '',
      divisionLpWebApi: '',
      employeeLpWebApi: '',
      phoneLpWebApi: '',      
    }; 

    constructor (private injector: Injector) { }
    loadAppConfig() {
        let http = this.injector.get(HttpClient);
          firstValueFrom(http.get<IAppConfig>('/assets/app-config.json')).then((data) => {
            this._appConfig = data;
          }).catch(()=>{
            console.warn("Error loading app-config.json, using envrionment file instead");
          });
    }
    get config(): IAppConfig {
        return this._appConfig;
    }
}

