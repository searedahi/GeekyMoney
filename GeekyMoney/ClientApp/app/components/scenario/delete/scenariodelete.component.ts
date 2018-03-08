import { Component } from '@angular/core';
import { Router, ActivatedRoute, Params } from '@angular/router';

import { Scenario } from '../../_model/scenario.model';
import { ScenarioService } from '../scenario.service';

@Component({
    selector: 'scenario/delete',
    templateUrl: './scenariodelete.component.html',
    providers: [ScenarioService],
    styleUrls: ['../scenario.component.css']
})
export class ScenarioDeleteComponent {

    public scenario: Scenario = new Scenario();
    private id: string;
    constructor(private scenarioService: ScenarioService, private route: ActivatedRoute, private redirect: Router) {

        this.route.params.subscribe((params: Params) => {
            this.id = params['id'];
        });

        if (this != undefined && this.id != undefined && this.id != "0") {
            this.scenarioService.getDetail(this.id).subscribe(data => {
                this.scenario = data.json();
            },
                error => console.log(error)
            );
        }

    }

    onDelete(id: number) {
        this.scenarioService.deleteData(id).subscribe(data => {
            this.list();
        },
            error => console.log(error)
        );
    }  

    list() {
        this.redirect.navigateByUrl('/scenarios');
    }

}



