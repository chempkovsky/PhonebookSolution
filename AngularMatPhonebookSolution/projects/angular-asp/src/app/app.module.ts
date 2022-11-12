
import { BrowserModule } from '@angular/platform-browser';
import { APP_INITIALIZER, NgModule } from '@angular/core';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';


import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AppMaterialModule } from 'common-modules';
import { AppFlexLayoutModule } from 'common-modules';
import { AppGlblInterceptor } from 'common-auth';
import { AppConfigService } from 'common-services';
import { AppFormatterModule } from 'common-formatters';
import { AppGlblHomeComponent } from './shared/components/app-glbl-home/app-glbl-home.component';
import { AppGlblPagenotfoundComponent } from './shared/components/app-glbl-pagenotfound/app-glbl-pagenotfound.component';

const appInitializerFn = (appConfig: AppConfigService) => {
  return () => {
      return appConfig.loadAppConfig();
  }
};


@NgModule({
  declarations: [
    AppComponent,
    AppGlblHomeComponent, 
    AppGlblPagenotfoundComponent, 

  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    AppRoutingModule,
    AppMaterialModule,
    AppFormatterModule,
    AppFlexLayoutModule,
    HttpClientModule,
  ],
  entryComponents: [
  ],
  exports: [
  ],
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: AppGlblInterceptor,
      multi: true
    },
    AppConfigService,
    {
        provide: APP_INITIALIZER,
        useFactory: appInitializerFn,
        multi: true,
        deps: [AppConfigService]
    }        
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }

