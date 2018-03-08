import { Component, Inject } from '@angular/core';
import { Http } from '@angular/http';
import { Mortgage } from '../_model/mortgage.model';
import { MortgageService } from './mortgage.service'


@Component({
    selector: 'mortgages',
    templateUrl: './mortgages.component.html',
    providers: [MortgageService],
    styleUrls: ['./mortgage.component.css']
})

export class MortgagesComponent {
    public mortgages: Mortgage[]

    constructor(private mortgageServie: MortgageService) {
        this.getListData();
    }
    
    getListData() {
        this.mortgageServie.getData().subscribe(data => {
            this.mortgages = data.json() as Mortgage[];
        },
            error => console.log(error)
        );
    }
}
