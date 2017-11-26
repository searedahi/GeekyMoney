import { Component, Inject, Output, EventEmitter } from '@angular/core';
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
    public feeTemplateId: number;

    @Output() feePickedEvent = new EventEmitter<any>();

    constructor(private feeService: FeeService) {
        this.getTemplates();
    }

    getTemplates() {
        this.feeService.getTemplates().subscribe(data => {
            this.allFees = data.json() as Fee[];
        },
            error => console.log(error)
        );
    }

    feePicked(value: number): void {
        if (value > 0) {
            this.feeTemplateId = value;

            this.feePickedEvent.emit({
                feeTemplateId: this.feeTemplateId
            });

            this.selectedFee = new Fee();
            this.selectedFee.id = 0; // We're done.  Reset the picker.
        }
    }
}