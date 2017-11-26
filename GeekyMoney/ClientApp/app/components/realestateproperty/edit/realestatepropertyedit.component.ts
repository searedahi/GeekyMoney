import { Component } from '@angular/core';
import { Router, ActivatedRoute, Params } from '@angular/router';


import { RealEstateProperty } from '../../_model/realestateproperty.model';
import { RealEstatePropertyService } from '../realestateproperty.service';
import { FeePickerComponent } from '../../fee/picker/feepicker.component';
import { FeeService } from '../../fee/fee.service';
import { Fee } from '../../_model/fee.model';

@Component({
    selector: 'realestateproperty/edit',
    templateUrl: './realestatepropertyedit.component.html',
    providers: [RealEstatePropertyService, FeeService],
    styleUrls: ['../realestateproperty.component.css']
})
export class RealEstatePropertyEditComponent {

    public realEstateProperty: RealEstateProperty = new RealEstateProperty();
    private id: string;
    constructor(private realEstatePropertyService: RealEstatePropertyService, private feeService: FeeService, private route: ActivatedRoute, private redirect: Router) {

        this.route.params.subscribe((params: Params) => {
            this.id = params['id'];
        });

        if (this != undefined && this.id != undefined && this.id != "0") {
            this.realEstatePropertyService.getDetail(this.id).subscribe(data => {
                this.realEstateProperty = data.json();
            },
                error => console.log(error)
            );
        }

    }

    save() {

        if (this.realEstateProperty.id == undefined || this.realEstateProperty.id == 0) {
            this.realEstatePropertyService.postData(this.realEstateProperty)
                .subscribe(
                (response) => {
                    console.log(response);
                    this.list();
                },


                (error) => console.log(error)
                );
        }
        else {
            this.realEstatePropertyService.putData(this.realEstateProperty)
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
        this.redirect.navigateByUrl('/realestateproperties');
    }

    onRating(obj: any): void {
        this.realEstateProperty.rating = obj.rating;
    }

    onDeleteFee(id: any): void {
        this.feeService.deleteData(id).subscribe(data => {

            var index = this.realEstateProperty.propertyFees.findIndex(f => f.id == id);
            if (index > -1) {
                this.realEstateProperty.propertyFees.splice(index, 1);
            }
        },
            error => console.log(error)
        );
    }



    feeTemplateSelected(feePickedEvent: any): void {
        //var fee = this.feeService.realEstatePropertyFeeFromTemplate(feePickedEvent.feeTemplateId, this.realEstateProperty.id);


        this.feeService.getDetail(feePickedEvent.feeTemplateId).subscribe(data => {
            var feeTemplate: Fee = data.json();

            if (feeTemplate.id != null) {
                var fee: Fee = new Fee();

                // Set the properties for our new fee and parent real estate property
                fee = feeTemplate;
                fee.id = 0;
                fee.realEstatePropertyID = this.realEstateProperty.id;
                fee.isTemplate = false;

                this.feeService.postData(fee).subscribe(
                    (response) => {
                        var newFee = response.json();
                        fee.id = newFee.id;
                        this.realEstateProperty.propertyFees.push(fee);
                    });
            }


        },
            error => console.log(error)
        );
    }
}