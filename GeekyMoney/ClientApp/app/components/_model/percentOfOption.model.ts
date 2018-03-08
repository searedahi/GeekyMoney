export class PercentOfOption {
    id: number;
    name: string;    
    value: number;
    displayAs: string;

    constructor(id: number, name: string, val: number, displayAs: string) {
        this.id = id;
        this.name = name;
        this.value = val;
        this.displayAs = displayAs;
    }
}