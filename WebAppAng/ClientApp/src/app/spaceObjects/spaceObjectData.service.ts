import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { SpaceObject } from './spaceObject';

@Injectable()
export class SpaceObjectDataService {

    private url = "/spaceobject";

    constructor(private http: HttpClient) {
    }

    getSpaceObjects() {
        return this.http.get(this.url + "/get");
    }

    getSpaceObject(id: number) {
        return this.http.get(this.url + '/' + id);
    }

    createSpaceObject(spaceObject: SpaceObject) {
        return this.http.post(this.url + '/post', spaceObject);
    }
    updateSpaceObject(spaceObject: SpaceObject) {

        return this.http.put(this.url + '/put', spaceObject);
    }
    deleteSpaceObject(spaceObject: SpaceObject) {
        return this.http.delete(this.url + '/delete/' + spaceObject.id);
    }

    getStarSystemsSelectList() {
        return this.http.get("/starsystem/get");
    }
}