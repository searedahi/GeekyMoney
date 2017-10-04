import { Component } from '@angular/core';
import { Router, ActivatedRoute, Params } from '@angular/router';

import { RealEstateProperty } from '../realestateproperty.model';
import { RealEstatePropertyService } from '../realestateproperty.service';

@Component({
    selector: 'realestateproperty/delete',
    templateUrl: './realestatepropertydelete.component.html',
    providers: [RealEstatePropertyService],
    styleUrls: ['../realestateproperty.component.css']
})
export class RealEstatePropertyDeleteComponent {

    public realEstateProperty: RealEstateProperty = new RealEstateProperty();
    private id: string;
    constructor(private realEstatePropertyService: RealEstatePropertyService, private route: ActivatedRoute, private redirect: Router) {

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

    onDelete(id: number) {
        this.realEstatePropertyService.deleteData(id).subscribe(data => {
            this.list();
        },
            error => console.log(error)
        );
    }  

    list() {
        this.redirect.navigateByUrl('/realestateproperties');
    }

}



