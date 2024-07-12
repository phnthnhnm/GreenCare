import axios from 'axios';

const API_URL = 'https://localhost:7126/api/plant-types';

export const getAllPlantTypes = async (query) => {
    const response = await axios.get(API_URL, { params: query });
    return response.data;
};

export const getPlantTypeById = async (id) => {
    const response = await axios.get(`${API_URL}/${id}`);
    return response.data;
};

export const createPlantType = async (plantType) => {
    const response = await axios.post(API_URL, plantType);
    return response.data;
};

export const updatePlantType = async (id, plantType) => {
    const response = await axios.put(`${API_URL}/${id}`, plantType);
    return response.data;
};

export const deletePlantType = async (id) => {
    const response = await axios.delete(`${API_URL}/${id}`);
    return response.data;
};
