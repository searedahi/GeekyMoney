import { Injectable } from '@angular/core';
import { Http, Response, RequestOptions, Headers } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';

import { FeeType } from '../_model/feeType.model'

@Injectable()
export class FeeTypeService {

    public myDetail: FeeType;
    public headers: Headers

    constructor(private http: Http) {
        this.headers = new Headers();
        this.headers.append('Content-Type', 'application/json; charset=utf-8');
    }

    getData() {
        return this.http.get('/api/fee');
    }

    getDataByType(id: string) {
        return this.http.get('/api/fee/type/' + id);
    }

    getTemplates() {
        return this.http.get('/api/fee/templates');
    }

    getTemplatesByType(id: string) {
        return this.http.get('/api/fee/templates/type/' + id);
    }

    getDetail(id: string) {
        return this.http.get('/api/fee/' + id);
    }

    postData(feeType: FeeType) {
        return this.http.post('/api/fee', feeType);
    }

    putData(feeType: FeeType) {
        return this.http.put('/api/fee/' + feeType.id, feeType);
    }

    deleteData(id: number) {
        return this.http.delete('/api/fee/' + id, new RequestOptions({
            headers: this.headers,
            body: id
        }));
    }


}  