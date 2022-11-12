

import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AppGlblSettingsService } from 'common-services';
import { AppGlblSettingsServiceActivator } from 'common-services';
import { LformsFeatureFtrComponent } from './lforms-feature.ftr.component';


const routes: Routes = [
    {
        path: '',
        component: LformsFeatureFtrComponent,
        canActivate: [AppGlblSettingsServiceActivator],

    },
]; // const routes: Routes = [...]

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class LformsFeatureFtrRoutingModule { }


