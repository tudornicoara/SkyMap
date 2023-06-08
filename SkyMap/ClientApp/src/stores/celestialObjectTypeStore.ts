import {writable} from "svelte/store";
import Agent from "../api/agent";
import {CelestialObjectType} from "../models/celestialObjectType";

const celestialObjectTypes = writable<CelestialObjectType[]>([]);

const loadCelestialObjectTypes = async () => {
    try {
        const result = await Agent.CelestialObjectTypes.list();
        celestialObjectTypes.set(result);
    } catch (e) {
        console.log(e);
    }
}

const getCelestialObjectTypes = () => {
    return celestialObjectTypes;
}

const celestialObjectTypeStore = {
    loadCelestialObjectTypes,
    getCelestialObjectTypes
}

export default celestialObjectTypeStore;
