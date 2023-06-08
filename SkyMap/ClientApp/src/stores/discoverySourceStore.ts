import {writable} from "svelte/store";
import Agent from "../api/agent";
import {DiscoverySource} from "../models/discoverySource";

const discoverySources = writable<DiscoverySource[]>([]);

const loadDiscoverySources = async () => {
    try {
        const result = await Agent.DiscoverySources.list();
        discoverySources.set(result);
    } catch (e) {
        console.log(e);
    }
}

const getDiscoverySources = () => {
    return discoverySources;
}

const discoverySourceStore = {
    loadDiscoverySources,
    getDiscoverySources
}

export default discoverySourceStore;
