import { Mortgage } from "../_model/mortgage.model"
import { RealEstateProperty } from "../_model/realestateproperty.model"


export class Scenario {
    id: number;
    name: string;
    description: string;
    mortgage: Mortgage[];
    realEstateProperty: RealEstateProperty[];
}