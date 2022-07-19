"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.SpaceObjectComponent = void 0;
var core_1 = require("@angular/core");
var spaceObjectData_service_1 = require("./spaceObjectData.service");
var spaceObject_1 = require("./spaceObject");
core_1.Component({
    selector: 'app-space',
    templateUrl: './spaceObject.component.html',
    providers: [spaceObjectData_service_1.SpaceObjectDataService],
    styleUrls: ['./spaceObject.component.css']
});
var SpaceObjectComponent = /** @class */ (function () {
    function SpaceObjectComponent(dataService) {
        this.dataService = dataService;
        this.spaceObject = new spaceObject_1.SpaceObject();
        this.tableMode = true;
        this.types = [
            { value: '1', viewValue: 'Планета' },
            { value: '2', viewValue: 'Звезда' },
            { value: '3', viewValue: 'Черная дыра' },
        ];
        this.selectedtype = 1;
    }
    SpaceObjectComponent.prototype.ngOnInit = function () {
        this.loadSpaceObjects();
        this.selectedtype = this.spaceObject.type;
    };
    SpaceObjectComponent.prototype.loadSpaceObjects = function () {
        var _this = this;
        this.dataService.getSpaceObjects()
            .subscribe(function (data) { return _this.spaceObjects = data; });
    };
    SpaceObjectComponent.prototype.save = function (form) {
        var _this = this;
        if (this.spaceObject.id == null) {
            this.dataService.createSpaceObject(this.spaceObject)
                .subscribe(function (data) { return _this.spaceObjects.push(data); });
        }
        else {
            this.dataService.updateSpaceObject(this.spaceObject)
                .subscribe(function (data) { return _this.loadSpaceObjects(); });
        }
        this.cancel();
    };
    SpaceObjectComponent.prototype.editSpaceObject = function (spaceObject) {
        this.spaceObject = spaceObject;
        this.tableMode = false;
    };
    SpaceObjectComponent.prototype.cancel = function () {
        this.spaceObject = new spaceObject_1.SpaceObject();
        this.tableMode = true;
    };
    SpaceObjectComponent.prototype.delete = function (spaceObject) {
        var _this = this;
        this.dataService.deleteSpaceObject(spaceObject)
            .subscribe(function (data) { return _this.loadSpaceObjects(); });
    };
    SpaceObjectComponent.prototype.add = function () {
        this.spaceObject = new spaceObject_1.SpaceObject();
        this.tableMode = false;
    };
    return SpaceObjectComponent;
}());
exports.SpaceObjectComponent = SpaceObjectComponent;
//# sourceMappingURL=spaceObject.component.js.map