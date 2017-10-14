import { Component } from '@angular/core';
import { Router, ActivatedRoute, Params } from '@angular/router';

import { Fee } from '../../_model/fee.model';
import { FeeService } from '../fee.service';

@Component({
    selector: 'fee/delete',
    templateUrl: './feedelete.component.html',
    providers: [FeeService],
    styleUrls: ['../fee.component.css']
})
export class FeeDeleteComponent {

    public fee: Fee = new Fee();
    private id: string;
    constructor(private feeService: FeeService, private route: ActivatedRoute, private redirect: Router) {

        this.route.params.subscribe((params: Params) => {
            this.id = params['id'];
        });

        if (this != undefined && this.id != undefined && this.id != "0") {
            this.feeService.getDetail(this.id).subscribe(data => {
                this.fee = data.json();
            },
                error => console.log(error)
            );
        }

    }

    onDelete(id: number) {
        this.feeService.deleteData(id).subscribe(data => {
            this.list();
        },
            error => console.log(error)
        );
    }  

    list() {
        this.redirect.navigateByUrl('/fees');
    }

}



