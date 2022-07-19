import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { StarSystemDataService } from './starSystemData.service';
import { StarSystem } from './starSystem';
import { NgForm } from '@angular/forms';

@Component({
    selector: 'app-star',
    templateUrl: './starSystem.component.html',
    providers: [StarSystemDataService],
    styleUrls: ['./starSystem.component.css']
})
export class StarSystemComponent implements OnInit {

    starSystem: StarSystem = new StarSystem();
    starSystems: StarSystem[];
    tableMode: boolean = true;

    constructor(private dataService: StarSystemDataService) { }

    ngOnInit() {
        this.loadStarSystems();
    }

    loadStarSystems() {
        this.dataService.getStarSystems()
            .subscribe((data: StarSystem[]) => this.starSystems = data);
    }

    save(form: NgForm) {

        if (this.starSystem.id == null) {
            this.dataService.createStarSystem(this.starSystem)
                .subscribe(data => this.loadStarSystems());
        } else {
            this.dataService.updateStarSystem(this.starSystem)
                .subscribe(data => this.loadStarSystems());
        }
        this.cancel();
    }
    editStarSystem(system: StarSystem) {
        this.starSystem = system;
        this.tableMode = false;
    }
    cancel() {
        this.starSystem = new StarSystem();
        this.tableMode = true;
    }
    delete(system: StarSystem) {
        this.dataService.deleteStarSystem(system)
            .subscribe(data => this.loadStarSystems());
    }
    add() {
        this.starSystem = new StarSystem();
        this.tableMode = false;
    }
}