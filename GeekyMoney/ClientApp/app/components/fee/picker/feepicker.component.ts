import { Component, Input, Output, EventEmitter } from '@angular/core';
import { Fee } from '../../_model/fee.model';

@Component({
    selector: 'feepicker',
    templateUrl: './feepicker.component.html',
    styleUrls: ['./feepicker.component.css']
})

export class FeePickerComponent {

    selectedFee: Fee;
    allFees: Fee[];
    
    @Output() feeClicked = new EventEmitter<any>();

    onClick(value: number): void {
        this.selectedFee.id = value;
        this.feeClicked.emit({
            feeId: this.selectedFee.id,
            parentObjectId: this.selectedFee.parentObjectId
        });
    }
}