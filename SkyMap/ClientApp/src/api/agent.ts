import axios from "axios";
import type {AxiosResponse} from "axios";
import {DiscoverySourceType} from "../models/discoverySourceType";
import {DiscoverySource} from "../models/discoverySource";
import {CelestialObjectType} from "../models/celestialObjectType";
import {CelestialObject} from "../models/celestialObject";

const sleep = (delay: number) => {
    return new Promise((resolve) => {
        setTimeout(resolve, delay)
    })
}

axios.defaults.baseURL = 'https://localhost:7014/api';

const responseBody = <T> (response: AxiosResponse<T>) => response.data;

const requests = {
    get: <T> (url: string) => axios.get<T>(url).then(responseBody),
    post: <T> (url: string, body: {}) => axios.post<T>(url, body).then(responseBody),
    put: <T> (url: string, body: {}) => axios.put<T>(url, body).then(responseBody),
    delete: <T> (url: string) => axios.delete<T>(url).then(responseBody)
}

const DiscoverySourceTypes = {
    list: () => requests.get<DiscoverySourceType[]>('/discoverySourceType'),
    get: (id: string) => requests.get<DiscoverySourceType>(`/discoverySourceType/${id}`),
    create: (type: DiscoverySourceType) => requests.post<DiscoverySourceType>('/discoverySourceType', type),
    delete: (id: string) => requests.delete<void>(`/discoverySourceType/${id}`)
}

const DiscoverySources = {
    list: () => requests.get<DiscoverySource[]>('/discoverySource'),
    get: (id: string) => requests.get<DiscoverySource>(`/discoverySource/${id}`),
    create: (type: DiscoverySource) => requests.post<DiscoverySource>('/discoverySource', type),
    delete: (id: string) => requests.delete<void>(`/discoverySource/${id}`)
}

const CelestialObjectTypes = {
    list: () => requests.get<CelestialObjectType[]>('/celestialObjectType'),
    get: (id: string) => requests.get<CelestialObjectType>(`/celestialObjectType/${id}`),
    create: (type: CelestialObjectType) => requests.post<CelestialObjectType>('/celestialObjectType', type),
    delete: (id: string) => requests.delete<void>(`/celestialObjectType/${id}`)
}

const CelestialObjects = {
    list: () => requests.get<CelestialObject[]>('/celestialObject'),
    get: (id: string) => requests.get<CelestialObject>(`/celestialObject/${id}`),
    create: (type: CelestialObject) => requests.post<CelestialObject>('/celestialObject', type),
    delete: (id: string) => requests.delete<void>(`/celestialObject/${id}`)
}

const agent = {
    DiscoverySourceTypes,
    DiscoverySources,
    CelestialObjectTypes,
    CelestialObjects
}

export default agent;