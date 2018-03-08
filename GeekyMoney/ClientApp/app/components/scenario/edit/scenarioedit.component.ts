import { Component } from '@angular/core';
import { Router, ActivatedRoute, Params } from '@angular/router';

import { Scenario } from '../../_model/scenario.model';
import { ScenarioService } from '../scenario.service';

@Component({
    selector: 'scenario/edit',
    templateUrl: './scenarioedit.component.html',
    providers: [ScenarioService],
    styleUrls: ['../scenario.component.css']
})
export class ScenarioEditComponent {

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

    save() {

        if (this.scenario.id == undefined || this.scenario.id == 0) {
            this.scenarioService.postData(this.scenario)
                .subscribe(
                (response) => {
                    console.log(response);
                    this.list();
                },


                (error) => console.log(error)
                );
        }
        else {
            this.scenarioService.putData(this.scenario)
                .subscribe(
                (response) => {
                    console.log(response);
                    this.list();
                },
                (error) => console.log(error)
                );
        }
    }

    list() {
        this.redirect.navigateByUrl('/scenarios');
    }

}



