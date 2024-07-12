import React, { useEffect, useState } from 'react';
import { Link } from 'react-router-dom';
import { getAllAppointments,deleteAppointment } from '../../api/appointments';

const AppointmentList = () => {
    const [appointments, setAppointments] = useState([]);

    useEffect(() => {
        const fetchAppointments = async () => {
            const data = await getAllAppointments();
            setAppointments(data);
        };
        fetchAppointments();
    }, []);

    
    const handleDelete = async (id) => {
        await deleteAppointment(id);
        setAppointments(appointments.filter(appointments => appointments.id !== id));
    };


    return (
        <div>
            <h2>Appointments</h2>
            <ul>
                {appointments.map(appointment => (
                    <li key={appointment.id}>
                        <p>ID: {appointment.id}</p>
                        <p>UserID: {appointment.userId}</p>
                        <p>ExpertID: {appointment.expertId}</p>
                        <p>Date: {appointment.dateTime}</p>
                        <p>Status: {appointment.status}</p>
                        <p>Payment Details:</p>
                        <div>
                            <p><strong>Payment ID:</strong> {appointment.payment?.id}</p>
                            <p><strong>Amount:</strong> {appointment.payment?.amount}</p>
                            <p><strong>Payment Method:</strong> {appointment.payment?.paymentMethod}</p>
                            <p><strong>Date:</strong> {appointment.payment?.dateTime}</p>
                            <p><strong>Status:</strong> {appointment.payment?.status}</p>
                        </div>
                        <button onClick={() => handleDelete(appointment.id)}>Delete</button>
                        <Link to={`/appointments/${appointment.id}/edit`}>Edit</Link>
                    </li>
                ))}
            </ul>
        </div>
    );
};

export default AppointmentList; 