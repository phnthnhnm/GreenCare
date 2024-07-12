import axios from 'axios';

const API_BASE_URL = 'https://localhost:7126/api';

        
const apiService = {
    getAllAppointmentServices: async () => {
        try {
            const response = await axios.get(`${API_BASE_URL}/appointment-services`);
            return response.data;
        } catch (error) {
            console.error('Error fetching all appointment services:', error);
            throw error; // Optionally handle error or rethrow
        }
    },

    getServicesByAppointmentId: async (appointmentId) => {
        try {
            const response = await axios.get(`${API_BASE_URL}/appointment-services/services/${appointmentId}`);
            return response.data;
        } catch (error) {
            console.error(`Error fetching services for appointment ID ${appointmentId}:`, error);
            throw error; // Optionally handle error or rethrow
        }
    },

    getAppointmentsByServiceId: async (serviceId) => {
        try {
            const response = await axios.get(`${API_BASE_URL}/appointment-services/appointments/${serviceId}`);
            return response.data;
        } catch (error) {
            console.error(`Error fetching appointments for service ID ${serviceId}:`, error);
            throw error; // Optionally handle error or rethrow
        }
    },

    createAppointmentService: async (createDto) => {
        try {
            const response = await axios.post(`${API_BASE_URL}/appointment-services`, createDto);
            return response.data;
        } catch (error) {
            console.error('Error creating appointment service:', error);
            throw error; // Optionally handle error or rethrow
        }
    },

    deleteAppointmentService: async (appointmentId, serviceId) => {
        try {
            await axios.delete(`${API_BASE_URL}/appointment-services/${appointmentId}/${serviceId}`);
            console.log(`Deleted appointment service with ID ${serviceId} for appointment ID ${appointmentId}`);
        } catch (error) {
            console.error('Error deleting appointment service:', error);
            throw error; // Optionally handle error or rethrow
        }
    }
};

export default apiService;
