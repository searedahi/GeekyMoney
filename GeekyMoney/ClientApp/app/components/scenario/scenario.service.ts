import { Injectable } from '@angular/core';
import { Http, Response, RequestOptions, Headers } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';

import { Scenario } from '../_model/scenario.model'

@Injectable()
export class ScenarioService {

    //public myDetail: Scenario;
    public headers: Headers

    constructor(private http: Http) {
        this.headers = new Headers();
        this.headers.append('Content-Type', 'application/json; charset=utf-8');
    }

    getData() {
        return this.http.get('/api/scenario');
    }

    getDetail(id: string) {        
        return this.http.get('/api/scenario/' + id);
    }

    postData(scenario: Scenario) {
        return this.http.post('/api/scenario', scenario);
    }  

    putData(scenario: Scenario) {
        return this.http.put('/api/scenario/' + scenario.id, scenario);
    }  

    deleteData(id: number) {
        return this.http.delete('/api/scenario/' + id, new RequestOptions({
            headers: this.headers,
            body: id
        }));
    } 

}  