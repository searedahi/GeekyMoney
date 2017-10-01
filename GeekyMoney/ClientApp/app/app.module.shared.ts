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
import { RealEstatePropertyComponent } from './components/realestateproperty/detail/realestateproperty.component';

import { MortgageComponent } from './components/mortgage/mortgage.component'

@NgModule({
    declarations: [
        AppComponent,
        NavMenuComponent,
        CounterComponent,
        HomeComponent,
        RealEstatePropertiesComponent,
        RealEstatePropertyComponent,
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
            { path: 'realestateproperty/:id', component: RealEstatePropertyComponent },
            { path: 'mortgage', component: MortgageComponent },
            { path: '**', redirectTo: 'home' }
        ])
    ]
})
export class AppModuleShared {
}
