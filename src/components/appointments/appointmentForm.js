import React, { useState, useEffect } from 'react';
import { createAppointment, updateAppointment, getAppointmentById } from '../../api/appointments';
import { useNavigate, useParams } from 'react-router-dom';

const AppointmentForm = ({ isEditMode }) => {
    const [formData, setFormData] = useState({
        dateTime: '',
        userId: '',
        expertId: '',
        status: '',
    });

    const navigate = useNavigate();
    const { id } = useParams();

    useEffect(() => {
        if (isEditMode && id) {
            const fetchAppointment = async () => {
                try {
                    const data = await getAppointmentById(id);
                    setFormData(data);
                } catch (error) {
                    console.error('Error fetching appointment:', error);
                }
            };
            fetchAppointment();
        }
    }, [isEditMode, id]);

    const handleChange = (e) => {
        setFormData({
            ...formData,
            [e.target.name]: e.target.value
        });
    };

    const handleSubmit = async (e) => {
        e.preventDefault();
        try {
            if (isEditMode) {
                await updateAppointment(id, formData);
                console.log('Appointment updated successfully');
            } else {
                await createAppointment(formData);
                console.log('Appointment created successfully');
            }
            navigate('/appointments');
        } catch (error) {
            console.error('Error:', error);
        }
    };

    return (
        <div>
            <h2>{isEditMode ? 'Edit Appointment' : 'Create Appointment'}</h2>
            <form onSubmit={handleSubmit}>
                <div>
                    <label htmlFor="dateTime">Date</label>
                    <input
                        id="dateTime"
                        name="dateTime"
                        type="datetime-local"
                        placeholder="Date"
                        onChange={handleChange}
                        value={formData.dateTime}
                    />
                </div>
                <div>
                    <label htmlFor="userId">User ID</label>
                    <input
                        id="userId"
                        name="userId"
                        placeholder="User ID"
                        onChange={handleChange}
                        value={formData.userId}
                    />
                </div>
                <div>
                    <label htmlFor="expertId">Expert ID</label>
                    <input
                        id="expertId"
                        name="expertId"
                        placeholder="Expert ID"
                        onChange={handleChange}
                        value={formData.expertId}
                    />
                </div>
                <div>
                    <label htmlFor="status">Status</label>
                    <select
                        id="status"
                        name="status"
                        value={formData.status}
                        onChange={handleChange}
                    >
                        <option value="">Select a status</option>
                        <option value="In Progress">In Progress</option>
                        <option value="null">null</option>
                        <option value="Cancelled">Cancelled</option>
                        <option value="Completed">Completed</option>
                    </select>
                </div>
                <button type="submit">{isEditMode ? 'Update Appointment' : 'Create Appointment'}</button>
            </form>
        </div>
    );
};

export default AppointmentForm;