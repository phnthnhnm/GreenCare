import React, { useState } from 'react';
import { createExpertService } from '../../api/expertServices';
import { useNavigate } from 'react-router-dom';

const ExpertServiceForm = () => {
    const [formData, setFormData] = useState({
        expertId: '',
        serviceId: ''
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
            await createExpertService(formData);
            console.log('Expert service created successfully');
            navigate('/expert-services');
        } catch (error) {
            console.error('Error:', error);
        }
    };

    return (
        <form onSubmit={handleSubmit}>
            <input name="expertId" placeholder="Expert ID" onChange={handleChange} value={formData.expertId} />
            <input name="serviceId" placeholder="Service ID" onChange={handleChange} value={formData.serviceId} />
            <button type="submit">Create Expert Service</button>
        </form>
    );
};

export default ExpertServiceForm;
