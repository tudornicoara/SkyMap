import {writable} from "svelte/store";
import Agent from "../api/agent";
import {DiscoverySourceType} from "../models/discoverySourceType";

const discoverySourceTypes = writable<DiscoverySourceType[]>([]);

const loadDiscoverySourceTypes = async () => {
    try {
        const result = await Agent.DiscoverySourceTypes.list();
        discoverySourceTypes.set(result);
    } catch (e) {
        console.log(e);
    }
}

const getDiscoverySourceTypes = () => {
    return discoverySourceTypes;
}

const discoverySourceTypeStore = {
    loadDiscoverySourceTypes,
    getDiscoverySourceTypes
}

export default discoverySourceTypeStore;
