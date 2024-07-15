import axios from 'axios';

const API_URL = 'https://localhost:7126/api/expert-services';

export const getAllExpertServices = async () => {
    const response = await axios.get(`${API_URL}/get-all`);
    return response.data;
};

export const getExpertServices = async () => {
    const response = await axios.get(API_URL, {
        headers: {
            Authorization: `Bearer ${localStorage.getItem('token')}`
        }
    });
    return response.data;
};

export const getExpertsByServiceId = async (serviceId) => {
    const response = await axios.get(`${API_URL}/expert-services/${serviceId}/experts`);
    return response.data;
};

export const createExpertService = async (service) => {
    const response = await axios.post(API_URL, service, {
        headers: {
            Authorization: `Bearer ${localStorage.getItem('token')}`
        }
    });
    return response.data;
};

export const deleteExpertService = async (expertId, serviceId) => {
    const response = await axios.delete(`${API_URL}/${expertId}/${serviceId}`, {
        headers: {
            Authorization: `Bearer ${localStorage.getItem('token')}`
        }
    });
    return response.data;
};
