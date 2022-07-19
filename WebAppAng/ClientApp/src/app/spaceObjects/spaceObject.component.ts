import { Component, OnInit } from '@angular/core';
import { SpaceObjectDataService } from './spaceObjectData.service';
import { SpaceObject } from './spaceObject';
import { NgForm } from '@angular/forms';
import { StarSystem } from '../starSystems/starSystem';

@Component({
    selector: 'app-space',
    templateUrl: './spaceObject.component.html',
    providers: [SpaceObjectDataService],
    styleUrls: ['./spaceObject.component.css']
})

export class SpaceObjectComponent implements OnInit {

    spaceObject: SpaceObject = new SpaceObject();
    spaceObjects: SpaceObject[];
    tableMode: boolean = true;
    types: object[] = [
        { value: 1, viewValue: 'Планета' },
        { value: 2, viewValue: 'Звезда' },
        { value: 3, viewValue: 'Черная дыра' },
    ];
    starSystemsSelectList: StarSystem[];

    constructor(private dataService: SpaceObjectDataService) { }

    ngOnInit() {
        this.spaceObject.type = 1;
        this.spaceObject.centerOfGravity = this.spaceObject.isCenterOfGravity ? "да" : "нет";
        this.dataService.getStarSystemsSelectList()
            .subscribe((data: StarSystem[]) => this.starSystemsSelectList = data);
        this.loadSpaceObjects();
    }

    loadSpaceObjects() {
        this.dataService.getSpaceObjects()
            .subscribe((data: SpaceObject[]) => this.spaceObjects = data);
    }

    save(form: NgForm) {

        this.spaceObject.type = +this.spaceObject.type;
        this.spaceObject.starSystemId = +this.spaceObject.starSystemId;

        if (this.spaceObject.id == null) {
            this.dataService.createSpaceObject(this.spaceObject)
                .subscribe(data => this.loadSpaceObjects());
        } else {
            this.dataService.updateSpaceObject(this.spaceObject)
                .subscribe(data => this.loadSpaceObjects());
        }
        this.cancel();
    }
    editSpaceObject(spaceObject: SpaceObject) {
        this.spaceObject = spaceObject;
        this.tableMode = false;
    }
    cancel() {
        this.spaceObject = new SpaceObject();
        this.tableMode = true;
    }
    delete(spaceObject: SpaceObject) {
        this.dataService.deleteSpaceObject(spaceObject)
            .subscribe(data => this.loadSpaceObjects());
    }
    add() {
        this.spaceObject = new SpaceObject();
        this.tableMode = false;
    }
}