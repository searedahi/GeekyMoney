import { Component, Inject } from '@angular/core';
import { Http } from '@angular/http';

@Component({
    selector: 'realestateproperty',
    templateUrl: './realestateproperty.component.html'
})

export class RealEstatePropertyComponent {
    public realEstateProperties: RealEstateProperty[]

    constructor(http: Http, @Inject('BASE_URL') baseUrl: string) {
        http.get(baseUrl + 'api/RealEstateProperty').subscribe(result => {
            this.realEstateProperties = result.json() as RealEstateProperty[];
        }, error => console.error(error));
    }



}



