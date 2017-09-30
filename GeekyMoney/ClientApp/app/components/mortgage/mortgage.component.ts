import { Component, Inject } from '@angular/core';
import { Http } from '@angular/http';

@Component({
    selector: 'mortgage',
    templateUrl: './mortgage.component.html'
})

export class MortgageComponent {
    public mortgages: Mortgage[]

    constructor(http: Http, @Inject('BASE_URL') baseUrl: string) {
        http.get(baseUrl + 'api/Mortgage').subscribe(result => {
            this.mortgages = result.json() as Mortgage[];
        }, error => console.error(error));
    }
}



interface Mortgage {
    startDate: Date;
    loanAmount: number;
    downPayment: number;
    closingCost: number;
    cashToClose: number;
    interestRate: number;
    loanTerm: number;
}