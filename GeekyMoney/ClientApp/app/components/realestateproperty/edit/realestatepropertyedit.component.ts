import { Component } from '@angular/core';
import { Router, ActivatedRoute, Params } from '@angular/router';

import { RealEstateProperty } from '../../_model/realestateproperty.model';
import { RealEstatePropertyService } from '../realestateproperty.service';

@Component({
    selector: 'realestateproperty/edit',
    templateUrl: './realestatepropertyedit.component.html',
    providers: [RealEstatePropertyService],
    styleUrls: ['../realestateproperty.component.css']
})
export class RealEstatePropertyEditComponent {

    public realEstateProperty: RealEstateProperty = new RealEstateProperty();
    private id: string;
    constructor(private realEstatePropertyService: RealEstatePropertyService, private route: ActivatedRoute, private redirect: Router) {

        this.route.params.subscribe((params: Params) => {
            this.id = params['id'];
        });

        if (this != undefined && this.id != undefined && this.id != "0") {
            this.realEstatePropertyService.getDetail(this.id).subscribe(data => {
                this.realEstateProperty = data.json();
                var extraStop = "";
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

}



