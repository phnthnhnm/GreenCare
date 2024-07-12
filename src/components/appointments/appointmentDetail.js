// components/AppointmentDetail.jsx

import React, { useState} from 'react';
import getAppointmentById from '../../api/appointmentService';
import DeleteAppointment from './deleteAppointment';
import { Link } from 'react-router-dom';

const AppointmentDetail = () => {
    const [id, setId] = useState('');
    const [appointment, setAppointment] = useState(null);
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState('');

    const handleChange = (e) => {
        setId(e.target.value);
    };

    const handleDelete = async (id) => {
        await DeleteAppointment(id);
        setAppointment(appointment.filter(appointment => appointment.id !== id));
    };

    const handleSubmit = async (e) => {
        e.preventDefault();
        setLoading(true);
        setError(null);
        try {
            const data = await getAppointmentById(id);
            setAppointment(data);
        } catch (err) {
            setError(err);
        } finally {
            setLoading(false);
        }
    };

    return (
        <div>
            <h2>Find Appointment by ID</h2>
            <form onSubmit={handleSubmit}>
                <input
                    type="text"
                    placeholder="Enter Appointment ID"
                    value={id}
                    onChange={handleChange}
                />
                <button type="submit">Find</button>
            </form>
            {loading && <div>Loading...</div>}
            {error && <div>Error: {error.message}</div>}
            {appointment && (
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
            )}
        </div>
    );
};

export default AppointmentDetail;
