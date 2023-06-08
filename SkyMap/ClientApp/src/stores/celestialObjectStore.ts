import {writable} from "svelte/store";
import Agent from "../api/agent";
import {CelestialObject} from "../models/celestialObject";

const celestialObjects = writable<CelestialObject[]>([]);

const loadCelestialObjects = async () => {
    try {
        const result = await Agent.CelestialObjects.list();
        celestialObjects.set(result);
    } catch (e) {
        console.log(e);
    }
}

const getCelestialObjects = () => {
    return celestialObjects;
}

const celestialObjectStore = {
    loadCelestialObjects,
    getCelestialObjects
}

export default celestialObjectStore;
