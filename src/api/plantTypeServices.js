import axios from 'axios';

const API_URL = 'https://localhost:7126/api/plant-type-services';

export const getAllPlantTypeServices = async () => {
    const response = await axios.get(API_URL);
    return response.data;
};

export const getServicesByPlantTypeId = async (plantTypeId) => {
    const response = await axios.get(`${API_URL}/${plantTypeId}/services`);
    return response.data;
};

export const getPlantTypesByServiceId = async (serviceId) => {
    const response = await axios.get(`${API_URL}/${serviceId}/plant-types`);
    return response.data;
};

export const createPlantTypeService = async (plantTypeService) => {
    const response = await axios.post(API_URL, plantTypeService);
    return response.data;
};

export const deletePlantTypeService = async (plantTypeId, serviceId) => {
    const response = await axios.delete(`${API_URL}/${plantTypeId}/${serviceId}`);
    return response.data;
};
