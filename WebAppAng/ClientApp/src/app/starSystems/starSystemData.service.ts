import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { StarSystem } from './starSystem';

@Injectable()
export class StarSystemDataService {

    private url = "/starsystem";

    constructor(private http: HttpClient) {
    }

    getStarSystems() {
        return this.http.get(this.url + "/get");
    }

    getStarSystem(id: number) {
        return this.http.get(this.url + '/' + id);
    }

    createStarSystem(starSystem: StarSystem) {
        return this.http.post(this.url + '/post', starSystem);
    }
    updateStarSystem(starSystem: StarSystem) {

        return this.http.put(this.url + '/put', starSystem);
    }
    deleteStarSystem(starSystem: StarSystem) {
        return this.http.delete(this.url + '/delete/' + starSystem.id);
    }
}