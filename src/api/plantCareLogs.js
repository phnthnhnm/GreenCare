import axios from 'axios';

const API_URL = 'https://localhost:7126/api/plant-care-logs';

export const getAllPlantCareLogs = async () => {
    const response = await axios.get(API_URL);
    return response.data;
};

export const getPlantCareLogById = async (id) => {
    const response = await axios.get(`${API_URL}/${id}`);
    return response.data;
};

export const createPlantCareLog = async (plantCareLog) => {
    const response = await axios.post(API_URL, plantCareLog);
    return response.data;
};

export const updatePlantCareLog = async (id, plantCareLog) => {
    const response = await axios.put(`${API_URL}/${id}`, plantCareLog);
    return response.data;
};

export const deletePlantCareLog = async (id) => {
    const response = await axios.delete(`${API_URL}/${id}`);
    return response.data;
};
