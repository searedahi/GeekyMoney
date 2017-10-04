import { Component, Inject } from '@angular/core';
import { Http } from '@angular/http';
import { RealEstateProperty } from './realestateproperty.model';
import { RealEstatePropertyService } from './realestateproperty.service'


@Component({
    selector: 'realestateproperties',
    templateUrl: './realestateproperties.component.html',
    providers: [RealEstatePropertyService],
    styleUrls: ['./realestateproperty.component.css']
})

export class RealEstatePropertiesComponent {
    public realEstateProperties: RealEstateProperty[]

    //constructor(http: Http, @Inject('BASE_URL') baseUrl: string) {
    //    http.get(baseUrl + 'api/RealEstateProperty').subscribe(result => {
    //        this.realEstateProperties = result.json() as RealEstateProperty[];
    //    }, error => console.error(error));
    //}

    constructor(private realEstatePropertyService: RealEstatePropertyService) {
        this.getListData();
    }
    
    getListData() {
        this.realEstatePropertyService.getData().subscribe(data => {
            this.realEstateProperties = data.json() as RealEstateProperty[];
        },
            error => console.log(error)
        );
    }
}
