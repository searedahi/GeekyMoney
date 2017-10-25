import { Component, Input, Output, EventEmitter } from '@angular/core';

@Component({
    selector: 'rating-star',
    templateUrl: './rating.component.html',
    styleUrls: ['./rating.component.css']
})

export class RatingComponent {
    private range: Array<number> = [1, 2, 3, 4, 5];

    @Input() rating: number;
    @Input() realEstatePropertyId: number;

    @Output() ratingClicked = new EventEmitter<any>();

    onClick(value: number): void {
        this.rating = value;
        this.ratingClicked.emit({
            itemId: this.realEstatePropertyId,
            rating: this.rating
        });
    }
}