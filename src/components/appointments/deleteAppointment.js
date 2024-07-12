// components/DeleteAppointment.jsx

import React, { useEffect } from 'react';
import { useParams, useNavigate } from 'react-router-dom'; // Import useNavigate instead of useHistory
import { deleteAppointment } from '../../api/appointments';

const DeleteAppointment = () => {
    const { id } = useParams(); // Get the id from URL params
    const navigate = useNavigate(); // useNavigate hook for managing navigation

    useEffect(() => {
        const removeAppointment = async () => {
            try {
                await deleteAppointment(id); // Call your delete API function
                alert('Appointment deleted successfully!');
                navigate('/appointments'); // Redirect after deletion
            } catch (error) {
                console.error('Error deleting appointment:', error);
                alert('Failed to delete appointment. Please try again.');
            }
        };

        removeAppointment(); // Execute the deletion logic
    }, [id, navigate]); // Depend on id (URL param) and navigate (for navigation)

    return (
        <div>
            <h2>Deleting Appointment...</h2>
            {/* Optionally, add loading spinner or progress indicator */}
        </div>
    );
};

export default DeleteAppointment;
