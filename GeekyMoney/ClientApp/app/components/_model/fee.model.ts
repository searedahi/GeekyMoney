export class Fee {
    id: number;
    name: string;
    description: string;
    amount: number;
    isDeductible: boolean;
    isTemplate: boolean;
    scheduleTypeId: number;
    feeTypeId: number;
    realEstatePropertyId: number;
    mortgageId: number;
}