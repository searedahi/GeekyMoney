import { Component } from '@angular/core';
import { Router, ActivatedRoute, Params } from '@angular/router';

import { Fee } from '../../_model/fee.model';
import { ScheduleType } from '../../_model/scheduleType.model';
import { FeeService } from '../fee.service';

@Component({
    selector: 'fee/edit',
    templateUrl: './feeedit.component.html',
    providers: [FeeService],
    styleUrls: ['../fee.component.css']
})
export class FeeEditComponent {

    public fee: Fee = new Fee();
    private id: string;
    private returnToRealEstateProperty: boolean;
    private enableTemplateToggle: boolean;

    private allScheduleTypes: Array<ScheduleType> = [
        new ScheduleType(1, 'OneTime')
        ,new ScheduleType(2, 'Daily')
        ,new ScheduleType(3, 'Weekly')
        ,new ScheduleType(4, 'BiWeekly')
        ,new ScheduleType(5, 'Monthly')
        ,new ScheduleType(6, 'BiMonthly')
        ,new ScheduleType(7, 'Quarterly')
        ,new ScheduleType(8, 'Annually')
    ]
    

    constructor(private feeService: FeeService, private route: ActivatedRoute, private redirect: Router) {

        this.route.params.subscribe((params: Params) => {
            this.id = params['id'];
        });

        if (this != undefined && this.id != undefined) {

            if (this.id != "0") {
                // Editing a fee
                this.feeService.getDetail(this.id).subscribe(data => {
                    this.fee = data.json();                    
                    this.enableTemplateToggle = false;

                },
                    error => console.log(error)
                );
            }
            else if (this.id == "0") {
                // New fee
                this.enableTemplateToggle = true;
            }
            else if (this.fee.realEstatePropertyID == undefined || this.fee.realEstatePropertyID == 0) {
                // Editing a RealEstateFee
                this.route.queryParams.subscribe(qParams => {
                    this.fee.realEstatePropertyID = qParams['realEstatePropertyId'];
                    this.returnToRealEstateProperty = true;
                });
            }


        }
    }

    save() {

        if (this.fee.id == undefined || this.fee.id == 0) {
            this.feeService.postData(this.fee)
                .subscribe(
                (response) => {
                    this.navigate();
                },
                (error) => console.log(error)
                );
        }
        else {
            this.feeService.putData(this.fee)
                .subscribe(
                (response) => {
                    this.navigate();
                },
                (error) => console.log(error)
                );
        }
    }

    onDeductibleFlagChange() {
        this.fee.isDeductible = !this.fee.isDeductible;
    }
    onTemplateFlagChange() {
        this.fee.isTemplate = !this.fee.isTemplate;
    }
    onFeeTypeChange() {
        this.fee.feeTypeID = this.fee.feeTypeID == 1 ? 2 : 1;
    }

    navigate() {
        if (this.returnToRealEstateProperty) {
            this.redirect.navigateByUrl('/realestateproperty/edit/' + this.fee.realEstatePropertyID);
        } else {
            this.list();
        }
    }

    list() {

        this.redirect.navigateByUrl('/fees');
    }

}



