import React, { useState, useEffect } from 'react';
import { createPlantType, getPlantTypeById, updatePlantType } from '../../api/plantType';
import { useNavigate, useParams } from 'react-router-dom';

const PlantTypeForm = ({ isEditMode }) => {
    const [formData, setFormData] = useState({
        name: '',
    });

    const navigate = useNavigate();
    const { id } = useParams();

    useEffect(() => {
        if (isEditMode) {
            const fetchPlantType = async () => {
                const pt = await getPlantTypeById(id);
                setFormData(pt);
            };
            fetchPlantType();
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
                await updatePlantType(id, formData);
            } else {
                await createPlantType(formData);
            }
            navigate('/plant-types');
        } catch (error) {
            console.error('Error:', error);
        }
    };

    return (
        <form onSubmit={handleSubmit}>
            <input
                name="name"
                placeholder="Name"
                onChange={handleChange}
                value={formData.name}
            />
            <button type="submit">{isEditMode ? 'Update Plant Type' : 'Create Plant Type'}</button>
        </form>
    );
};

export default PlantTypeForm;
