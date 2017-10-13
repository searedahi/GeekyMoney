import { Injectable } from '@angular/core';
import { Http, Response, RequestOptions, Headers } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';

import { Fee } from '../_model/fee.model'

@Injectable()
export class FeeService {

    public myDetail: Fee;
    public headers: Headers

    constructor(private http: Http) {
        this.headers = new Headers();
        this.headers.append('Content-Type', 'application/json; charset=utf-8');
    }

    getData() {
        return this.http.get('/api/fee');
    }

    getDetail(id: string) {        
        return this.http.get('/api/fee/' + id);
    }

    postData(fee: Fee) {
        return this.http.post('/api/fee', fee);
    }  

    putData(fee: Fee) {
        return this.http.put('/api/fee/' + fee.id, fee);
    }  

    deleteData(id: number) {
        return this.http.delete('/api/fee/' + id, new RequestOptions({
            headers: this.headers,
            body: id
        }));
    } 

}  