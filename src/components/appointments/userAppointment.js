// components/AppointmentsByUser.jsx

import React, { useState, useEffect } from 'react';
import { getAppointmentsByUserId } from '../../api/appointments';

const AppointmentsByUser = ({ userId }) => {
    const [appointments, setAppointments] = useState([]);
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState('');

    useEffect(() => {
        const fetchAppointments = async () => {
            try {
                const data = await getAppointmentsByUserId(userId);
                setAppointments(data);
            } catch (error) {
                setError(`Error fetching appointments: ${error.message}`);
            } finally {
                setLoading(false);
            }
        };

        fetchAppointments();
    }, [userId]);

    if (loading) {
        return <p>Loading...</p>;
    }

    if (error) {
        return <p>{error}</p>;
    }

    return (
        <div>
            <h2>Appointments for User ID: {userId}</h2>
            <ul>
                {appointments.map(appointment => (
                    <li key={appointment.id}>
                        <p>Name: {appointment.name}</p>
                        <p>Description: {appointment.description}</p>
                    </li>
                ))}
            </ul>
        </div>
    );
};

export default AppointmentsByUser;
