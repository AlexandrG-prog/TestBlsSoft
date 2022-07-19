import { SpaceObject } from "src/app/spaceObjects/spaceObject";

export class StarSystem {
    constructor(
        public name?: string,
        public age?: number,
        public centersOfGravity?: SpaceObject[],
        public spaceObjects?: SpaceObject[],
        public id?: number
    ) { }
}