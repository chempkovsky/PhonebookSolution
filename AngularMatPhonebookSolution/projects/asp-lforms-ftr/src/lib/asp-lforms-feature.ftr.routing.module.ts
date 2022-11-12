

import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AppGlblSettingsService } from 'common-services';
import { AppGlblSettingsServiceActivator } from 'common-services';
import { AspLformsFeatureFtrComponent } from './asp-lforms-feature.ftr.component';


const routes: Routes = [
    {
        path: '',
        component: AspLformsFeatureFtrComponent,
        canActivate: [AppGlblSettingsServiceActivator],

    },
]; // const routes: Routes = [...]

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AspLformsFeatureFtrRoutingModule { }


