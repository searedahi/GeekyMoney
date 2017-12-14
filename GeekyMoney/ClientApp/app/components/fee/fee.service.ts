import { Injectable } from '@angular/core';
import { Http, Response, RequestOptions, Headers } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';

import { Fee } from '../_model/fee.model'
import { RealEstateProperty } from '../_model/realestateproperty.model'
import { Mortgage } from '../_model/mortgage.model'
import { GenericDropDownType } from '../_model/genericDropDownType.model'

@Injectable()
export class FeeService {

    public myDetail: Fee;
    public headers: Headers;

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

    realEstatePropertyFeeFromTemplate(feeTemplateId: string, realEstatePropertyId: number) {
        var fee: Fee = new Fee();

        this.getDetail(feeTemplateId).subscribe(data => {
            var feeTemplate: Fee = data.json();

            if (feeTemplate.id != null) {
                // Set the properties for our new fee and parent real estate property
                fee = feeTemplate;
                fee.id = 0;
                fee.realEstatePropertyID = realEstatePropertyId;
                fee.isTemplate = false;

                this.postData(fee).subscribe(
                    (response) => {
                        return fee;
                    });
            }
        },
            error => console.log(error)
        );
    }


    calculateMonthlyFeeAmout(fee: Fee): number {

        var monthlyAmount: number = 0;

        if (fee != null) {

            var annualAmount: number = 0;
            var baseRate: number = 0;

            if (fee.feeTypeID == 2) {
                baseRate = fee.percentBaseValue * (fee.percentRate / 100);
            } else {
                baseRate = fee.amount;
            }

            switch (fee.scheduleTypeID) {
                case 1:
                case 8:
                    monthlyAmount = baseRate / 12;
                    annualAmount = baseRate;
                    break;
                case 2:
                    monthlyAmount = (baseRate * 365) / 12;
                    annualAmount = baseRate * 365;
                    break;
                case 3:
                    monthlyAmount = (baseRate * 52.1429) / 12;
                    annualAmount = baseRate * 52.1429;
                    break;
                case 4:
                    monthlyAmount = (baseRate * 26) / 12;
                    annualAmount = baseRate * 26;
                    break;
                case 5:
                    monthlyAmount = baseRate;
                    annualAmount = baseRate * 12;
                    break;
                case 6:
                    monthlyAmount = baseRate / 2;
                    annualAmount = baseRate * 6;
                    break;
                case 7:
                    monthlyAmount = baseRate / 3;
                    annualAmount = baseRate * 4;
                    break;
                default:
                    monthlyAmount = baseRate;
                    annualAmount = baseRate;
            }
        }
        return monthlyAmount;

    }

    calculateAnnualFeeAmout(fee: Fee): number {

        var annualAmount: number = 0;

        if (fee != null) {

            var annualAmount: number = 0;
            var baseRate: number = fee.amount;

            switch (fee.scheduleTypeID) {
                case 1:
                case 8:
                    annualAmount = baseRate;
                    break;
                case 2:
                    annualAmount = baseRate * 365;
                    break;
                case 3:
                    annualAmount = baseRate * 52.1429;
                    break;
                case 4:
                    annualAmount = baseRate * 26;
                    break;
                case 5:
                    annualAmount = baseRate * 12;
                    break;
                case 6:
                    annualAmount = baseRate * 6;
                    break;
                case 7:
                    annualAmount = baseRate * 4;
                    break;
                default:
                    annualAmount = baseRate;
            }
        }
        return annualAmount;

    }


    getParentClassOptions(parentClassTypeId: number, myFee: Fee) {

        switch (Number(parentClassTypeId)) {
            case 2:
                return this.http.get('/api/Mortgage/PercentOfOptions/' + String(myFee.mortgageID));
            case 1:
                return this.http.get('/api/RealEstateProperty/PercentOfOptions/' + String(myFee.realEstatePropertyID));
        }
        return this.http.get('/api/RealEstateProperty/PercentOfOptions/0');
    }
}  