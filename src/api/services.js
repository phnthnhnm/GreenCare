import axios from 'axios';

const API_URL = 'http://localhost:5062/api/services';

export const getAllServices = async () => {
    const response = await axios.get(API_URL);
    return response.data;
};

export const getServiceById = async (id) => {
    try {
      const response = await axios.get(`${API_URL}/${id}`);
      return response.data;
    } catch (error) {
      console.error('Error fetching service:', error);
      throw error;
    }
};

export const createService = async (service) => {
    const response = await axios.post(API_URL, service);
    return response.data;
};

export const updateService = async (id, service) => {
    const response = await axios.put(`${API_URL}/${id}`, service);
    return response.data;
};

export const deleteService = async (id) => {
    await axios.delete(`${API_URL}/${id}`);
};
