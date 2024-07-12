import axios from 'axios';

const API_URL = 'https://localhost:7126/api/payments';

export const getAllPayments = async () => {
    const response = await axios.get(API_URL);
    return response.data;
};

export const getPaymentById = async (id) => {
    const response = await axios.get(`${API_URL}/${id}`);
    return response.data;
};

export const createPayment = async (payment) => {
    const response = await axios.post(API_URL, payment);
    return response.data;
};

export const updatePayment = async (id, payment) => {
    const response = await axios.put(`${API_URL}/${id}`, payment);
    return response.data;
};

export const deletePayment = async (id) => {
    const response = await axios.delete(`${API_URL}/${id}`);
    return response.data;
};
