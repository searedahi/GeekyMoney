import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';
import { BootstrapSwitchModule } from 'angular2-bootstrap-switch';

import { AppComponent } from './components/app/app.component';
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { HomeComponent } from './components/home/home.component';
import { CounterComponent } from './components/counter/counter.component';
import { RealEstatePropertiesComponent } from './components/realestateproperty/realestateproperties.component';
import { RealEstatePropertyEditComponent } from './components/realestateproperty/edit/realestatepropertyedit.component';
import { RealEstatePropertyDeleteComponent } from './components/realestateproperty/delete/realestatepropertydelete.component';

import { MortgagesComponent } from './components/mortgage/mortgages.component'
import { MortgageEditComponent } from './components/mortgage/edit/mortgageedit.component'
import { MortgageDeleteComponent } from './components/mortgage/delete/mortgagedelete.component'

import { FeesComponent } from './components/fee/fees.component';
import { FeeEditComponent } from './components/fee/edit/feeedit.component';
import { FeeDeleteComponent } from './components/fee/delete/feedelete.component';
import { FeePickerComponent } from './components/fee/picker/feepicker.component';

import { RatingComponent } from './components/_shared/rating/rating.component';

import { ScenariosComponent } from './components/scenario/scenarios.component'
import { ScenarioEditComponent } from './components/scenario/edit/scenarioedit.component'
import { ScenarioDeleteComponent } from './components/scenario/delete/scenariodelete.component'


@NgModule({
    declarations: [
        AppComponent,
        NavMenuComponent,
        CounterComponent,
        HomeComponent,
        RealEstatePropertiesComponent,
        RealEstatePropertyEditComponent,
        RealEstatePropertyDeleteComponent,
        MortgagesComponent,
        MortgageEditComponent,
        MortgageDeleteComponent,
        FeesComponent,
        FeeEditComponent,
        FeeDeleteComponent,
        FeePickerComponent,
        RatingComponent,
        ScenariosComponent,
        ScenarioEditComponent,
        ScenarioDeleteComponent,
    ],
    imports: [
        CommonModule,
        HttpModule,
        FormsModule,  
        RouterModule.forRoot([
            { path: '', redirectTo: 'home', pathMatch: 'full' },
            { path: 'home', component: HomeComponent },
            { path: 'counter', component: CounterComponent },
            { path: 'realestateproperties', component: RealEstatePropertiesComponent },
            { path: 'realestateproperty/edit/:id', component: RealEstatePropertyEditComponent },
            { path: 'realestateproperty/delete/:id', component: RealEstatePropertyDeleteComponent },
            { path: 'mortgages', component: MortgagesComponent },
            { path: 'mortgage/edit/:id', component: MortgageEditComponent },
            { path: 'mortgage/delete/:id', component: MortgageDeleteComponent },
            { path: 'fees', component: FeesComponent },
            { path: 'fee/templates', component: FeesComponent },
            { path: 'fee/edit/:id', component: FeeEditComponent },
            { path: 'fee/delete/:id', component: FeeDeleteComponent },
            { path: 'scenarios', component: ScenariosComponent },
            { path: 'scenario/edit/:id', component: ScenarioEditComponent },
            { path: 'scenario/delete/:id', component: ScenarioDeleteComponent },

            { path: '**', redirectTo: 'home' }
        ]),
        BootstrapSwitchModule.forRoot()
    ],
    bootstrap: [AppComponent]
})
export class AppModuleShared {
}
