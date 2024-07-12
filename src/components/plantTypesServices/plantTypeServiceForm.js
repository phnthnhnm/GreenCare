import React, { useState } from 'react';
import { createPlantTypeService } from '../../api/plantTypeServices';
import { useNavigate } from 'react-router-dom';

const PlantTypeServiceForm = () => {
    const [formData, setFormData] = useState({
        plantTypeId: '',
        serviceId: '',
    });

    const navigate = useNavigate();

    const handleChange = (e) => {
        setFormData({
            ...formData,
            [e.target.name]: e.target.value
        });
    };

    const handleSubmit = async (e) => {
        e.preventDefault();
        try {
            await createPlantTypeService(formData);
            navigate('/plant-type-services');
        } catch (error) {
            console.error('Error:', error);
        }
    };

    return (
        <form onSubmit={handleSubmit}>
            <input
                name="plantTypeId"
                placeholder="Plant Type ID"
                onChange={handleChange}
                value={formData.plantTypeId}
            />
            <input
                name="serviceId"
                placeholder="Service ID"
                onChange={handleChange}
                value={formData.serviceId}
            />
            <button type="submit">Add Plant Type Service</button>
        </form>
    );
};

export default PlantTypeServiceForm;
