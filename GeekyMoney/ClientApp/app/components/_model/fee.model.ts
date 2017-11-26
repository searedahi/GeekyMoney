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

    monthlyTotal: number;
    annualTotal: number;
}