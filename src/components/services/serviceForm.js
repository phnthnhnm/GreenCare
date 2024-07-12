import React, { useState, useEffect } from 'react';
import { createService, updateService, getServiceById } from '../../api/services';
import { useParams, useNavigate } from 'react-router-dom';

const ServiceForm = ({ isEditMode }) => {
    const [formData, setFormData] = useState({
        name: '',
        description: '',
        price: 0,
        duration: 0,
    });
    const navigate = useNavigate();
    const { id } = useParams();

    useEffect(() => {
        if (isEditMode && id) {
            const fetchReview = async () => {
                try {
                    const data = await getServiceById(id);
                    setFormData(data);
                } catch (error) {
                    console.error('Error fetching service:', error);
                }
            };
            fetchReview();
        }
    }, [isEditMode, id]);

    const handleChange = (e) => {
        setFormData({
            ...formData,
            [e.target.name]: e.target.value,
        });
    };

    const handleSubmit = async (e) => {
        e.preventDefault();
        try {
            if (isEditMode) {
                await updateService(id, formData);
                console.log('Service updated successfully');
            } else {
                await createService(formData);
                console.log('Service created successfully');
            }
            navigate('/services');
        } catch (error) {
            console.error('Error:', error);
        }
    };

    return (
        
        <form onSubmit={handleSubmit}>
            <h2>Add Service</h2>
            <div>
                <label htmlFor="name">Service Name</label>
                <input
                    id="name"
                    name="name"
                    placeholder="Service Name"
                    required
                    onChange={handleChange}
                    value={formData.name}
                />
            </div>
            <div>
                <label htmlFor="description">Description</label>
                <input
                    id="description"
                    name="description"
                    required
                    placeholder="Description"
                    onChange={handleChange}
                    value={formData.description}
                />
            </div>
            <div>
                <label htmlFor="price">Price</label>
                <input
                    id="price"
                    name="price"
                    type="number"
                    min="0"
                    required
                    placeholder="Price"
                    onChange={handleChange}
                    value={formData.price}
                />
            </div>
            <div>
                <label htmlFor="duration">Duration</label>
                <input
                    id="duration"
                    name="duration"
                    type="number"
                    min="0"
                    required
                    placeholder="Duration"
                    onChange={handleChange}
                    value={formData.duration}
                />
            </div>
            <button type="submit">Save</button>
        </form>
    );
};

export default ServiceForm;
