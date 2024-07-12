// src/components/DeleteAppointmentService.js

import React from 'react';
import apiService from '../../api/appointmentService';

const DeleteAppointmentService = ({ appointmentId, serviceId }) => {
    const handleDelete = async () => {
        try {
            await apiService.deleteAppointmentService(appointmentId, serviceId);
            console.log(`Deleted appointment service with ID ${serviceId} for appointment ID ${appointmentId}`);
            // Optionally, update local state or inform parent component about deletion
        } catch (error) {
            console.error('Error deleting appointment service:', error);
            // Optionally, handle error or show error message to the user
        }
    };

    return (
        <div>
            <button onClick={handleDelete}>Delete Service</button>
        </div>
    );
};

export default DeleteAppointmentService;
