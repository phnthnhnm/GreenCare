import React, { useState, useEffect } from 'react';
import { createPlantCareLog, getPlantCareLogById, updatePlantCareLog } from '../../api/plantCareLogs';
import { useNavigate, useParams } from 'react-router-dom';

const PlantCareLogForm = ({ isEditMode }) => {
    const [formData, setFormData] = useState({
        expertId: '',
        appointmentId: '',
        notes: '',
        logDate: '',
    });

    const navigate = useNavigate();
    const { id } = useParams();

    useEffect(() => {
        if (isEditMode) {
            const fetchPlantCareLog = async () => {
                const log = await getPlantCareLogById(id);
                setFormData(log);
            };
            fetchPlantCareLog();
        }
    }, [id, isEditMode]);

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
                await updatePlantCareLog(id, formData);
            } else {
                await createPlantCareLog(formData);
            }
            navigate('/plant-care-logs');
        } catch (error) {
            console.error('Error:', error);
        }
    };

    return (
        <form onSubmit={handleSubmit}>
            <div>
                <label htmlFor="expertId">Expert ID</label>
                <input
                    id="expertId"
                    name="expertId"
                    onChange={handleChange}
                    value={formData.expertId}
                />
            </div>
            <div>
                <label htmlFor="appointmentId">Appointment ID</label>
                <input
                    id="appointmentId"
                    name="appointmentId"
                    onChange={handleChange}
                    value={formData.appointmentId}
                />
            </div>
            <div>
                <label htmlFor="notes">Notes</label>
                <input
                    id="notes"
                    name="notes"
                    onChange={handleChange}
                    value={formData.notes}
                />
            </div>
            <div>
                <label htmlFor="logDate">Date</label>
                <input
                    id="logDate"
                    name="logDate"
                    type='datetime-local'
                    onChange={handleChange}
                    value={formData.logDate}
                />
            </div>
            <button type="submit">{isEditMode ? 'Update Plant Care Log' : 'Create Plant Care Log'}</button>
        </form>
    );
};

export default PlantCareLogForm;
