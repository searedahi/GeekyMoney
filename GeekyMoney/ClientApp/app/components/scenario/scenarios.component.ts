import { Component, Inject } from '@angular/core';
import { Http } from '@angular/http';
import { Scenario } from '../_model/scenario.model';
import { ScenarioService } from './scenario.service'


@Component({
    selector: 'scenarios',
    templateUrl: './scenarios.component.html',
    providers: [ScenarioService],
    styleUrls: ['./scenario.component.css']
})

export class ScenariosComponent {
    public scenarios: Scenario[]

    constructor(private scenarioServie: ScenarioService) {
        this.getListData();
    }
    
    getListData() {
        this.scenarioServie.getData().subscribe(data => {
            this.scenarios = data.json() as Scenario[];
        },
            error => console.log(error)
        );
    }
}
