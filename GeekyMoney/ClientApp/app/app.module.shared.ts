import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './components/app/app.component';
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { HomeComponent } from './components/home/home.component';
import { CounterComponent } from './components/counter/counter.component';
import { RealEstatePropertiesComponent } from './components/realestateproperty/realestateproperties.component';
import { RealEstatePropertyComponent } from './components/realestateproperty/edit/realestateproperty.component';
import { RealEstatePropertyDeleteComponent } from './components/realestateproperty/delete/realestatepropertydelete.component';

import { MortgageComponent } from './components/mortgage/mortgage.component'

@NgModule({
    declarations: [
        AppComponent,
        NavMenuComponent,
        CounterComponent,
        HomeComponent,
        RealEstatePropertiesComponent,
        RealEstatePropertyComponent,
        RealEstatePropertyDeleteComponent,
        MortgageComponent
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
            { path: 'realestateproperty/edit/:id', component: RealEstatePropertyComponent },
            { path: 'realestateproperty/delete/:id', component: RealEstatePropertyDeleteComponent },
            { path: 'mortgage', component: MortgageComponent },
            { path: '**', redirectTo: 'home' }
        ])
    ]
})
export class AppModuleShared {
}
