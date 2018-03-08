import { Injectable } from '@angular/core';
import { Http, Response, RequestOptions, Headers } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';

import { Mortgage } from '../_model/mortgage.model'

@Injectable()
export class MortgageService {

    //public myDetail: Mortgage;
    public headers: Headers

    constructor(private http: Http) {
        this.headers = new Headers();
        this.headers.append('Content-Type', 'application/json; charset=utf-8');
    }

    getData() {
        return this.http.get('/api/Mortgage');
    }

    getDetail(id: string) {        
        return this.http.get('/api/Mortgage/' + id);
    }

    postData(mortgage: Mortgage) {
        return this.http.post('/api/Mortgage', mortgage);
    }  

    putData(mortgage: Mortgage) {
        return this.http.put('/api/Mortgage/' + mortgage.id, mortgage);
    }  

    deleteData(id: number) {
        return this.http.delete('/api/Mortgage/' + id, new RequestOptions({
            headers: this.headers,
            body: id
        }));
    } 

}  