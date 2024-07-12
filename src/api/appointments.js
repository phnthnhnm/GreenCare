import axios from 'axios';

const API_URL = 'https://localhost:7126/api/appointments';

export const getAllAppointments = async () => {
    const response = await axios.get(API_URL);
    return response.data;
};

export const getAppointmentById = async (id) => {
    const response = await axios.get(`${API_URL}/${id}`);
    return response.data;
};

export const getAppointmentsByUserId = async (userId) => {
    const response = await axios.get(`${API_URL}/user/${userId}`);
    return response.data;
};

export const getAppointmentsByExpertId = async (expertId) => {
    const response = await axios.get(`${API_URL}/expert/${expertId}`);
    return response.data;
};

export const createAppointment = async (appointment) => {
    const response = await axios.post(API_URL,  appointment);
    return response.data;
};

export const updateAppointment = async (id, appointment) => {
    const response = await axios.put(`${API_URL}/${id}`, appointment);
    return response.data;
};

export const deleteAppointment = async (id) => {
    await axios.delete(`${API_URL}/${id}`);
};
