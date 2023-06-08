import axios from "axios";
import type {AxiosResponse} from "axios";
import {DiscoverySourceType} from "../models/discoverySourceType";

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
    list: () => requests.get<DiscoverySourceType[]>('/discoverySourceType')
}

const agent = {
    DiscoverySourceTypes
}

export default agent;