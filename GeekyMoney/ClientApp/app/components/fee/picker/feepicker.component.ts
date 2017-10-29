import { Component, Inject, Input } from '@angular/core';
import { Fee } from '../../_model/fee.model';
import { FeeService } from '../fee.service'

@Component({
    selector: 'fee-picker',
    templateUrl: './feepicker.component.html',
    styleUrls: ['./feepicker.component.css']
})

export class FeePickerComponent {

    public selectedFee: Fee;
    public allFees: Fee[];
    
    constructor(private feeService: FeeService) {
        this.getListData();
    }

    getListData() {
        this.feeService.getData().subscribe(data => {
            this.allFees = data.json() as Fee[];
        },
            error => console.log(error)
        );
    }
}