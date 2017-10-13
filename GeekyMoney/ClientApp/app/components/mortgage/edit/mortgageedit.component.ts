import { Component } from '@angular/core';
import { Router, ActivatedRoute, Params } from '@angular/router';

import { Mortgage } from '../mortgage.model';
import { MortgageService } from '../mortgage.service';

@Component({
    selector: 'mortgage/edit',
    templateUrl: './mortgageedit.component.html',
    providers: [MortgageService],
    styleUrls: ['../mortgage.component.css']
})
export class MortgageEditComponent {

    public mortgage: Mortgage = new Mortgage();
    private id: string;
    constructor(private mortgageService: MortgageService, private route: ActivatedRoute, private redirect: Router) {

        this.route.params.subscribe((params: Params) => {
            this.id = params['id'];
        });

        if (this != undefined && this.id != undefined && this.id != "0") {
            this.mortgageService.getDetail(this.id).subscribe(data => {
                this.mortgage = data.json();
            },
                error => console.log(error)
            );
        }

    }

    save() {

        if (this.mortgage.id == undefined || this.mortgage.id == 0) {
            this.mortgageService.postData(this.mortgage)
                .subscribe(
                (response) => {
                    console.log(response);
                    this.list();
                },


                (error) => console.log(error)
                );
        }
        else {
            this.mortgageService.putData(this.mortgage)
                .subscribe(
                (response) => {
                    console.log(response);
                    this.list();
                },
                (error) => console.log(error)
                );
        }
    }

    list() {
        this.redirect.navigateByUrl('/mortgages');
    }

}



