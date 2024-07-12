import React, { useState } from 'react';
import { getServiceById,deleteService } from '../../api/services';
import { Link } from 'react-router-dom';

const GetServiceById = () => {
    const [id, setId] = useState('');
    const [service, setService] = useState(null);
    const [loading, setLoading] = useState(false);
    const [error, setError] = useState(null);

    const handleChange = (e) => {
        setId(e.target.value);
    };

    const handleDelete = async (id) => {
        await deleteService(id);
        setService(service.filter(service => service.id !== id));
    };

    const handleSubmit = async (e) => {
        e.preventDefault();
        setLoading(true);
        setError(null);
        try {
            const data = await getServiceById(id);
            setService(data);
        } catch (err) {
            setError(err);
        } finally {
            setLoading(false);
        }
    };

    return (
        <div>
            <h2>Find Service by ID</h2>
            <form onSubmit={handleSubmit}>
                <input
                    type="text"
                    placeholder="Enter Service ID"
                    value={id}
                    onChange={handleChange}
                />
                <button type="submit">Find</button>
            </form>
            {loading && <div>Loading...</div>}
            {error && <div>Error: {error.message}</div>}
            {service && (
                <div>
                    <h3>Service Details</h3>
                    <p><strong>ID:</strong> {service.id}</p>
                    <p><strong>Name:</strong> {service.name}</p>
                    <p><strong>Description:</strong> {service.description}</p>
                    <p><strong>Price:</strong> {service.price}</p>
                    <p><strong>Duration:</strong> {service.duration}</p>
                    <button onClick={() => handleDelete(service.id)}>Delete</button>
                    <Link to={`/services/${service.id}/edit`}>Edit</Link>
                </div>
            )}
        </div>
    );
};

export default GetServiceById;
