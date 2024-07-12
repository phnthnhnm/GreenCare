import React, { useState } from 'react';
import { getPlantTypeById } from '../../api/plantType';

const PlantTypeDetails = () => {
    const [id, setId] = useState('');
    const [plantType, setPlantType] = useState(null);
    const [loading, setLoading] = useState(false);
    const [error, setError] = useState(null);

    const handleChange = (e) => {
        setId(e.target.value);
    };

    const handleSubmit = async (e) => {
        e.preventDefault();
        setLoading(true);
        setError(null);
        try {
            const data = await getPlantTypeById(id);
            setPlantType(data);
        } catch (err) {
            setError(err);
        } finally {
            setLoading(false);
        }
    };

    return (
        <div>
            <h2>Find Plant Type by ID</h2>
            <form onSubmit={handleSubmit}>
                <input
                    type="text"
                    placeholder="Enter Plant Type ID"
                    value={id}
                    onChange={handleChange}
                />
                <button type="submit">Find</button>
            </form>
            {loading && <div>Loading...</div>}
            {error && <div>Error: {error.message}</div>}
            {plantType && (
                <div>
                    <h3>Plant Type Details</h3>
                    <p><strong>ID:</strong> {plantType.id}</p>
                    <p><strong>Name:</strong> {plantType.name}</p>
                </div>
            )}
        </div>
    );
};

export default PlantTypeDetails;
