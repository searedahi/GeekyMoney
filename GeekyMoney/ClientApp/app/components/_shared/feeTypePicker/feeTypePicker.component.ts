import { Component, Inject, Input, Output, EventEmitter } from '@angular/core';
import { Fee } from '../../_model/fee.model';
import { FeeTypeService } from '../../fee/feeType.service'

@Component({
    selector: 'feeTypePicker',
    templateUrl: './feeTypePicker.component.html',
    styleUrls: ['./feeTypePicker.component.css']
})

export class FeeTypePickerComponent {

    @Input() feeTypeID: number;

    public selectedFee: Fee;
    public allFees: Fee[];
    public feeTemplateId: number;

    @Output() feePickedEvent = new EventEmitter<any>();

    onClick(value: number): void {
        this.feeTypeID = value;
        this.feePickedEvent.emit({
            feeTypeID: this.feeTypeID
        });
    }
}