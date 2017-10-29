import { Component, Inject, Input } from '@angular/core';
import { Http } from '@angular/http';
import { Fee } from '../_model/fee.model';
import { FeeService } from './fee.service'


@Component({
    selector: 'fees',
    templateUrl: './fees.component.html',
    providers: [FeeService],
    styleUrls: ['./fee.component.css']
})

export class FeesComponent {
    public fees: Fee[]
    @Input() isTemplate: boolean;

    //constructor(http: Http, @Inject('BASE_URL') baseUrl: string) {
    //    http.get(baseUrl + 'api/RealEstateProperty').subscribe(result => {
    //        this.realEstateProperties = result.json() as RealEstateProperty[];
    //    }, error => console.error(error));
    //}

    constructor(private feeService: FeeService) {
        this.getListData();
    }

    getListData() {

        if (this.isTemplate == true) {
            this.feeService.getData().subscribe(data => {
                this.fees = data.json() as Fee[];
            },
                error => console.log(error)
            );
        } else {
            this.feeService.getTemplates().subscribe(data => {
                this.fees = data.json() as Fee[];
            },
                error => console.log(error)
            );
        }
    }

    onClick(value: number): void {
        this.isTemplate = !this.isTemplate;
        this.getListData();
    }

}
