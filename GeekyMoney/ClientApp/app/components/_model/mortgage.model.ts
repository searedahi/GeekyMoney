import { Fee } from "./fee.model"

export class Mortgage {
    id: number;
    name: string;
    description: string;
    loanAmount: number;
    interestRate: number;
    termInMonths: number;
    created: Date;
    mortgageFees: Fee[];
}