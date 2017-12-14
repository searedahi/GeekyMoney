import { FeeService } from '../fee/fee.service';

export class Fee {
    id: number;
    name: string;
    description: string;
    amount: number;
    isDeductible: boolean;
    isTemplate: boolean;
    scheduleTypeID: number;
    feeTypeID: number;
    realEstatePropertyID: number;
    mortgageID: number;

    percentRate: number;
    percentBaseValue: number;
    percentBasedOn: string;

    monthlyTotal: number;
    annualTotal: number;
}