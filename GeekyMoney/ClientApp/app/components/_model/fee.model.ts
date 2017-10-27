export class Fee {
    id: number;
    name: string;
    description: string;
    amount: number;
    isDeductible: boolean;
    scheduleTypeID: number;
    parentObjectId: number;
}