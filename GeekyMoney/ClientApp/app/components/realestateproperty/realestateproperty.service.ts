import { Injectable } from '@angular/core';
import { Http, Response, RequestOptions, Headers } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';

import { RealEstateProperty } from './realestateproperty.model'

@Injectable()
export class RealEstatePropertyService {

    public myDetail: RealEstateProperty;
    public headers: Headers

    constructor(private http: Http) {
        this.headers = new Headers();
        this.headers.append('Content-Type', 'application/json; charset=utf-8');
    }

    getData() {
        return this.http.get('/api/RealEstateProperty');
    }

    getDetail(id: string) {        
        return this.http.get('/api/RealEstateProperty/' + id);
    }

    postData(realProp: RealEstateProperty) {
        return this.http.post('/api/RealEstateProperty', realProp);
    }  

    putData(realProp: RealEstateProperty) {
        return this.http.put('/api/RealEstateProperty/' + realProp.id, realProp);
    }  

    deleteData(id: number) {
        return this.http.delete('/api/RealEstateProperty/' + id, new RequestOptions({
            headers: this.headers,
            body: id
        }));
    } 

}  