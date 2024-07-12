import React, { useState, useEffect } from 'react';
import apiService from '../../api/appointmentService';


const AppointmentServicesList = () => {
    const [appointmentServices, setAppointmentServices] = useState([]);
    const [loading, setLoading] = useState(true);

    useEffect(() => {
        const fetchAppointmentServices = async () => {
            try {
                const data = await apiService.getAllAppointmentServices();
                setAppointmentServices(data);
                setLoading(false);
            } catch (error) {
                console.error('Error fetching appointment services:', error);
            }
        };

        fetchAppointmentServices();
    }, []);

    return (
        <div>
            <h2>All Appointment Services</h2>
            {loading ? (
                <p>Loading...</p>
            ) : (
                <ul>
                    {appointmentServices.map(service => (
                        <li key={service.id}>
                            <strong>Service ID:</strong> {service.serviceId}<br />
                            <strong>Appointment ID:</strong> {service.appointmentId}<br />
                            <button onClick={() => apiService.deleteAppointmentService(service.appointmentId,service.serviceId)}>Delete</button>
                        </li>
                    ))}
                </ul>
            )}
        </div>
    );
};

export default AppointmentServicesList;
