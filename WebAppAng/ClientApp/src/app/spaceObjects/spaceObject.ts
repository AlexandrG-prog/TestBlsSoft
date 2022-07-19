import { StarSystem } from "src/app/starSystems/starSystem";

export class SpaceObject {
    constructor(
        public starSystem?: StarSystem,
        public isCenterOfGravity?: boolean,
        public centerOfGravity?: string,
        public name?: string,
        public age?: number,
        public diameter?: number,
        public weight?: number,
        public type?: number,
        public starSystemId?: number,
        public id?: number
    ) {
    }
}