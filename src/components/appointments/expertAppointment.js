
import React, { useState, useEffect } from 'react';
import { getAppointmentsByExpertId } from '../../api/appointments';

const AppointmentsByExpert = ({ expertId }) => {
    const [appointments, setAppointments] = useState([]);
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState('');

    useEffect(() => {
        const fetchAppointments = async () => {
            try {
                const data = await getAppointmentsByExpertId(expertId);
                setAppointments(data);
            } catch (error) {
                setError(`Error fetching appointments: ${error.message}`);
            } finally {
                setLoading(false);
            }
        };

        fetchAppointments();
    }, [expertId]);

    if (loading) {
        return <p>Loading...</p>;
    }

    if (error) {
        return <p>{error}</p>;
    }

    return (
        <div>
            <h2>Appointments for Expert ID: {expertId}</h2>
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

export default AppointmentsByExpert;
